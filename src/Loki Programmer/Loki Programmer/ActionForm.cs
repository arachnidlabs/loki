using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LokiProgrammer
{
    public partial class ActionForm : Form
    {
        private FreebooterHost host;
        private FreebooterHost.Actions action;
        private Stream file;
        private String actionName;

        public ActionForm(FreebooterHost host, FreebooterHost.Actions action, Stream file)
        {
            this.host = host;
            this.action = action;
            this.file = file;
            InitializeComponent();
        }

        private void ActionForm_Load(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case FreebooterHost.Actions.PROGRAM:
                    actionName = "Programming";
                    break;
                case FreebooterHost.Actions.VERIFY:
                    actionName = "Verifying";
                    break;
                case FreebooterHost.Actions.ERASE:
                    actionName = "Erasing";
                    break;
            }
            progressLabel.Text = actionName + "...";
            this.Text = actionName + " device";
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
        }

        BackgroundWorker worker = null;
        bool success = false;

        public bool Success
        {
            get { return success; }
        }

        private void ActionForm_Shown(object sender, EventArgs e)
        {
            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Operation Cancelled", "Bootloader Operation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            } else if (e.Error != null)
            {
                if (e.Error is InvalidRowException)
                {
                    MessageBox.Show("Attempted to write to an invalid location in flash. Check to make sure this firmware was built against the correct bootloader version.", "Bootloader Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (e.Error is CommunicationsError)
                {
                    MessageBox.Show("A communications error was encountered while talking to the bootloader. Try restarting the device and trying again.", "Bootloader Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error occurred communicating with bootloader: " + e.Error.ToString(), "Bootloader Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                success = true;
            }
            worker = null;
            this.Close();
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Tuple<byte, ushort> args = (Tuple<byte, ushort>)e.UserState;
            progressLabel.Text = String.Format("{0} array {1}, row {2}", actionName, args.Item1, args.Item2);
            progressBar1.Value = e.ProgressPercentage;
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            host.Progress += host_Progress;
            try
            {
                host.DoAction(action, file);
            }
            finally
            {
                host.Progress -= host_Progress;
            }
        }

        void host_Progress(int percent, byte arrayID, ushort rowNum)
        {
            if (worker.CancellationPending)
            {
                host.Abort();
            }
            else
            {
                worker.ReportProgress(percent, Tuple.Create<byte, ushort>(arrayID, rowNum));
            }
        }

        private void abortButton_Click(object sender, EventArgs e)
        {
            if(worker != null && worker.IsBusy)
                worker.CancelAsync();
        }

        private void ActionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(worker != null && worker.IsBusy)
                worker.CancelAsync();
        }
    }
}
