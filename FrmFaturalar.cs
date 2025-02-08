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
using DevExpress.Pdf.Native.BouncyCastle.Asn1.X509;

namespace Ticari_Otomasyon
{
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl=new SqlBaglanti();
        public string ıd;

        void listele()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT *FROM TBL_FATURABILGI",bgl.baglanti());
            adapter.Fill(dataTable);
            gridControl1.DataSource = dataTable;

        }
        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            
            listele();
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
{
    if (TxtId.Text == "")
    {
        // Fatura Bilgileri Ekleme
        SqlCommand cmd = new SqlCommand("INSERT INTO TBL_FATURABILGI(SERINO, SIRANO, TARIH, SAAT, VERGIDAIRESI, ALICIADSOYAD, TESLIMEDEN, TESLIMALAN) " +
            "VALUES(@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8)", bgl.baglanti());
        cmd.Parameters.AddWithValue("@p1", txtserino.Text);
        cmd.Parameters.AddWithValue("@p2", txtsırano.Text);
        cmd.Parameters.AddWithValue("@p3", DateTime.Parse(msktarih.Text));
        cmd.Parameters.AddWithValue("@p4", msksaat.Text);
        cmd.Parameters.AddWithValue("@p5", txtvergidaire.Text);
        cmd.Parameters.AddWithValue("@p6", txtalıcı.Text);
        cmd.Parameters.AddWithValue("@p7", txtteslimalan.Text);
        cmd.Parameters.AddWithValue("@p8", txtteslimeden.Text);
        cmd.ExecuteNonQuery();
        bgl.baglanti().Close();
        listele();
        MessageBox.Show("Kayıt Başarıyla Yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
    
   
    }
            if (TxtId.Text != "")
            {
                decimal t = 0;
                decimal fiyat = 0;
                int miktar = 0;
                if (decimal.TryParse(txtmiktar.Text, out decimal miktarDecimal))
                {
                    miktar = (int)miktarDecimal; 
                }
                if (decimal.TryParse(txtfiyat.Text, out fiyat))
                {
                    t = fiyat * miktarDecimal;
                }
                SqlCommand cmd2 = new SqlCommand("INSERT INTO TBL_FATURADETAY(URUNAD, MIKTAR, FIYAT, TUTAR, FATURAID) " +
                    "VALUES(@p1, @p2, @p3, @p4, @p5)", bgl.baglanti());           
                cmd2.Parameters.AddWithValue("@p1", txturunad.Text); 
                cmd2.Parameters.AddWithValue("@p2", txtmiktar.Text); 
                cmd2.Parameters.AddWithValue("@p3", fiyat);
                cmd2.Parameters.AddWithValue("@p4", t); 
                cmd2.Parameters.AddWithValue("@p5", txtfaturaID.Text); 
                cmd2.ExecuteNonQuery();
                bgl.baglanti().Close();
                

                SqlCommand cmd3 = new SqlCommand("insert into TBL_FIRMAHAREKETLER(URUNID,ADET,PERSONEL,FIRMA,FIYAT,TOPLAM,FATURAID,TARIH) VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)",bgl.baglanti());
                cmd3.Parameters.AddWithValue("@p1",urunID.Text);
                cmd3.Parameters.AddWithValue("@p2",txtmiktar.Text);
                cmd3.Parameters.AddWithValue("@p3",txtpersonel.Text);
                cmd3.Parameters.AddWithValue("@p4",txtfirma.Text);
                cmd3.Parameters.AddWithValue("@p5",fiyat);
                cmd3.Parameters.AddWithValue("@p6",t);
                cmd3.Parameters.AddWithValue("@p7",txtfaturaID.Text);
                cmd3.Parameters.AddWithValue("@p8", DateTime.Parse(msktarih.Text));
                cmd3.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt Başarıyla Yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SqlCommand cmd4 = new SqlCommand("UPDATE TBL_URUNLER SET ADET=ADET-@p1 WHERE ID=@p2 ",bgl.baglanti());
                cmd4.Parameters.AddWithValue("@p1",txtmiktar.Text);
                cmd4.Parameters.AddWithValue("@p2",urunID.Text);
                cmd4.ExecuteNonQuery();
                bgl.baglanti().Close();
            }


        }


        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            
            if (dr != null)
            {
                TxtId.Text = dr["FATURABILGIID"].ToString();
                txtserino.Text = dr["SERINO"].ToString();
                txtsırano.Text = dr["SIRANO"].ToString();
                msktarih.Text = dr["TARIH"].ToString();
                msksaat.Text = dr["SAAT"].ToString();
                txtvergidaire.Text = dr["VERGIDAIRESI"].ToString();
                txtalıcı.Text = dr["ALICIADSOYAD"].ToString();
                txtteslimeden.Text = dr["TESLIMEDEN"].ToString();
                txtteslimalan.Text = dr["TESLIMALAN"].ToString();
            }
        }
        void temizle()
        {
            TxtId.Text = "";
            txtserino.Text = "";
            txtsırano.Text = "";
            msktarih.Text = "";
            msksaat.Text = "";
            txtvergidaire.Text = "";
            txtalıcı.Text = "";
            txtteslimeden.Text = "";
            txtteslimalan.Text = "";
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM TBL_FATURABILGI WHERE FATURABILGIID=@p1",bgl.baglanti());
                cmd.Parameters.AddWithValue("@p1",TxtId.Text);
                cmd.ExecuteNonQuery();
                bgl.baglanti().Close();
                listele();
            }
            catch (Exception)
            {
                MessageBox.Show("Silme işlemi sırasında hata meydana geldi","Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE TBL_FATURABILGI SET SERINO=@p1,SIRANO=@p2,TARIH=@p3,SAAT=@p4,VERGIDAIRESI=@p5,ALICIADSOYAD=@p6,TESLIMEDEN=@p7,TESLIMALAN=@p8 WHERE FATURABILGIID=@p9",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",txtserino.Text);
            cmd.Parameters.AddWithValue("@p2",txtsırano.Text);
            cmd.Parameters.AddWithValue("@p3", msktarih.Text);
            cmd.Parameters.AddWithValue("@p4",msksaat.Text);
            cmd.Parameters.AddWithValue("@p5",txtvergidaire.Text);
            cmd.Parameters.AddWithValue("@p6",txtalıcı.Text);
            cmd.Parameters.AddWithValue("@p7",txtteslimeden.Text);
            cmd.Parameters.AddWithValue("@p8",txtteslimalan.Text);
            cmd.Parameters.AddWithValue("@p9", TxtId.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Güncelleme işlemi başarıyla gerçekleşti", "Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaUrunDetay urunDetay=new FrmFaturaUrunDetay();
            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (row != null)
            {
                urunDetay.ID = row["FATURABILGIID"].ToString();
            }
            urunDetay.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd= new SqlCommand("SELECT URUNAD,SATISFIYAT FROM TBL_URUNLER  WHERE ID=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",urunID.Text);
            SqlDataReader dr=cmd.ExecuteReader();
            while(dr.Read())
            {
                txturunad.Text = dr[0].ToString();
                txtfiyat.Text = dr[1].ToString();
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
