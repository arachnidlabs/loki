using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CyUSB;
using System.Runtime.InteropServices;
using System.IO;

namespace LokiProgrammer
{
    public partial class MainForm : Form
    {
        private const int VID = 0x04B4;
        private const int PID = 0xB71D;

        HIDCommunicationsChannel channel;
        LokiBootloaderHost host;
        USBDeviceList usbHIDDevices = null;
        LokiInfo loki;

        /// Bootload action to perform 
        private enum CyBootloadAction
        {
            PROGRAM,
            ERASE,
            VERIFY,
        }

        /// <summary>
        /// The main Form
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            //
            usbHIDDevices = new USBDeviceList(CyConst.DEVICES_HID);

            //Adding event handlers for device attachment and device removal            
            usbHIDDevices.DeviceAttached += new EventHandler(usbHIDDevices_DeviceAttached);
            usbHIDDevices.DeviceRemoved += new EventHandler(usbHIDDevices_DeviceRemoved);
            GetHidDevice();
        }

        public void GetHidDevice()
        {
            CyHidDevice device = usbHIDDevices[VID, PID] as CyHidDevice;

            if (device != null)
            {
                channel = new HIDCommunicationsChannel(device);
                host = new LokiBootloaderHost(channel);
                host.EnterBootloader();
                this.UseWaitCursor = true;
                readEEPROMWorker.RunWorkerAsync();
            }
            else
            {
                OnDetach();
            }
        }

        private void OnDetach()
        {
            if (deviceNode != null)
                mainTreeView.Nodes.Remove(deviceNode);
            deviceNode = null;
            SelectionChanged();
        }

        private TreeNode deviceNode = null;

        private void OnAttach()
        {
            loki = host.GetLokiInfo();
            loki.PropertyChanged += loki_PropertyChanged;

            foreach (BoardInfo plank in host.GetPlankInfo())
            {
                loki.Planks.Add(plank);
                plank.PropertyChanged += plank_PropertyChanged;
            }
        }

        void loki_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "ProductName")
                return;

            deviceNode.Name = loki.ProductName;
        }

        void plank_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "ProductName")
                return;

            foreach (TreeNode plankNode in deviceNode.Nodes)
            {
                if (plankNode.Tag == sender)
                {
                    plankNode.Name = ((BoardInfo)sender).ProductName;
                }
            }
        }

        void usbHIDDevices_DeviceRemoved(object sender, EventArgs e)
        {
            OnDetach();
        }

        void usbHIDDevices_DeviceAttached(object sender, EventArgs e)
        {
            GetHidDevice();
        }

        private String ChooseFile()
        {
 
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("No file chosen");
                return null;
            }
        }

        private void programButton_Click(object sender, EventArgs e)
        {
            String filename = this.ChooseFile();

            if (filename != null)
            {
                ActionForm af = new ActionForm(this.host, FreebooterHost.Actions.PROGRAM, new FileStream(filename, FileMode.Open, FileAccess.Read));
                af.ShowDialog();
                if(af.Success)
                    MessageBox.Show("Bootloading completed successfully.");
            }
        }

        private void mainTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectionChanged();
        }

        private void SelectionChanged()
        {
            TreeNode node = mainTreeView.SelectedNode;
            if (node == this.deviceNode && this.deviceNode != null)
            {
                programButton.Enabled = true;
                verifyButton.Enabled = true;
                eraseButton.Enabled = true;
                exitBootloaderButton.Enabled = true;
            }
            else
            {
                programButton.Enabled = false;
                verifyButton.Enabled = false;
                eraseButton.Enabled = false;
                exitBootloaderButton.Enabled = true;
            }

            splitContainer1.Panel2.Controls.Clear();
            UserControl mainPanel = null;
            if(node == null) {
                mainPanel = new NullPanel();
            }
            else if (node == this.deviceNode)
            {
                mainPanel = new LokiPanel((LokiInfo)node.Tag);
            }
            else
            {
                mainPanel = new PlankPanel((BoardInfo)node.Tag);
            }
            mainPanel.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(mainPanel);
        }

        private void verifyButton_Click(object sender, EventArgs e)
        {
            String filename = this.ChooseFile();

            if (filename != null)
            {
                ActionForm af = new ActionForm(this.host, FreebooterHost.Actions.VERIFY, new FileStream(filename, FileMode.Open, FileAccess.Read));
                af.ShowDialog();
                if(af.Success)
                    MessageBox.Show("Flash verification succeeded.");
            }
        }

        private void eraseButton_Click(object sender, EventArgs e)
        {
            String filename = this.ChooseFile();

            if (filename != null)
            {
                ActionForm af = new ActionForm(this.host, FreebooterHost.Actions.ERASE, new FileStream(filename, FileMode.Open, FileAccess.Read));
                af.ShowDialog();
                if(af.Success)
                    MessageBox.Show("Device Erased");
            }
        }

        private void exitBootloaderButton_Click(object sender, EventArgs e)
        {
            this.host.ExitBootloader();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        }

        private BoardInfo editNode = null;
        private void mainTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            editNode = e.Node.Tag as BoardInfo;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                boardContextMenu.Show(mainTreeView, e.Location);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditBoardInfoForm form = new EditBoardInfoForm(editNode);
            form.ShowDialog();
            if (form.Success)
            {
                this.UseWaitCursor = true;
                writeEEPROMWorker.RunWorkerAsync();
            }
        }

        private void readEEPROMWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            OnAttach();
        }

        private void readEEPROMWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            deviceNode = new TreeNode();
            if (loki.ProductName != "" && loki.ProductName != null)
            {
                deviceNode.Text = loki.ProductName;
            }
            else
            {
                deviceNode.Text = String.Format("{0} [{1:X}, {2:X}]", channel.Device.Product, channel.Device.VendorID, channel.Device.ProductID);
            }
            deviceNode.ImageKey = "Loki";
            deviceNode.SelectedImageKey = "Loki";
            deviceNode.Tag = loki;
            mainTreeView.Nodes.Add(deviceNode);

            foreach (BoardInfo plank in loki.Planks)
            {
                TreeNode plankNode = new TreeNode();
                plankNode.ImageKey = "Plank";
                plankNode.SelectedImageKey = "Plank";
                plankNode.Tag = plank;
                if (plank == null)
                {
                    plankNode.Text = "Unknown Plank";
                }
                else
                {
                    plankNode.Text = plank.ProductName;
                }
                deviceNode.Nodes.Add(plankNode);
            }

            deviceNode.Expand();
            mainTreeView.SelectedNode = deviceNode;

            this.UseWaitCursor = false;
        }

        private void writeEEPROMWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            editNode.Serialize(host.OpenEEPROM(editNode.Address, 65536));
        }

        private void writeEEPROMWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.UseWaitCursor = false;
            this.Cursor = Cursors.Arrow;
            MessageBox.Show("Successfully updated EEPROM", "Write complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
