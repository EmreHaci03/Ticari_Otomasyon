using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class NotDetay : Form
    {
        public NotDetay()
        {
            InitializeComponent();
        }
        public string not;
        private void NotDetay_Load(object sender, EventArgs e)
        {
            labelControl1.Text = not;
        }
    }
}
