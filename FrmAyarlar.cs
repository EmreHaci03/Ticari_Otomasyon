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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();

        void Kullanicilistele()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT *FROM TBL_ADMIN",bgl.baglanti());
            DataTable dt = new DataTable(); 
            adapter.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void kullanicikaydet()
        {
            SqlCommand cmd = new SqlCommand("insert into TBL_ADMIN VALUES(@p1,@p2)",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",txtkullaniciad.Text);
            cmd.Parameters.AddWithValue("@p2", txtsifre.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kullanıcı Kaydı Yapıldı","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Question);
            Kullanicilistele();
            

        }
        void sifreguncelle()
        {
            SqlCommand cmd = new SqlCommand("UPDATE TBL_ADMIN SET Sifre=@p2 WHERE KullaniciAd=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",txtkullaniciad.Text);
            cmd.Parameters.AddWithValue("@p2",txtsifre.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            Kullanicilistele();
            MessageBox.Show("Güncelleme Islemi Başarılı", "Güncelleme",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            Kullanicilistele();
            txtkullaniciad.Text = "";
            txtsifre.Text = "";
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {

                switch (e.RowHandle % 3)
                {
                    case 0:
                        e.Appearance.BackColor = Color.LightGreen;
                        e.Appearance.BackColor2 = Color.White;
                        break;
                    case 1:
                        e.Appearance.BackColor = Color.LightBlue;
                        e.Appearance.BackColor2 = Color.White;
                        break;
                    case 2:
                        e.Appearance.BackColor = Color.LightCoral;
                        e.Appearance.BackColor2 = Color.White;
                        break;
                }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (row != null)
            {
                txtkullaniciad.Text = row["KullaniciAd"].ToString();
                txtsifre.Text = row["Sifre"].ToString();
            }
            
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (BtnIslem.Text == "Kaydet")
            {
                kullanicikaydet();
            }
            if (BtnIslem.Text == "Güncelle")
            {
                sifreguncelle();
            }
        }

        private void txtkullaniciad_TextChanged(object sender, EventArgs e)
        {
            if (txtkullaniciad.Text!="")
            {
                BtnIslem.Text = "Güncelle";
                BtnIslem.BackColor = Color.LightSeaGreen;
            }
            else
            {
                BtnIslem.Text = "Kaydet";
                BtnIslem.BackColor = Color.MediumTurquoise;

            }
        }
    }
}
