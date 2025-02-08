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
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();

        void giderlistele()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM TBL_GIDERLER", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void temizle()
        {
            TxtId.Text = "";
            CmbAy.Text = "";
            CmbYıl.Text = "";
            TxtElektrik.Text = "";
            TxtSu.Text = "";
            TxtDogalgaz.Text = "";
            TxtInternet.Text = "";
            TxtMaaslar.Text = "";
            TxtEkstra.Text = "";
            RchNotlar.Text = "";
        }
        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            giderlistele();
        }

       
       
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            e.Appearance.BackColor2 = Color.Aqua;
        }


        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO TBL_GIDERLER(AY,YIL,ELEKTRIK,SU,DOGALGAZ,INTERNET,MAASLAR,EKSTRA,NOTLAR) " +
                "VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",CmbAy.Text);
            cmd.Parameters.AddWithValue("@p2",CmbYıl.Text);
            cmd.Parameters.AddWithValue("@p3",decimal.Parse(TxtElektrik.Text));
            cmd.Parameters.AddWithValue("@p4",decimal.Parse(TxtSu.Text));
            cmd.Parameters.AddWithValue("@p5",decimal.Parse(TxtDogalgaz.Text));
            cmd.Parameters.AddWithValue("@p6",decimal.Parse(TxtInternet.Text));
            cmd.Parameters.AddWithValue("@p7",decimal.Parse(TxtMaaslar.Text));
            cmd.Parameters.AddWithValue("@p8",decimal.Parse(TxtEkstra.Text));
            cmd.Parameters.AddWithValue("@p9",RchNotlar.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Yapıldı", "Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            giderlistele();



        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM TBL_GIDERLER WHERE GIDERID=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",TxtId.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kayıt Silindi", "Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            giderlistele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE TBL_GIDERLER SET AY=@p1,YIL=@p2,ELEKTRIK=@p3,SU=@p4,DOGALGAZ=@p5,INTERNET=@p6,MAASLAR=@p7,EKSTRA=@p8,NOTLAR=@p9 WHERE GIDERID=@p10",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",CmbAy.Text);
            cmd.Parameters.AddWithValue("@p2",CmbYıl.Text);
            cmd.Parameters.AddWithValue("@p3",decimal.Parse(TxtElektrik.Text));
            cmd.Parameters.AddWithValue("@p4", decimal.Parse(TxtSu.Text));
            cmd.Parameters.AddWithValue("@p5", decimal.Parse(TxtDogalgaz.Text));
            cmd.Parameters.AddWithValue("@p6", decimal.Parse(TxtInternet.Text));
            cmd.Parameters.AddWithValue("@p7", decimal.Parse(TxtMaaslar.Text));
            cmd.Parameters.AddWithValue("@p8", decimal.Parse(TxtEkstra.Text));
            cmd.Parameters.AddWithValue("@p9", RchNotlar.Text);
            cmd.Parameters.AddWithValue("@p10",TxtId.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Question);
            giderlistele();

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtId.Text = dr["GIDERID"].ToString();
            CmbAy.Text = dr["AY"].ToString();
            CmbYıl.Text = dr["YIL"].ToString();
            TxtElektrik.Text = dr["ELEKTRIK"].ToString();
            TxtSu.Text = dr["SU"].ToString();
            TxtDogalgaz.Text = dr["DOGALGAZ"].ToString();
            TxtInternet.Text = dr["INTERNET"].ToString();
            TxtMaaslar.Text = dr["MAASLAR"].ToString();
            TxtEkstra.Text = dr["EKSTRA"].ToString();
            RchNotlar.Text = dr["NOTLAR"].ToString();

        }
    }
}
