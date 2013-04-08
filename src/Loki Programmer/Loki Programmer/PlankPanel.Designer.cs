namespace LokiProgrammer
{
    partial class PlankPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label3;
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.nameLabel = new System.Windows.Forms.LinkLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.topPlankCheck = new System.Windows.Forms.CheckBox();
            this.vinCheck = new System.Windows.Forms.CheckBox();
            this.fiveVoltCheck = new System.Windows.Forms.CheckBox();
            this.productIdLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pinMapBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.boardInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hostPinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plankPinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label1 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pinMapBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 6);
            label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(35, 13);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(3, 70);
            label5.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(32, 13);
            label5.TabIndex = 4;
            label5.Text = "Flags";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(3, 134);
            label6.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(66, 13);
            label6.TabIndex = 5;
            label6.Text = "Pin Mapping";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nameLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.productIdLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(373, 352);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.boardInfoBindingSource, "FullName", true));
            this.nameLabel.Location = new System.Drawing.Point(103, 6);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(55, 13);
            this.nameLabel.TabIndex = 12;
            this.nameLabel.TabStop = true;
            this.nameLabel.Text = "linkLabel1";
            this.nameLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.nameLabel_LinkClicked);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.topPlankCheck);
            this.flowLayoutPanel1.Controls.Add(this.vinCheck);
            this.flowLayoutPanel1.Controls.Add(this.fiveVoltCheck);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(103, 67);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(267, 58);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // topPlankCheck
            // 
            this.topPlankCheck.AutoCheck = false;
            this.topPlankCheck.AutoSize = true;
            this.topPlankCheck.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.boardInfoBindingSource, "IsTopPlank", true));
            this.topPlankCheck.Enabled = false;
            this.topPlankCheck.Location = new System.Drawing.Point(3, 3);
            this.topPlankCheck.Name = "topPlankCheck";
            this.topPlankCheck.Size = new System.Drawing.Size(75, 17);
            this.topPlankCheck.TabIndex = 0;
            this.topPlankCheck.Text = "Top Plank";
            this.topPlankCheck.UseVisualStyleBackColor = true;
            // 
            // vinCheck
            // 
            this.vinCheck.AutoCheck = false;
            this.vinCheck.AutoSize = true;
            this.vinCheck.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.boardInfoBindingSource, "SuppliesVIN", true));
            this.vinCheck.Enabled = false;
            this.vinCheck.Location = new System.Drawing.Point(3, 26);
            this.vinCheck.Name = "vinCheck";
            this.vinCheck.Size = new System.Drawing.Size(87, 17);
            this.vinCheck.TabIndex = 1;
            this.vinCheck.Text = "Supplies VIN";
            this.vinCheck.UseVisualStyleBackColor = true;
            // 
            // fiveVoltCheck
            // 
            this.fiveVoltCheck.AutoCheck = false;
            this.fiveVoltCheck.AutoSize = true;
            this.fiveVoltCheck.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.boardInfoBindingSource, "Supplies5V", true));
            this.fiveVoltCheck.Enabled = false;
            this.fiveVoltCheck.Location = new System.Drawing.Point(96, 3);
            this.fiveVoltCheck.Name = "fiveVoltCheck";
            this.fiveVoltCheck.Size = new System.Drawing.Size(88, 17);
            this.fiveVoltCheck.TabIndex = 2;
            this.fiveVoltCheck.Text = "Supplies +5V";
            this.fiveVoltCheck.UseVisualStyleBackColor = true;
            // 
            // productIdLabel
            // 
            this.productIdLabel.AutoSize = true;
            this.productIdLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.boardInfoBindingSource, "FullPlankId", true));
            this.productIdLabel.Location = new System.Drawing.Point(103, 38);
            this.productIdLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.productIdLabel.Name = "productIdLabel";
            this.productIdLabel.Size = new System.Drawing.Size(35, 13);
            this.productIdLabel.TabIndex = 14;
            this.productIdLabel.Text = "label2";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hostPinDataGridViewTextBoxColumn,
            this.plankPinDataGridViewTextBoxColumn,
            this.Type});
            this.dataGridView1.DataSource = this.pinMapBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(103, 131);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(267, 218);
            this.dataGridView1.TabIndex = 16;
            // 
            // pinMapBindingSource
            // 
            this.pinMapBindingSource.DataMember = "PinMap";
            this.pinMapBindingSource.DataSource = this.boardInfoBindingSource;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(3, 38);
            label3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(48, 13);
            label3.TabIndex = 2;
            label3.Text = "Plank ID";
            // 
            // boardInfoBindingSource
            // 
            this.boardInfoBindingSource.DataSource = typeof(LokiProgrammer.BoardInfo);
            // 
            // hostPinDataGridViewTextBoxColumn
            // 
            this.hostPinDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.hostPinDataGridViewTextBoxColumn.DataPropertyName = "HostPin";
            this.hostPinDataGridViewTextBoxColumn.HeaderText = "HostPin";
            this.hostPinDataGridViewTextBoxColumn.Name = "hostPinDataGridViewTextBoxColumn";
            this.hostPinDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // plankPinDataGridViewTextBoxColumn
            // 
            this.plankPinDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.plankPinDataGridViewTextBoxColumn.DataPropertyName = "PlankPin";
            this.plankPinDataGridViewTextBoxColumn.HeaderText = "PlankPin";
            this.plankPinDataGridViewTextBoxColumn.Name = "plankPinDataGridViewTextBoxColumn";
            this.plankPinDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 56;
            // 
            // PlankPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PlankPanel";
            this.Size = new System.Drawing.Size(373, 352);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pinMapBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox topPlankCheck;
        private System.Windows.Forms.CheckBox vinCheck;
        private System.Windows.Forms.CheckBox fiveVoltCheck;
        private System.Windows.Forms.LinkLabel nameLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label productIdLabel;
        private System.Windows.Forms.BindingSource boardInfoBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource pinMapBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn hostPinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn plankPinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
    }
}
