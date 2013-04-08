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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.configuredCheck = new System.Windows.Forms.CheckBox();
            this.isHostCheck = new System.Windows.Forms.CheckBox();
            this.topPlankCheck = new System.Windows.Forms.CheckBox();
            this.suppliesVinCheck = new System.Windows.Forms.CheckBox();
            this.supplies5VCheck = new System.Windows.Forms.CheckBox();
            this.plankIdText = new System.Windows.Forms.TextBox();
            this.shortNameText = new System.Windows.Forms.TextBox();
            this.nameText = new System.Windows.Forms.TextBox();
            this.makerIdText = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gPIONamesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.IsInput = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsOutput = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsAnalog = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.boardInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pinNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gPIONamesBindingSource)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
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
            label2.Size = new System.Drawing.Size(42, 13);
            label2.TabIndex = 1;
            label2.Text = "Version";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(3, 70);
            label3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(51, 13);
            label3.TabIndex = 2;
            label3.Text = "Maker ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(3, 102);
            label4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(48, 13);
            label4.TabIndex = 3;
            label4.Text = "Plank ID";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(3, 134);
            label5.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(32, 13);
            label5.TabIndex = 4;
            label5.Text = "Flags";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(3, 209);
            label6.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(27, 13);
            label6.TabIndex = 5;
            label6.Text = "Pins";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.plankIdText, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.makerIdText, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.shortNameText, 1, 1);
            this.tableLayoutPanel1.Controls.Add(label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.nameText, 1, 0);
            this.tableLayoutPanel1.Controls.Add(label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel4, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
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
            this.flowLayoutPanel4.Location = new System.Drawing.Point(60, 131);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(268, 69);
            this.flowLayoutPanel4.TabIndex = 10;
            // 
            // configuredCheck
            // 
            this.configuredCheck.AutoSize = true;
            this.configuredCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.boardInfoBindingSource, "IsConfigured", true));
            this.configuredCheck.Location = new System.Drawing.Point(3, 3);
            this.configuredCheck.Name = "configuredCheck";
            this.configuredCheck.Size = new System.Drawing.Size(77, 17);
            this.configuredCheck.TabIndex = 5;
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
            this.isHostCheck.TabIndex = 7;
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
            this.topPlankCheck.TabIndex = 9;
            this.topPlankCheck.Text = "Top Plank";
            this.topPlankCheck.UseVisualStyleBackColor = true;
            // 
            // suppliesVinCheck
            // 
            this.suppliesVinCheck.AutoSize = true;
            this.suppliesVinCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.boardInfoBindingSource, "SuppliesVIN", true));
            this.suppliesVinCheck.Location = new System.Drawing.Point(86, 3);
            this.suppliesVinCheck.Name = "suppliesVinCheck";
            this.suppliesVinCheck.Size = new System.Drawing.Size(87, 17);
            this.suppliesVinCheck.TabIndex = 6;
            this.suppliesVinCheck.Text = "Supplies VIN";
            this.suppliesVinCheck.UseVisualStyleBackColor = true;
            // 
            // supplies5VCheck
            // 
            this.supplies5VCheck.AutoSize = true;
            this.supplies5VCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.boardInfoBindingSource, "Supplies5V", true));
            this.supplies5VCheck.Location = new System.Drawing.Point(86, 26);
            this.supplies5VCheck.Name = "supplies5VCheck";
            this.supplies5VCheck.Size = new System.Drawing.Size(88, 17);
            this.supplies5VCheck.TabIndex = 8;
            this.supplies5VCheck.Text = "Supplies +5V";
            this.supplies5VCheck.UseVisualStyleBackColor = true;
            // 
            // plankIdText
            // 
            this.plankIdText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.boardInfoBindingSource, "PlankId", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "X"));
            this.plankIdText.Location = new System.Drawing.Point(60, 99);
            this.plankIdText.Name = "plankIdText";
            this.plankIdText.Size = new System.Drawing.Size(100, 20);
            this.plankIdText.TabIndex = 4;
            // 
            // shortNameText
            // 
            this.shortNameText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.boardInfoBindingSource, "Version", true));
            this.shortNameText.Location = new System.Drawing.Point(60, 35);
            this.shortNameText.Name = "shortNameText";
            this.shortNameText.Size = new System.Drawing.Size(251, 20);
            this.shortNameText.TabIndex = 2;
            // 
            // nameText
            // 
            this.nameText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.boardInfoBindingSource, "PlankName", true));
            this.nameText.Location = new System.Drawing.Point(60, 3);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(251, 20);
            this.nameText.TabIndex = 1;
            // 
            // makerIdText
            // 
            this.makerIdText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.boardInfoBindingSource, "MakerId", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "X"));
            this.makerIdText.Location = new System.Drawing.Point(60, 67);
            this.makerIdText.Name = "makerIdText";
            this.makerIdText.Size = new System.Drawing.Size(100, 20);
            this.makerIdText.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pinNumberDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.IsInput,
            this.IsOutput,
            this.IsAnalog});
            this.dataGridView1.DataSource = this.gPIONamesBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(60, 206);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(268, 224);
            this.dataGridView1.TabIndex = 10;
            // 
            // gPIONamesBindingSource
            // 
            this.gPIONamesBindingSource.DataMember = "GPIONames";
            this.gPIONamesBindingSource.DataSource = this.boardInfoBindingSource;
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
            this.okButton.TabIndex = 11;
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
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // IsInput
            // 
            this.IsInput.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IsInput.DataPropertyName = "IsInput";
            this.IsInput.HeaderText = "Input";
            this.IsInput.Name = "IsInput";
            this.IsInput.Width = 37;
            // 
            // IsOutput
            // 
            this.IsOutput.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IsOutput.DataPropertyName = "IsOutput";
            this.IsOutput.HeaderText = "Output";
            this.IsOutput.Name = "IsOutput";
            this.IsOutput.Width = 45;
            // 
            // IsAnalog
            // 
            this.IsAnalog.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IsAnalog.DataPropertyName = "IsAnalog";
            this.IsAnalog.HeaderText = "Analog";
            this.IsAnalog.Name = "IsAnalog";
            this.IsAnalog.Width = 46;
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
            this.Text = "Edit Plank Info";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gPIONamesBindingSource)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox plankIdText;
        private System.Windows.Forms.TextBox shortNameText;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.TextBox makerIdText;
        private System.Windows.Forms.CheckBox isHostCheck;
        private System.Windows.Forms.CheckBox topPlankCheck;
        private System.Windows.Forms.CheckBox suppliesVinCheck;
        private System.Windows.Forms.CheckBox supplies5VCheck;
        private System.Windows.Forms.BindingSource boardInfoBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource gPIONamesBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn pinNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsInput;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsOutput;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsAnalog;

    }
}