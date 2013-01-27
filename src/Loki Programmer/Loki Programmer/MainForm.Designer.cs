namespace LokiProgrammer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.mainTreeView = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.programButton = new System.Windows.Forms.ToolStripButton();
            this.verifyButton = new System.Windows.Forms.ToolStripButton();
            this.eraseButton = new System.Windows.Forms.ToolStripButton();
            this.exitBootloaderButton = new System.Windows.Forms.ToolStripButton();
            this.boardContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readEEPROMWorker = new System.ComponentModel.BackgroundWorker();
            this.writeEEPROMWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.boardContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "cyacd file|*.cyacd";
            this.openFileDialog1.Title = "Open CYACD File";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 39);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mainTreeView);
            this.splitContainer1.Size = new System.Drawing.Size(559, 365);
            this.splitContainer1.SplitterDistance = 186;
            this.splitContainer1.TabIndex = 1;
            // 
            // mainTreeView
            // 
            this.mainTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTreeView.ImageIndex = 0;
            this.mainTreeView.ImageList = this.imageList1;
            this.mainTreeView.Location = new System.Drawing.Point(0, 0);
            this.mainTreeView.Name = "mainTreeView";
            this.mainTreeView.SelectedImageIndex = 0;
            this.mainTreeView.Size = new System.Drawing.Size(186, 365);
            this.mainTreeView.TabIndex = 0;
            this.mainTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.mainTreeView_AfterSelect);
            this.mainTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.mainTreeView_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Loki");
            this.imageList1.Images.SetKeyName(1, "Plank");
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programButton,
            this.verifyButton,
            this.eraseButton,
            this.exitBootloaderButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(559, 39);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // programButton
            // 
            this.programButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.programButton.Enabled = false;
            this.programButton.Image = ((System.Drawing.Image)(resources.GetObject("programButton.Image")));
            this.programButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.programButton.Name = "programButton";
            this.programButton.Size = new System.Drawing.Size(36, 36);
            this.programButton.Text = "Program";
            this.programButton.Click += new System.EventHandler(this.programButton_Click);
            // 
            // verifyButton
            // 
            this.verifyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.verifyButton.Enabled = false;
            this.verifyButton.Image = ((System.Drawing.Image)(resources.GetObject("verifyButton.Image")));
            this.verifyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.verifyButton.Name = "verifyButton";
            this.verifyButton.Size = new System.Drawing.Size(36, 36);
            this.verifyButton.Text = "Verify";
            this.verifyButton.Click += new System.EventHandler(this.verifyButton_Click);
            // 
            // eraseButton
            // 
            this.eraseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.eraseButton.Enabled = false;
            this.eraseButton.Image = ((System.Drawing.Image)(resources.GetObject("eraseButton.Image")));
            this.eraseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.eraseButton.Name = "eraseButton";
            this.eraseButton.Size = new System.Drawing.Size(36, 36);
            this.eraseButton.Text = "Erase";
            this.eraseButton.Click += new System.EventHandler(this.eraseButton_Click);
            // 
            // exitBootloaderButton
            // 
            this.exitBootloaderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exitBootloaderButton.Enabled = false;
            this.exitBootloaderButton.Image = ((System.Drawing.Image)(resources.GetObject("exitBootloaderButton.Image")));
            this.exitBootloaderButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitBootloaderButton.Name = "exitBootloaderButton";
            this.exitBootloaderButton.Size = new System.Drawing.Size(36, 36);
            this.exitBootloaderButton.Text = "Exit Bootloader";
            this.exitBootloaderButton.Click += new System.EventHandler(this.exitBootloaderButton_Click);
            // 
            // boardContextMenu
            // 
            this.boardContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.boardContextMenu.Name = "boardContextMenu";
            this.boardContextMenu.Size = new System.Drawing.Size(95, 26);
            this.boardContextMenu.Text = "Edit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // readEEPROMWorker
            // 
            this.readEEPROMWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.readEEPROMWorker_DoWork);
            this.readEEPROMWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.readEEPROMWorker_RunWorkerCompleted);
            // 
            // writeEEPROMWorker
            // 
            this.writeEEPROMWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.writeEEPROMWorker_DoWork);
            this.writeEEPROMWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.writeEEPROMWorker_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 404);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.boardContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView mainTreeView;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton programButton;
        private System.Windows.Forms.ToolStripButton verifyButton;
        private System.Windows.Forms.ToolStripButton eraseButton;
        private System.Windows.Forms.ToolStripButton exitBootloaderButton;
        private System.Windows.Forms.ContextMenuStrip boardContextMenu;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker readEEPROMWorker;
        private System.ComponentModel.BackgroundWorker writeEEPROMWorker;
    }
}