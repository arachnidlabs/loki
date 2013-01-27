using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LokiProgrammer
{
    public class LokiInfo : BoardInfo
    {
        protected LokiBootloaderHost host;
        protected HIDCommunicationsChannel channel;
        protected ObservableCollection<BoardInfo> planks = new ObservableCollection<BoardInfo>();

        public LokiInfo(LokiBootloaderHost host, HIDCommunicationsChannel channel, byte address) : base(address) {
            this.host = host;
            this.channel = channel;
            WatchPlanks();
        }

        public LokiInfo(LokiBootloaderHost host, HIDCommunicationsChannel channel, Stream stream, byte address) : base(stream, address) {
            this.host = host;
            this.channel = channel;
            WatchPlanks();
        }

        private void WatchPlanks()
        {
            this.planks.CollectionChanged += planks_CollectionChanged;
        }

        void planks_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("Planks");

            // Watch all the pins on new planks
            foreach (Object plank in e.NewItems)
            {
                ((BoardInfo)plank).GPIONames.CollectionChanged += GPIONames_CollectionChanged;

                foreach(PinInfo pin in ((BoardInfo)plank).GPIONames)
                    pin.PropertyChanged += pin_PropertyChanged;
            }
            ComputePinMapping();
        }

        void GPIONames_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach (Object pin in e.NewItems)
                ((PinInfo)pin).PropertyChanged += pin_PropertyChanged;
            ComputePinMapping();
        }

        void pin_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ComputePinMapping();
        }

        public uint SiliconId
        {
            get
            {
                return this.host.SiliconId;
            }
        }

        public uint SiliconRev
        {
            get
            {
                return this.host.SiliconRev;
            }
        }

        public uint BootloaderVersion
        {
            get
            {
                return this.host.BootloaderVersion;
            }
        }

        public string SiliconVersion
        {
            get
            {
                return string.Format("{0:X}.{1:X}", this.SiliconId, this.SiliconRev);
            }
        }

        public string USBDeviceName
        {
            get
            {
                return string.Format("{0} {1} [{2:X}, {3:X}]", this.channel.Device.Manufacturer, this.channel.Device.Product, this.channel.Device.VendorID, this.channel.Device.ProductID);
            }
        }

        public ObservableCollection<BoardInfo> Planks
        {
            get
            {
                return this.planks;
            }
        }

        public void ComputePinMapping()
        {
            this.pinMap.Clear();

            List<string> bankA = new List<string>();
            for (int i = 0; i < 16; i++)
                bankA.Add(this.GPIONames[i].Name);

            List<string> bankB = new List<string>();
            for (int i = 16; i < 32; i++)
                bankB.Add(this.GPIONames[i].Name);

            foreach (BoardInfo plank in this.planks)
            {
                if (!plank.IsConfigured)
                    continue;

                List<int> usedPins = new List<int>();
                plank.PinMap.Clear();
                for (int i = 0; i < plank.GPIONames.Count; i++)
                {
                    if (plank.GPIONames[i].Name != "")
                    {
                        string lokiPin;
                        if (i < 16 && i < bankA.Count)
                        {
                            lokiPin = bankA[i];
                        }
                        else if (i < 32 && i - 16 < bankB.Count)
                        {
                            lokiPin = bankB[i - 16];
                        }
                        else
                        {
                            lokiPin = "N/C";
                        }
                        usedPins.Add(i);

                        PinMapping mapping = new PinMapping(lokiPin, plank, plank.GPIONames[i].Name);
                        plank.PinMap.Add(mapping);
                        this.pinMap.Add(mapping);
                    }
                }

                // Delete used pins
                for (int i = plank.GPIONames.Count - 1; i >= 0; i--)
                {
                    if (usedPins.Contains(i))
                    {
                        if (i < bankA.Count)
                        {
                            bankA.RemoveAt(i);
                        }
                        else if (i > 16 && i - 16 < bankB.Count)
                        {
                            bankB.RemoveAt(i - 16);
                        }
                    }
                }
            }
        }
    }
}
