using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl=new SqlBaglanti();

        
        private void FrmAdmin_Load(object sender, EventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT *FROM TBL_ADMIN WHERE KullaniciAd=@p1 AND Sifre=@p2", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", txtkullaniciad.Text);
            cmd.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                FrmAnaModul anaModul = new FrmAnaModul();
                anaModul.kullaniciad = txtkullaniciad.Text;
                anaModul.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı Ve Şifrenizi Yanlış Girdiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
