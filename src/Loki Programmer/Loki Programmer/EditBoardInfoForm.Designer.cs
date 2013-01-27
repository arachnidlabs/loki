namespace LokiProgrammer
{
    partial class EditBoardInfoForm
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditBoardInfoForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.configuredCheck = new System.Windows.Forms.CheckBox();
            this.isHostCheck = new System.Windows.Forms.CheckBox();
            this.topPlankCheck = new System.Windows.Forms.CheckBox();
            this.suppliesVinCheck = new System.Windows.Forms.CheckBox();
            this.supplies5VCheck = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.serialText = new System.Windows.Forms.TextBox();
            this.refreshSerial = new System.Windows.Forms.Button();
            this.shortNameText = new System.Windows.Forms.TextBox();
            this.nameText = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.productIdText = new System.Windows.Forms.TextBox();
            this.refreshProductId = new System.Windows.Forms.Button();
            this.urlText = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.gPIONamesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.boardInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pinNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gPIONamesBindingSource)).BeginInit();
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 38);
            label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(63, 13);
            label2.TabIndex = 1;
            label2.Text = "Short Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(3, 102);
            label3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(58, 13);
            label3.TabIndex = 2;
            label3.Text = "Product ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(3, 134);
            label4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(33, 13);
            label4.TabIndex = 3;
            label4.Text = "Serial";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(3, 166);
            label5.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(32, 13);
            label5.TabIndex = 4;
            label5.Text = "Flags";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(3, 291);
            label6.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(27, 13);
            label6.TabIndex = 5;
            label6.Text = "Pins";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(3, 70);
            label7.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(29, 13);
            label7.TabIndex = 11;
            label7.Text = "URL";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(label7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel4, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.shortNameText, 1, 1);
            this.tableLayoutPanel1.Controls.Add(label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(label5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(label6, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.nameText, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.urlText, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(331, 433);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.configuredCheck);
            this.flowLayoutPanel4.Controls.Add(this.isHostCheck);
            this.flowLayoutPanel4.Controls.Add(this.topPlankCheck);
            this.flowLayoutPanel4.Controls.Add(this.suppliesVinCheck);
            this.flowLayoutPanel4.Controls.Add(this.supplies5VCheck);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(72, 163);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(256, 119);
            this.flowLayoutPanel4.TabIndex = 10;
            // 
            // configuredCheck
            // 
            this.configuredCheck.AutoSize = true;
            this.configuredCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.boardInfoBindingSource, "IsConfigured", true));
            this.configuredCheck.Location = new System.Drawing.Point(3, 3);
            this.configuredCheck.Name = "configuredCheck";
            this.configuredCheck.Size = new System.Drawing.Size(77, 17);
            this.configuredCheck.TabIndex = 0;
            this.configuredCheck.Text = "Configured";
            this.configuredCheck.UseVisualStyleBackColor = true;
            // 
            // isHostCheck
            // 
            this.isHostCheck.AutoSize = true;
            this.isHostCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.boardInfoBindingSource, "IsHost", true));
            this.isHostCheck.Location = new System.Drawing.Point(3, 26);
            this.isHostCheck.Name = "isHostCheck";
            this.isHostCheck.Size = new System.Drawing.Size(48, 17);
            this.isHostCheck.TabIndex = 1;
            this.isHostCheck.Text = "Host";
            this.isHostCheck.UseVisualStyleBackColor = true;
            // 
            // topPlankCheck
            // 
            this.topPlankCheck.AutoSize = true;
            this.topPlankCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.boardInfoBindingSource, "IsTopPlank", true));
            this.topPlankCheck.Location = new System.Drawing.Point(3, 49);
            this.topPlankCheck.Name = "topPlankCheck";
            this.topPlankCheck.Size = new System.Drawing.Size(75, 17);
            this.topPlankCheck.TabIndex = 2;
            this.topPlankCheck.Text = "Top Plank";
            this.topPlankCheck.UseVisualStyleBackColor = true;
            // 
            // suppliesVinCheck
            // 
            this.suppliesVinCheck.AutoSize = true;
            this.suppliesVinCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.boardInfoBindingSource, "SuppliesVIN", true));
            this.suppliesVinCheck.Location = new System.Drawing.Point(3, 72);
            this.suppliesVinCheck.Name = "suppliesVinCheck";
            this.suppliesVinCheck.Size = new System.Drawing.Size(87, 17);
            this.suppliesVinCheck.TabIndex = 3;
            this.suppliesVinCheck.Text = "Supplies VIN";
            this.suppliesVinCheck.UseVisualStyleBackColor = true;
            // 
            // supplies5VCheck
            // 
            this.supplies5VCheck.AutoSize = true;
            this.supplies5VCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.boardInfoBindingSource, "Supplies5V", true));
            this.supplies5VCheck.Location = new System.Drawing.Point(3, 95);
            this.supplies5VCheck.Name = "supplies5VCheck";
            this.supplies5VCheck.Size = new System.Drawing.Size(88, 17);
            this.supplies5VCheck.TabIndex = 4;
            this.supplies5VCheck.Text = "Supplies +5V";
            this.supplies5VCheck.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.serialText);
            this.flowLayoutPanel3.Controls.Add(this.refreshSerial);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(72, 131);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(256, 26);
            this.flowLayoutPanel3.TabIndex = 9;
            // 
            // serialText
            // 
            this.serialText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.boardInfoBindingSource, "Serial", true));
            this.serialText.Location = new System.Drawing.Point(3, 3);
            this.serialText.Name = "serialText";
            this.serialText.Size = new System.Drawing.Size(220, 20);
            this.serialText.TabIndex = 8;
            // 
            // refreshSerial
            // 
            this.refreshSerial.AutoSize = true;
            this.refreshSerial.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.refreshSerial.Image = ((System.Drawing.Image)(resources.GetObject("refreshSerial.Image")));
            this.refreshSerial.Location = new System.Drawing.Point(229, 3);
            this.refreshSerial.Name = "refreshSerial";
            this.refreshSerial.Size = new System.Drawing.Size(22, 22);
            this.refreshSerial.TabIndex = 9;
            this.refreshSerial.UseVisualStyleBackColor = true;
            this.refreshSerial.Click += new System.EventHandler(this.refreshSerial_Click);
            // 
            // shortNameText
            // 
            this.shortNameText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.boardInfoBindingSource, "ShortName", true));
            this.shortNameText.Location = new System.Drawing.Point(72, 35);
            this.shortNameText.Name = "shortNameText";
            this.shortNameText.Size = new System.Drawing.Size(251, 20);
            this.shortNameText.TabIndex = 7;
            // 
            // nameText
            // 
            this.nameText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.boardInfoBindingSource, "ProductName", true));
            this.nameText.Location = new System.Drawing.Point(72, 3);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(251, 20);
            this.nameText.TabIndex = 6;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.productIdText);
            this.flowLayoutPanel2.Controls.Add(this.refreshProductId);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(72, 99);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(256, 26);
            this.flowLayoutPanel2.TabIndex = 8;
            // 
            // productIdText
            // 
            this.productIdText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.boardInfoBindingSource, "ProductId", true));
            this.productIdText.Location = new System.Drawing.Point(3, 3);
            this.productIdText.Name = "productIdText";
            this.productIdText.Size = new System.Drawing.Size(220, 20);
            this.productIdText.TabIndex = 7;
            // 
            // refreshProductId
            // 
            this.refreshProductId.AutoSize = true;
            this.refreshProductId.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.refreshProductId.Image = ((System.Drawing.Image)(resources.GetObject("refreshProductId.Image")));
            this.refreshProductId.Location = new System.Drawing.Point(229, 3);
            this.refreshProductId.Name = "refreshProductId";
            this.refreshProductId.Size = new System.Drawing.Size(22, 22);
            this.refreshProductId.TabIndex = 8;
            this.refreshProductId.UseVisualStyleBackColor = true;
            this.refreshProductId.Click += new System.EventHandler(this.refreshProductId_Click);
            // 
            // urlText
            // 
            this.urlText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.boardInfoBindingSource, "ProductURL", true));
            this.urlText.Location = new System.Drawing.Point(72, 67);
            this.urlText.Name = "urlText";
            this.urlText.Size = new System.Drawing.Size(251, 20);
            this.urlText.TabIndex = 12;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pinNumberDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.gPIONamesBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(72, 288);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(256, 150);
            this.dataGridView1.TabIndex = 13;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.okButton);
            this.flowLayoutPanel1.Controls.Add(this.cancelButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 433);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(331, 29);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(253, 3);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(172, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // gPIONamesBindingSource
            // 
            this.gPIONamesBindingSource.DataMember = "GPIONames";
            this.gPIONamesBindingSource.DataSource = this.boardInfoBindingSource;
            // 
            // boardInfoBindingSource
            // 
            this.boardInfoBindingSource.DataSource = typeof(LokiProgrammer.BoardInfo);
            // 
            // pinNumberDataGridViewTextBoxColumn
            // 
            this.pinNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.pinNumberDataGridViewTextBoxColumn.DataPropertyName = "PinNumber";
            this.pinNumberDataGridViewTextBoxColumn.HeaderText = "Pin";
            this.pinNumberDataGridViewTextBoxColumn.Name = "pinNumberDataGridViewTextBoxColumn";
            this.pinNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.pinNumberDataGridViewTextBoxColumn.Width = 47;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // EditBoardInfoForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(331, 462);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "EditBoardInfoForm";
            this.Text = "EditBoardInfoForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gPIONamesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardInfoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.CheckBox configuredCheck;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.TextBox serialText;
        private System.Windows.Forms.Button refreshSerial;
        private System.Windows.Forms.TextBox shortNameText;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox productIdText;
        private System.Windows.Forms.Button refreshProductId;
        private System.Windows.Forms.CheckBox isHostCheck;
        private System.Windows.Forms.CheckBox topPlankCheck;
        private System.Windows.Forms.CheckBox suppliesVinCheck;
        private System.Windows.Forms.CheckBox supplies5VCheck;
        private System.Windows.Forms.BindingSource boardInfoBindingSource;
        private System.Windows.Forms.TextBox urlText;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pinNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource gPIONamesBindingSource;

    }
}