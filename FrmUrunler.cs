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
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();

        void urunListele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_URUNLER",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            urunListele();
            
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
           
            SqlCommand cmd = new SqlCommand("INSERT INTO TBL_URUNLER(URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY)" 
                +
                " VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", TxtAd.Text);
            cmd.Parameters.AddWithValue("@p2", TxtMarka.Text);
            cmd.Parameters.AddWithValue("@p3", TxtModel.Text);
            cmd.Parameters.AddWithValue("@p4", MskYil.Text);
            cmd.Parameters.AddWithValue("@p5", int.Parse(NudAdet.Value.ToString()));
            cmd.Parameters.AddWithValue("@p6", decimal.Parse(TxtAlis.Text.ToString()));
            cmd.Parameters.AddWithValue("@p7", decimal.Parse(TxtSatis.Text.ToString()));
            cmd.Parameters.AddWithValue("@p8", RichDetay.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Eklenmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            urunListele();

            


        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            
            SqlCommand cmd = new SqlCommand("DELETE FROM TBL_URUNLER WHERE ID=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",TxtId.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Başarıyla Silindi", "Silme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ////////////////////
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //Tablodaki değerleri Alanlara Aktarma
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtId.Text = dr["ID"].ToString();
            TxtAd.Text = dr["URUNAD"].ToString();
            TxtMarka.Text = dr["MARKA"].ToString();
            TxtModel.Text = dr["MODEL"].ToString();
            MskYil.Text = dr["YIL"].ToString();
            NudAdet.Value = decimal.Parse(dr["ADET"].ToString());
            TxtAlis.Text = dr["ALISFIYAT"].ToString();
            TxtSatis.Text = dr["SATISFIYAT"].ToString();
            RichDetay.Text = dr["DETAY"].ToString();



        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            
            SqlCommand cmd = new SqlCommand("UPDATE TBL_URUNLER SET URUNAD=@p1,MARKA=@p2,MODEL=@p3,YIL=@p4,ADET=@p5,ALISFIYAT=@p6,SATISFIYAT=@p7,DETAY=@p8 WHERE ID=@p9",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p9",TxtId.Text);
            cmd.Parameters.AddWithValue("@p1", TxtAd.Text);
            cmd.Parameters.AddWithValue("@p2", TxtMarka.Text);
            cmd.Parameters.AddWithValue("@p3", TxtModel.Text);
            cmd.Parameters.AddWithValue("@p4", MskYil.Text);
            cmd.Parameters.AddWithValue("@p5", int.Parse(NudAdet.Value.ToString()));
            cmd.Parameters.AddWithValue("@p6", decimal.Parse(TxtAlis.Text));
            cmd.Parameters.AddWithValue("@p7", decimal.Parse(TxtSatis.Text));
            cmd.Parameters.AddWithValue("@p8", RichDetay.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Güncellenmiştir", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            urunListele();
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            e.Appearance.BackColor2 = Color.Aqua;
            
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtId.Text = "";
            TxtAd.Text = "";
            TxtMarka.Text = "";
            TxtModel.Text = "";
            MskYil.Text = "";
            NudAdet.Value = 0;
            TxtAlis.Text = "";
            TxtSatis.Text = "";
            RichDetay.Text = "";


        }
    }
}
