using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LokiProgrammer
{
    public partial class EditBoardInfoForm : Form
    {
        private BoardInfo boardInfo;
        private bool success;

        public EditBoardInfoForm(BoardInfo boardInfo)
        {
            InitializeComponent();
            this.boardInfo = boardInfo;
            this.boardInfoBindingSource.DataSource = boardInfo;
            this.makerIdText.DataBindings["Text"].Parse += HexStringParse;
            this.plankIdText.DataBindings["Text"].Parse += HexStringParse;
        }

        void HexStringParse(object sender, ConvertEventArgs e)
        {
            e.Value = UInt16.Parse(e.Value.ToString(), System.Globalization.NumberStyles.HexNumber);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.boardInfoBindingSource.EndEdit();
            this.success = true;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.boardInfoBindingSource.CancelEdit();
            this.success = false;
            this.Close();
        }

        public bool Success
        {
            get
            {
                return this.success;
            }
        }
    }
}
