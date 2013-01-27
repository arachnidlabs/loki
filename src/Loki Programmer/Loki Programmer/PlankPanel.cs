using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LokiProgrammer
{
    public partial class PlankPanel : UserControl
    {
        private BoardInfo board;

        public PlankPanel(BoardInfo board)
        {
            InitializeComponent();

            this.board = board;
            boardInfoBindingSource.DataSource = board;
        }

        private void nameLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                nameLabel.LinkVisited = true;
                System.Diagnostics.Process.Start(this.board.ProductURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open URL: " + ex.ToString(), "Error opening URL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
