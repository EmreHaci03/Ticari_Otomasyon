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
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        void personelListele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM TBL_PERSONELLER",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;


        }
        void ilListele()
        {

            SqlCommand cmd = new SqlCommand("SELECT *FROM TBL_ILLER",bgl.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CmbIL.Properties.Items.Add(dr[1]);
            }
        }
        void alanTemizle()
        {
            TxtId.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            MskTelefon.Text = "";
            MskTc.Text = "";
            TxtMail.Text = "";
            CmbIL.Text = "";
            CmbILCE.Text = "";
            TxtGorev.Text = "";
            RichAdres.Text = "";
        }
        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            personelListele();
            ilListele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            //Personel Ekleme
            SqlCommand cmd = new SqlCommand("INSERT INTO TBL_PERSONELLER(AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV) VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", TxtAd.Text);
            cmd.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", MskTelefon.Text);
            cmd.Parameters.AddWithValue("@p4", MskTc.Text);
            cmd.Parameters.AddWithValue("@p5", TxtMail.Text);
            cmd.Parameters.AddWithValue("@p6", CmbIL.Text);
            cmd.Parameters.AddWithValue("@p7", CmbILCE.Text);
            cmd.Parameters.AddWithValue("@p8", RichAdres.Text);
            cmd.Parameters.AddWithValue("@p9", TxtGorev.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            //////////////////
            MessageBox.Show("Personel Kayıdı Yapılmıştır", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            personelListele();
            alanTemizle();
        }

        private void CmbIL_SelectedIndexChanged(object sender, EventArgs e)
        {
            //İle Göre Şehir Listeleme
            CmbILCE.Properties.Items.Clear();

            SqlCommand cmd=new SqlCommand("SELECT ILCE FROM TBL_ILCELER WHERE SEHIR=@p1",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",CmbIL.SelectedIndex+1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {  
                CmbILCE.Properties.Items.Add(dr[0]);
                CmbILCE.Text = dr[0].ToString();
            }
            
            
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr!= null) {
                TxtId.Text = dr[0].ToString();
                TxtAd.Text = dr[1].ToString();
                TxtSoyad.Text = dr[2].ToString();
                MskTelefon.Text = dr[3].ToString();
                MskTc.Text = dr[4].ToString();
                TxtMail.Text = dr[5].ToString();
                CmbIL.Text = dr[6].ToString();
                CmbILCE.Text = dr[7].ToString();
                RichAdres.Text = dr[8].ToString();
                TxtGorev.Text= dr[9].ToString();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            alanTemizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            //Personel Silme
            SqlCommand cmd = new SqlCommand("DELETE FROM TBL_PERSONELLER WHERE ID=@p1",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",TxtId.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Silindi", "Bilgi", MessageBoxButtons.OK,MessageBoxIcon.None);
            personelListele();
            alanTemizle();
            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE TBL_PERSONELLER SET AD=@p1,SOYAD=@p2,TELEFON=@p3,TC=@p4,MAIL=@p5,IL=@p6,ILCE=@p7,ADRES=@p8,GOREV=@p9 WHERE ID=@p10",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", TxtAd.Text);
            cmd.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", MskTelefon.Text);
            cmd.Parameters.AddWithValue("@p4", MskTc.Text);
            cmd.Parameters.AddWithValue("@p5", TxtMail.Text);
            cmd.Parameters.AddWithValue("@p6", CmbIL.Text);
            cmd.Parameters.AddWithValue("@p7", CmbILCE.Text);
            cmd.Parameters.AddWithValue("@p8", RichAdres.Text);
            cmd.Parameters.AddWithValue("@p9", TxtGorev.Text);
            cmd.Parameters.AddWithValue("@p10", TxtId.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            //////////////////
            MessageBox.Show("Personel Silinmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.None);
            personelListele();
            alanTemizle();
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {

                switch (e.RowHandle % 3)
                {
                    case 0:
                        e.Appearance.BackColor = Color.LightBlue;
                        e.Appearance.BackColor2 = Color.White;
                        break;
                    case 1:
                        e.Appearance.BackColor = Color.LightGreen;
                        e.Appearance.BackColor2 = Color.White;
                        break;
                    case 2:
                        e.Appearance.BackColor = Color.LightCoral;
                        e.Appearance.BackColor2 = Color.White;
                        break;
                }
            }
        }
    }
}
