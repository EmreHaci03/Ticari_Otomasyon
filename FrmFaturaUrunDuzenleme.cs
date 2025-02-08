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
using DevExpress.XtraGrid;


namespace Ticari_Otomasyon
{
    public partial class FrmFaturaUrunDuzenleme : Form
    {
        public FrmFaturaUrunDuzenleme()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl=new SqlBaglanti();
        public string id;
        void listeleme()
        {
            SqlCommand cmd = new SqlCommand("SELECT *FROM TBL_FATURADETAY WHERE FATURAURUNID=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txturunad.Text = dr[1].ToString();
                txtmiktar.Text = dr[2].ToString();
                txtfiyat.Text = dr[3].ToString();
                txttutar.Text = dr[4].ToString();
                txtfaturaID.Text = dr[5].ToString();
            }
            bgl.baglanti().Close();
        }
        private void FrmFaturaUrunDuzenleme_Load(object sender, EventArgs e)
        {
            urunID.Text = id;
            listeleme();
            
        }
       
        void temizleme()
        {
            
            txturunad.Text = "";
            txtmiktar.Text = "";
            txtfiyat.Text = "";
            txttutar.Text = "";

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizleme();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM TBL_FATURADETAY WHERE FATURAURUNID=@p1",bgl.baglanti());
                cmd.Parameters.AddWithValue("@p1",urunID.Text);
                cmd.ExecuteNonQuery();
                bgl.baglanti().Close();
                temizleme();
                listeleme();
                MessageBox.Show("Silme İşlemi Başarı İle Gerçekleşti","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Silme Sırasında Hata Meydana Geldi","Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                decimal miktar = decimal.Parse(txtmiktar.Text);
                decimal fiyat = decimal.Parse(txtfiyat.Text);
                decimal tutar = miktar * fiyat;

                SqlCommand cmd = new SqlCommand("UPDATE TBL_FATURADETAY SET URUNAD=@p1,MIKTAR=@p2,FIYAT=@p3,TUTAR=@p4 WHERE FATURAURUNID=@p5", bgl.baglanti());
                cmd.Parameters.AddWithValue("@p1", txturunad.Text);
                cmd.Parameters.AddWithValue("@p2", miktar); 
                cmd.Parameters.AddWithValue("@p3", fiyat);  
                cmd.Parameters.AddWithValue("@p4", tutar);
                cmd.Parameters.AddWithValue("@p5", urunID.Text); 
                cmd.ExecuteNonQuery();
                listeleme();
                bgl.baglanti().Close();
                MessageBox.Show("Güncelleme İşlemi Gerçekleşti", "Bilgi", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Güncelleme işlemi sırasında hata oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
