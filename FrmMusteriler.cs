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
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        
        void musteriListele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_MUSTERILER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void ilListele()
        {
            SqlCommand cmd = new SqlCommand("SELECT SEHIR FROM TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CmbIL.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();

        }
        
        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            musteriListele();
            ilListele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            //Müşteri Kaydetme
            SqlCommand cmd = new SqlCommand("INSERT INTO TBL_MUSTERILER(AD,SOYAD,TELEFON,TELEFON2,TC,MAIL,IL,ILCE,ADRES,VERGIDAIRESI) VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", TxtAd.Text);
            cmd.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", MskTelefon.Text);
            cmd.Parameters.AddWithValue("@p4", MskTelefon2.Text);
            cmd.Parameters.AddWithValue("@p5", TxtTc.Text);
            cmd.Parameters.AddWithValue("@p6", TxtMail.Text);
            cmd.Parameters.AddWithValue("@p7", CmbIL.Text);
            cmd.Parameters.AddWithValue("@p8", CmbIlce.Text);
            cmd.Parameters.AddWithValue("@p9", RichAdres.Text);
            cmd.Parameters.AddWithValue("@p10", TxtVergiDairesi.Text);
            cmd.ExecuteNonQuery();
            musteriListele();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //////////////////


        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            //Müşteri Silme
            SqlCommand cmd = new SqlCommand("DELETE FROM TBL_MUSTERILER WHERE ID=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",TxtId.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            musteriListele();
            MessageBox.Show("Müşteri kaydı Başarıyla Silindi","Kayıt Silindi!!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            //////////////////
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            //Müşteri Güncelleme
            SqlCommand cmd = new SqlCommand("UPDATE TBL_MUSTERILER SET  AD=@p1,SOYAD=@p2,TELEFON=@p3,TELEFON2=@p4,TC=@p5,MAIL=@p6,IL=@p7,ILCE=@p8,ADRES=@p9,VERGIDAIRESI=@p10  WHERE ID=@p11 ", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",TxtAd.Text);
            cmd.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", MskTelefon.Text);
            cmd.Parameters.AddWithValue("@p4", MskTelefon2.Text);
            cmd.Parameters.AddWithValue("@p5", TxtTc.Text);
            cmd.Parameters.AddWithValue("@p6", TxtMail.Text);
            cmd.Parameters.AddWithValue("@p7", CmbIL.Text);
            cmd.Parameters.AddWithValue("@p8", CmbIlce.Text);
            cmd.Parameters.AddWithValue("@p9", RichAdres.Text);
            cmd.Parameters.AddWithValue("@p10",TxtVergiDairesi.Text);
            cmd.Parameters.AddWithValue("@p11",TxtId.Text);
            cmd.ExecuteNonQuery();
            musteriListele();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Güncellendi","Müşteri Güncelleme",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //////////////////
        }

        private void CmbIL_SelectedIndexChanged(object sender, EventArgs e)
        {
            //İle Göre Şehir Listeleme
            CmbIlce.Properties.Items.Clear();
            SqlCommand cmd = new SqlCommand("SELECT ILCE FROM TBL_ILCELER WHERE SEHIR=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",CmbIL.SelectedIndex+1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CmbIlce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
            CmbIlce.Text = "";


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

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtId.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            MskTelefon.Text = "";
            MskTelefon2.Text = "";
            TxtTc.Text = "";
            TxtMail.Text = "";
            CmbIL.Text = "";
            CmbIlce.Text = "";
            TxtVergiDairesi.Text = "";
            RichAdres.Text = "";
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (row != null)
            {
                TxtId.Text = row["ID"].ToString();
                TxtAd.Text = row["AD"].ToString();
                TxtSoyad.Text = row["SOYAD"].ToString();
                MskTelefon.Text = row["TELEFON"].ToString();
                MskTelefon2.Text = row["TELEFON2"].ToString();
                TxtTc.Text = row["TC"].ToString();
                TxtMail.Text = row["MAIL"].ToString();
                CmbIL.Text = row["IL"].ToString();
                CmbIlce.Text = row["ILCE"].ToString();
                RichAdres.Text = row["ADRES"].ToString();
                TxtVergiDairesi.Text = row["VERGIDAIRESI"].ToString();
            }
        }
    }
}
