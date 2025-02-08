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
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();

        void firmaListele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM TBL_FIRMALAR",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        void firmaTemizle()
        {
            TxtId.Text = "";
            TxtFirmaAd.Text = "";
            TxtGörev.Text = "";
            TxtYetkili.Text = "";
            MskTc.Text = "";
            TxtSektör.Text = "";
            MskTelefon2.Text = "";
            MskTelefon1.Text = "";
            TxtMail.Text = "";
            TxtFax.Text = "";
            CmbIL.Text = "";
            CmbIlce.Text = "";
            TxtVergiDairesi.Text = "";
            RichAdres.Text = "";
            TxtKod1.Text = "";
            TxtKod2.Text = "";
            TxtKod3.Text = "";
        }
        void ilListele()
        {

            SqlCommand cmd = new SqlCommand("SELECT *FROM TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CmbIL.Properties.Items.Add(dr[1]);
            }
        }
        void kodaciklamalar()
        {
            SqlCommand cmd = new SqlCommand("SELECT FIRMAKOD1 FROM TBL_KODLAR ",bgl.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                RchKod1.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();
        }

        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            firmaListele();
            ilListele();
            firmaTemizle();
            kodaciklamalar();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtId.Text = dr["ID"].ToString();
                TxtFirmaAd.Text = dr["FIRMAAD"].ToString();
                TxtGörev.Text = dr["YETKILIGOREV"].ToString();
                TxtYetkili.Text = dr["YETKILIADSOYAD"].ToString();
                MskTc.Text = dr["YETKILITC"].ToString();
                TxtSektör.Text = dr["SEKTOR"].ToString();
                MskTelefon1.Text = dr["FIRMATELEFON"].ToString();
                MskTelefon2.Text = dr["YETKILITELEFON"].ToString();
                TxtMail.Text = dr["MAIL"].ToString();
                TxtFax.Text = dr["FAX"].ToString();
                CmbIL.Text = dr["IL"].ToString();
                CmbIlce.Text = dr["ILCE"].ToString();
                TxtVergiDairesi.Text = dr["VERGIDAIRE"].ToString();
                RichAdres.Text = dr["ADRES"].ToString();
                TxtKod1.Text = dr["OZELKOD1"].ToString();
                TxtKod2.Text = dr["OZELKOD2"].ToString();
                TxtKod3.Text = dr["OZELKOD3"].ToString();
            }

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            //Firma Bilgilerini Kaydetme
            SqlCommand cmd = new SqlCommand("INSERT INTO TBL_FIRMALAR(FIRMAAD,YETKILIGOREV,YETKILIADSOYAD,YETKILITC,SEKTOR,YETKILITELEFON,FIRMATELEFON,MAIL,FAX,IL,ILCE,VERGIDAIRE,ADRES,OZELKOD1,OZELKOD2,OZELKOD3) VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16)",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", TxtFirmaAd.Text);
            cmd.Parameters.AddWithValue("@p2", TxtGörev.Text);
            cmd.Parameters.AddWithValue("@p3", TxtYetkili.Text);
            cmd.Parameters.AddWithValue("@p4", MskTc.Text);
            cmd.Parameters.AddWithValue("@p5", TxtSektör.Text);
            cmd.Parameters.AddWithValue("@p6", MskTelefon2.Text);
            cmd.Parameters.AddWithValue("@p7", MskTelefon1.Text);
            cmd.Parameters.AddWithValue("@p8", TxtMail.Text);
            cmd.Parameters.AddWithValue("@p9", TxtFax.Text);
            cmd.Parameters.AddWithValue("@p10",CmbIL.Text);
            cmd.Parameters.AddWithValue("@p11",CmbIlce.Text);
            cmd.Parameters.AddWithValue("@p12",TxtVergiDairesi.Text);
            cmd.Parameters.AddWithValue("@p13",RichAdres.Text);
            cmd.Parameters.AddWithValue("@p14",TxtKod1.Text);
            cmd.Parameters.AddWithValue("@p15",TxtKod2.Text);
            cmd.Parameters.AddWithValue("@p16",TxtKod3.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma kayıdı yapılmıştır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            firmaListele();

        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM TBL_FIRMALAR WHERE ID=@p1",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", TxtId.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Silme Işlemi başarıyla gerçekleştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            firmaListele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE TBL_FIRMALAR SET FIRMAAD=@p1,YETKILIGOREV=@p2,YETKILIADSOYAD=@p3,YETKILITC=@p4,SEKTOR=@p5,YETKILITELEFON=@p6,FIRMATELEFON=@p7,MAIL=@p8,FAX=@p9,IL=@p10,ILCE=@p11," +
                "VERGIDAIRE=@p12,ADRES=@p13,OZELKOD1=@p14,OZELKOD2=@p15,OZELKOD3=@p16",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", TxtFirmaAd.Text);
            cmd.Parameters.AddWithValue("@p2", TxtGörev.Text);
            cmd.Parameters.AddWithValue("@p3", TxtYetkili.Text);
            cmd.Parameters.AddWithValue("@p4", MskTc.Text);
            cmd.Parameters.AddWithValue("@p5", TxtSektör.Text);
            cmd.Parameters.AddWithValue("@p6", MskTelefon2.Text);
            cmd.Parameters.AddWithValue("@p7", MskTelefon1.Text);
            cmd.Parameters.AddWithValue("@p8", TxtMail.Text);
            cmd.Parameters.AddWithValue("@p9", TxtFax.Text);
            cmd.Parameters.AddWithValue("@p10", CmbIL.Text);
            cmd.Parameters.AddWithValue("@p11", CmbIlce.Text);
            cmd.Parameters.AddWithValue("@p12", TxtVergiDairesi.Text);
            cmd.Parameters.AddWithValue("@p13", RichAdres.Text);
            cmd.Parameters.AddWithValue("@p14", TxtKod1.Text);
            cmd.Parameters.AddWithValue("@p15", TxtKod2.Text);
            cmd.Parameters.AddWithValue("@p16", TxtKod3.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma güncellemesi yapılmıştır.", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            firmaListele();
            firmaTemizle();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            firmaTemizle();
        }

        private void CmbIL_SelectedIndexChanged(object sender, EventArgs e)
        {
            // İle Göre Şehir Listeleme
            CmbIlce.Properties.Items.Clear();

            SqlCommand cmd = new SqlCommand("SELECT ILCE FROM TBL_ILCELER WHERE SEHIR=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", CmbIL.SelectedIndex + 1);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                CmbIlce.Properties.Items.Add(dr[0].ToString()); 
            }
            bgl.baglanti().Close(); 


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
