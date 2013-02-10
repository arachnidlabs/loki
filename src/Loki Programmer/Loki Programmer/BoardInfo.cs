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
        public enum ConfigFlags : ushort {
            Configured      = 0x01,    // Configured if set
            IsHost          = 0x02,    // True for the Loki, false for planks
            TopPlank        = 0x04,    // Can't have other planks stacked on it
            SuppliesVin     = 0x08,    // Supplies power on Vin
            Supplies5V      = 0x10,    // Supplies power on +5V
        }

        [Flags]
        public enum PinTypes : byte
        {
            Input            = 0x80,    // Input pin
            Output           = 0x40,    // Output pin
            Analog           = 0x20,    // Analog pin
        }

        public class PinMapping
        {
            private string hostPin;
            private BoardInfo targetPlank;
            private string plankPin;
            private PinTypes type;

            public PinMapping(string hostPin, BoardInfo targetPlank, string plankPin, PinTypes type)
            {
                this.hostPin = hostPin;
                this.targetPlank = targetPlank;
                this.plankPin = plankPin;
                this.type = type;
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

            public PinTypes Type
            {
                get
                {
                    return this.type;
                }
            }

            public bool IsInput
            {
                get
                {
                    return (this.type & PinTypes.Input) != 0;
                }
            }

            public bool IsOutput
            {
                get
                {
                    return (this.type & PinTypes.Output) != 0;
                }
            }

            public bool IsAnalog
            {
                get
                {
                    return (this.type & PinTypes.Analog) != 0;
                }
            }
        }

        public class PinInfo : INotifyPropertyChanged, IEditableObject
        {
            private PinInfo backup = null;

            private int pinNumber;
            private string name = "";
            private PinTypes type;

            public PinInfo(int pinNumber)
            {
                this.pinNumber = pinNumber;
            }

            public PinInfo(int pinNumber, string name, PinTypes type)
                : this(pinNumber)
            {
                this.name = name;
                this.type = type;
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

            public PinTypes Type
            {
                get
                {
                    return this.type;
                }
                set
                {
                    this.type = value;
                    if (this.PropertyChanged != null)
                        this.PropertyChanged(this, new PropertyChangedEventArgs("Flags"));
                }
            }

            public bool IsInput
            {
                get
                {
                    return (this.type & PinTypes.Input) != 0;
                }
                set
                {
                    if(value) {
                        this.Type |= PinTypes.Input;
                    } else {
                        this.Type &= ~PinTypes.Input;
                    }
                }
            }

            public bool IsOutput
            {
                get
                {
                    return (this.type & PinTypes.Output) != 0;
                }
                set
                {
                    if(value) {
                        this.Type |= PinTypes.Output;
                    } else {
                        this.Type &= ~PinTypes.Output;
                    }
                }
            }

            public bool IsAnalog
            {
                get
                {
                    return (this.type & PinTypes.Analog) != 0;
                }
                set
                {
                    if(value) {
                        this.Type |= PinTypes.Analog;
                    } else {
                        this.Type &= ~PinTypes.Analog;
                    }
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
                this.Type = this.backup.Type;
                this.backup = null;
            }

            public void EndEdit()
            {
                this.backup = null;
            }
        }

        private string plankName;
        private string version;
        private ushort makerId;
        private ushort plankId;
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
            if (Encoding.UTF8.GetString(reader.ReadBytes(2)) != "LK")
                throw new BoardInfoFormatException("Board info must begin with the 2 byte string 'LK'");

            this.makerId = reader.ReadUInt16();
            this.plankId = reader.ReadUInt16();
            this.flags = (ConfigFlags)reader.ReadUInt16();
            int numGPIOs = reader.ReadByte();
            if (numGPIOs != NUM_GPIOS)
                throw new BoardInfoFormatException(string.Format("Expected {0} GPIOs, read {1}", NUM_GPIOS, numGPIOs));

            int len = reader.ReadByte();
            this.plankName = Encoding.UTF8.GetString(reader.ReadBytes(len));

            len = reader.ReadByte();
            this.version = Encoding.UTF8.GetString(reader.ReadBytes(len));

            gpioNames = new ObservableCollection<PinInfo>();
            for (int i = 0; i < NUM_GPIOS; i++)
            {
                byte lengthByte = reader.ReadByte();
                string pinName = Encoding.UTF8.GetString(reader.ReadBytes(lengthByte & 0x1F));
                gpioNames.Add(new PinInfo(i + 1, pinName, (PinTypes)(lengthByte & 0xE0)));
            }
        }

        public void Serialize(Stream stream)
        {
            EndianBinaryWriter writer = new EndianBinaryWriter(EndianBitConverter.Little, stream);
            writer.Write(Encoding.UTF8.GetBytes("LK"));
            writer.Write(this.makerId);
            writer.Write(this.plankId);
            writer.Write((UInt16)this.flags);
            writer.Write((byte)NUM_GPIOS);

            byte[] nameBytes = Encoding.UTF8.GetBytes(this.plankName);
            writer.Write((byte)nameBytes.Length);
            writer.Write(nameBytes);

            byte[] versionBytes = Encoding.UTF8.GetBytes(this.version);
            writer.Write((byte)versionBytes.Length);
            writer.Write(versionBytes);

            for (int i = 0; i < NUM_GPIOS; i++) {
                byte[] gpioBytes = Encoding.UTF8.GetBytes(gpioNames[i].Name ?? "");
                byte lengthByte = (byte)(gpioBytes.Length & 0x1F);
                lengthByte |= (byte)gpioNames[i].Type;
                writer.Write(lengthByte);
                writer.Write(gpioBytes);
            }
        }

        public string PlankName
        {
            get
            {
                return this.plankName;
            }
            set
            {
                this.plankName = value;
                NotifyPropertyChanged();
            }
        }

        public string Version {
            get {
                return this.version;
            }
            set {
                this.version = value;
            }
        }

        public string FullName {
            get {
                return this.plankName + " " + this.version;
            }
        }

        public UInt16 MakerId
        {
            get
            {
                return this.makerId;
            }
            set
            {
                this.makerId = value;
                NotifyPropertyChanged();
            }
        }

        public UInt16 PlankId
        {
            get
            {
                return this.plankId;
            }
            set
            {
                this.plankId = value;
                NotifyPropertyChanged();
            }
        }

        public string FullPlankId
        {
            get
            {
                return String.Format("[{0:X}, {1:X}]", this.MakerId, this.PlankId);
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
            this.PlankName = backup.PlankName;
            this.Version = backup.Version;
            this.MakerId = backup.MakerId;
            this.PlankId = backup.PlankId;
            backup = null;
        }

        public void EndEdit()
        {
            backup = null;
        }

        public override string ToString()
        {
            return this.FullName;
        }
    }
}
