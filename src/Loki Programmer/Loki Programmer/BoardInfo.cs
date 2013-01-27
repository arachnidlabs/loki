using MiscUtil.Conversion;
using MiscUtil.IO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LokiProgrammer
{
    public class BoardInfo : INotifyPropertyChanged, IEditableObject
    {
        public const int SUPPORTED_SYSTEM_VERSION = 1;
        public const byte NUM_GPIOS = 32;

        [Flags]
        public enum ConfigFlags : ulong {
            Configured      = 0x01,    // Configured if set
            IsHost          = 0x02,    // True for the Loki, false for planks
            TopPlank        = 0x04,    // Can't have other planks stacked on it
            SuppliesVin     = 0x08,    // Supplies power on Vin
            Supplies5V      = 0x10,    // Supplies power on +5V
        }

        public class PinMapping
        {
            private string hostPin;
            private BoardInfo targetPlank;
            private string plankPin;

            public PinMapping(string hostPin, BoardInfo targetPlank, string plankPin)
            {
                this.hostPin = hostPin;
                this.targetPlank = targetPlank;
                this.plankPin = plankPin;
            }

            public string HostPin
            {
                get
                {
                    return this.hostPin;
                }
            }

            public BoardInfo TargetPlank
            {
                get
                {
                    return this.targetPlank;
                }
            }

            public string PlankPin
            {
                get
                {
                    return this.plankPin;
                }
            }
        }

        public class PinInfo : INotifyPropertyChanged, IEditableObject
        {
            private PinInfo backup = null;

            private int pinNumber;
            private string name = "";

            public PinInfo(int pinNumber)
            {
                this.pinNumber = pinNumber;
            }

            public PinInfo(int pinNumber, string name)
                : this(pinNumber)
            {
                this.name = name;
            }

            public int PinNumber
            {
                get
                {
                    return this.pinNumber;
                }
            }

            public string Name
            {
                get
                {
                    return this.name;
                }
                set
                {
                    this.name = value;
                    if (this.PropertyChanged != null)
                        this.PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            public void BeginEdit()
            {
                if (this.backup == null)
                    this.backup = this.MemberwiseClone() as PinInfo;
            }

            public void CancelEdit()
            {
                this.Name = this.backup.Name;
                this.backup = null;
            }

            public void EndEdit()
            {
                this.backup = null;
            }
        }

        private int systemVersion = 1;
        private string productName;
        private string productURL;
        private string shortName;
        private Guid productId = new Guid();
        private Guid serial = Guid.Empty;
        private ConfigFlags flags;
        private ObservableCollection<PinInfo> gpioNames = new ObservableCollection<PinInfo>();
        protected ObservableCollection<PinMapping> pinMap = new ObservableCollection<PinMapping>();
        private byte address;

        private BoardInfo backup = null;

        public BoardInfo(byte address)
        {
            this.address = address;
            for (int i = 0; i < NUM_GPIOS; i++)
                gpioNames.Add(new PinInfo(i + 1));
            this.gpioNames.CollectionChanged += gpioNames_CollectionChanged;
            this.pinMap.CollectionChanged += pinMap_CollectionChanged;
        }

        void pinMap_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("PinMap");
        }

        void gpioNames_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("GPIONames");
        }

        public BoardInfo(Stream stream, byte address) : this(address)
        {
            this.Deserialize(stream);
        }

        public void Deserialize(Stream stream)
        {
            EndianBinaryReader reader = new EndianBinaryReader(EndianBitConverter.Little, stream);
            if (Encoding.UTF8.GetString(reader.ReadBytes(4)) != "Loki")
                throw new BoardInfoFormatException("Board info must begin with the 4 byte string 'Loki'");
            
            this.systemVersion = reader.ReadByte();
            if(systemVersion > SUPPORTED_SYSTEM_VERSION)
                throw new BoardInfoFormatException(String.Format("Unsupported system version {0}", systemVersion));

            this.productName = decodePaddedString(Encoding.UTF8, reader.ReadBytes(32));
            this.productURL = decodePaddedString(Encoding.UTF8, reader.ReadBytes(64));
            this.shortName = decodePaddedString(Encoding.UTF8, reader.ReadBytes(16));
            this.productId = new Guid(reader.ReadBytes(16));
            this.serial = new Guid(reader.ReadBytes(16));
            this.flags = (ConfigFlags)reader.ReadUInt32();
            int numGPIOs = reader.ReadByte();
            if (numGPIOs != NUM_GPIOS)
                throw new BoardInfoFormatException(string.Format("Expected {0} GPIOs, read {1}", NUM_GPIOS, numGPIOs));


            reader.Seek(1024, SeekOrigin.Begin);
            gpioNames = new ObservableCollection<PinInfo>();
            for (int i = 0; i < NUM_GPIOS; i++)
            {
                string pinName = decodePaddedString(Encoding.UTF8, reader.ReadBytes(32));
                gpioNames.Add(new PinInfo(i + 1, pinName));
            }
        }

        public void Serialize(Stream stream)
        {
            EndianBinaryWriter writer = new EndianBinaryWriter(EndianBitConverter.Little, stream);
            writer.Write(Encoding.UTF8.GetBytes("Loki"));
            writer.Write((byte)this.systemVersion);
            writer.Write(encodePaddedString(Encoding.UTF8, this.productName ?? "", 32));
            writer.Write(encodePaddedString(Encoding.UTF8, this.productURL ?? "", 64));
            writer.Write(encodePaddedString(Encoding.UTF8, this.shortName ?? "", 16));
            writer.Write(this.productId.ToByteArray());
            writer.Write(this.serial.ToByteArray());
            writer.Write((UInt32)this.flags);
            writer.Write(NUM_GPIOS);

            writer.Seek(1024, SeekOrigin.Begin);
            for (int i = 0; i < NUM_GPIOS; i++)
                writer.Write(encodePaddedString(Encoding.UTF8, gpioNames[i].Name ?? "", 32));
        }

        private static string decodePaddedString(Encoding encoding, byte[] bytes)
        {
            int len = Array.IndexOf<byte>(bytes, 0);
            if (len == -1)
                len = bytes.Length;
            return encoding.GetString(bytes, 0, len);
        }

        private static byte[] encodePaddedString(Encoding encoding, string str, int len) {
            byte[] ret = new byte[len];
            encoding.GetBytes(str, 0, Math.Min(len, str.Length), ret, 0);
            return ret;
        }

        public int SystemVersion
        {
            get
            {
                return this.systemVersion;
            }
            set
            {
                this.systemVersion = value;
                NotifyPropertyChanged();
            }
        }

        public string ProductName
        {
            get
            {
                return this.productName;
            }
            set
            {
                this.productName = value;
                NotifyPropertyChanged();
            }
        }

        public string ProductURL
        {
            get
            {
                return this.productURL;
            }
            set
            {
                this.productURL = value;
                NotifyPropertyChanged();
            }
        }

        public string ShortName
        {
            get
            {
                return this.shortName;
            }
            set
            {
                this.shortName = value;
                NotifyPropertyChanged();
            }
        }

        public Guid ProductId
        {
            get
            {
                return this.productId;
            }
            set
            {
                this.productId = value;
                NotifyPropertyChanged();
            }
        }

        public Guid Serial
        {
            get
            {
                return this.serial;
            }
            set
            {
                this.serial = value;
                NotifyPropertyChanged();
            }
        }

        public ConfigFlags Flags
        {
            get
            {
                return this.flags;
            }
            set
            {
                this.flags = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<PinInfo> GPIONames
        {
            get
            {
                return this.gpioNames;
            }
            set
            {
                this.gpioNames = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsConfigured
        {
            get
            {
                return (this.flags & ConfigFlags.Configured) != 0;
            }
            set
            {
                if (value)
                {
                    this.flags |= ConfigFlags.Configured;
                }
                else
                {
                    this.flags &= ~ConfigFlags.Configured;
                }
                NotifyPropertyChanged();
            }
        }

        public bool IsHost
        {
            get
            {
                return (this.flags & ConfigFlags.IsHost) != 0;
            }
            set
            {
                if (value)
                {
                    this.flags |= ConfigFlags.IsHost;
                }
                else
                {
                    this.flags &= ~ConfigFlags.IsHost;
                }
                NotifyPropertyChanged();
            }
        }

        public bool IsTopPlank
        {
            get
            {
                return (this.flags & ConfigFlags.TopPlank) != 0;
            }
            set
            {
                if (value)
                {
                    this.flags |= ConfigFlags.TopPlank;
                }
                else
                {
                    this.flags &= ~ConfigFlags.TopPlank;
                }
                NotifyPropertyChanged();
            }
        }

        public bool SuppliesVIN
        {
            get
            {
                return (this.flags & ConfigFlags.SuppliesVin) != 0;
            }
            set
            {
                if (value)
                {
                    this.flags |= ConfigFlags.SuppliesVin;
                }
                else
                {
                    this.flags &= ~ConfigFlags.SuppliesVin;
                }
                NotifyPropertyChanged();
            }
        }

        public bool Supplies5V
        {
            get
            {
                return (this.flags & ConfigFlags.Supplies5V) != 0;
            }
            set
            {
                if (value)
                {
                    this.flags |= ConfigFlags.Supplies5V;
                }
                else
                {
                    this.flags &= ~ConfigFlags.Supplies5V;
                }
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<PinMapping> PinMap
        {
            get
            {
                return this.pinMap;
            }
        }

        public byte Address
        {
            get
            {
                return this.address;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void BeginEdit()
        {
            if (backup == null)
                backup = (BoardInfo) this.MemberwiseClone();
        }

        public void CancelEdit()
        {
            this.Flags = backup.Flags;
            this.GPIONames = backup.GPIONames;
            this.ProductId = backup.ProductId;
            this.ProductName = backup.ProductName;
            this.ProductURL = backup.ProductURL;
            this.Serial = backup.Serial;
            this.ShortName = backup.ShortName;
            this.SystemVersion = backup.SystemVersion;
            backup = null;
        }

        public void EndEdit()
        {
            backup = null;
        }

        public override string ToString()
        {
            return this.ShortName;
        }
    }
}
