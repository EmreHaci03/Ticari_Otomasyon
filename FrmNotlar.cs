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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM TBL_NOTLAR",bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizle()
        {
            
            MskTarih.Text = "";
            MskSaat.Text = "";
            TxtBaslik.Text = "";
            RchIcerik.Text = "";
            TxtOlusturan.Text = "";
            TxtHitap.Text = "";
        }
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO TBL_NOTLAR(NOTTARIH,NOTSAAT,NOTBASLIK,NOTICERIK,NOTOLUSTURAN,NOTHITAP) VALUES(@p1,@p2,@p3,@p4,@p5,@p6)",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",MskTarih.Text);
            cmd.Parameters.AddWithValue("@p2",MskSaat.Text);
            cmd.Parameters.AddWithValue("@p3",TxtBaslik.Text);
            cmd.Parameters.AddWithValue("@p4",RchIcerik.Text);
            cmd.Parameters.AddWithValue("@p5",TxtOlusturan.Text);
            cmd.Parameters.AddWithValue("@p6",TxtHitap.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Not Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM TBL_NOTLAR WHERE NOTID=@p1",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",TxtId.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kayıt Silindi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            listele();
        }
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE TBL_NOTLAR SET NOTTARIH=@p1,NOTSAAT=@p2,NOTBASLIK=@p3,NOTICERIK=@p4,NOTOLUSTURAN=@p5,NOTHITAP=@p6 WHERE NOTID=@p7",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",MskTarih.Text);
            cmd.Parameters.AddWithValue("@p2",MskSaat.Text);
            cmd.Parameters.AddWithValue("@p3",TxtBaslik.Text);
            cmd.Parameters.AddWithValue("@p4",RchIcerik.Text);
            cmd.Parameters.AddWithValue("@p5",TxtOlusturan.Text);
            cmd.Parameters.AddWithValue("@p6",TxtHitap.Text);
            cmd.Parameters.AddWithValue("@p7",TxtId.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Not Güncellendi", "Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }

        

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtId.Text = dr["NOTID"].ToString();
                MskTarih.Text = dr["NOTTARIH"].ToString();
                MskSaat.Text = dr["NOTSAAT"].ToString();
                TxtBaslik.Text = dr["NOTBASLIK"].ToString();
                RchIcerik.Text = dr["NOTICERIK"].ToString();
                TxtOlusturan.Text = dr["NOTOLUSTURAN"].ToString();
                TxtHitap.Text = dr["NOTHITAP"].ToString();
            }
           
        }
        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow row=gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(row != null)
            {
                NotDetay notDetay = new NotDetay();
                notDetay.not = row["NOTICERIK"].ToString();
                notDetay.Show();
            }
        }
    }
}
