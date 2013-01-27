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

            this.serialText.DataBindings["Text"].Parse += GuidControl_Parse;
            this.productIdText.DataBindings["Text"].Parse += GuidControl_Parse;
        }

        void GuidControl_Parse(object sender, ConvertEventArgs e)
        {
            e.Value = new Guid(e.Value.ToString());
        }

        private void refreshProductId_Click(object sender, EventArgs e)
        {
            this.boardInfo.ProductId = Guid.NewGuid();
        }

        private void refreshSerial_Click(object sender, EventArgs e)
        {
            this.boardInfo.Serial = Guid.NewGuid();
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
