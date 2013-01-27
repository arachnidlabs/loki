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
    public partial class LokiPanel : UserControl
    {
        private LokiInfo lokiInfo;

        public LokiPanel(LokiInfo lokiInfo)
        {
            InitializeComponent();
            this.lokiInfo = lokiInfo;
            boardInfoBindingSource.DataSource = lokiInfo;
        }
    }
}
