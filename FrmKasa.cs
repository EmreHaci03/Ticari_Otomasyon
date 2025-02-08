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
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        public string aktifkullanici;
        void firmahareketler()
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("execute FirmaHareketler",bgl.baglanti());
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void musterihareketler()
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("execute MusteriHareketler", bgl.baglanti());
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            gridControl2.DataSource = dt;
        }

        void personelmaas()
        {
            SqlCommand cmd = new SqlCommand("select sum(MAASLAR) from TBL_GIDERLER", bgl.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                labelControl5.Text = dr[0].ToString();
            }
        }
        void musterisayisi()
        {
            SqlCommand cmd = new SqlCommand("select count(*) FROM TBL_MUSTERILER", bgl.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                labelControl7.Text=dr[0].ToString();           
            }
        }
        void firmasayisi()
        {
            SqlCommand sql = new SqlCommand("select count(*) FROM TBL_FIRMALAR",bgl.baglanti());
            SqlDataReader dr = sql.ExecuteReader();
            while(dr.Read())
            {
                labelControl9.Text = dr[0].ToString();
            }
        }
        void sehirsayisi()
        {

        }
        void personelsayisi()
        {
            SqlCommand cmd = new SqlCommand("select count(*) FROM TBL_PERSONELLER",bgl.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                labelControl13.Text = dr[0].ToString();
            }
        }
        void aktifodemeler()
        {
            SqlCommand cmd = new SqlCommand("select(ELEKTRIK+SU+DOGALGAZ) FROM TBL_GIDERLER ORDER BY GIDERID asc", bgl.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                labelControl3.Text = dr[0].ToString();
            }
        }
        void toplamtutar()
        {
            SqlCommand cmd = new SqlCommand("SELECT SUM(TUTAR) FROM TBL_FATURADETAY",bgl.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                labelControl2.Text = dr[0].ToString();
            }
        }
        void firmasehirsayısı()
        {
            SqlCommand cmd = new SqlCommand("select COUNT(IL) FROM TBL_FIRMALAR", bgl.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                labelControl11.Text = dr[0].ToString();
            }
        }
        void musterisehirsayisi()
        {
            SqlCommand cmd = new SqlCommand("select COUNT(IL) FROM TBL_MUSTERILER", bgl.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                labelControl21.Text = dr[0].ToString();
            }
        }
        void urunstoksayisi()
        {
            SqlCommand cmd = new SqlCommand("SELECT SUM(ADET) FROM TBL_URUNLER", bgl.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                labelControl15.Text = dr[0].ToString();
            }
        }
        void giderlisteleme()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select top 4  *from TBL_GIDERLER", bgl.baglanti());
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            gridControl3.DataSource = dt;

        }
        
        
        
        
        private void FrmKasa_Load(object sender, EventArgs e)
        {
            label1.Text = aktifkullanici;
            firmahareketler();
            musterihareketler();
            personelmaas();
            musterisayisi();
            firmasayisi();
            personelsayisi();
            aktifodemeler();
            toplamtutar();
            sehirsayisi();
            firmasehirsayısı();
            musterisehirsayisi();
            urunstoksayisi();
            giderlisteleme();
            
            
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

        private void gridView1_RowStyle_1(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
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

        private void gridView2_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
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

        

        private void gridView3_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
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


        int sayac = 0;



        private void timer1_Tick_1(object sender, EventArgs e)
        {
            sayac++;
            if (sayac > 0 && sayac <= 5)
            {
                groupBox11.Text = "Elektrik Faturaları";
                SqlCommand cmd = new SqlCommand("select TOP 4 AY ,ELEKTRIK from TBL_GIDERLER ORDER BY GIDERID desc", bgl.baglanti());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(reader[0], reader[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac > 5 && sayac <= 10)
            {
                chartControl1.Series["Aylar"].Points.Clear();
                groupBox11.Text = "Su Faturaları";
                SqlCommand cmd2 = new SqlCommand("select TOP 4 AY ,SU from TBL_GIDERLER ORDER BY GIDERID desc", bgl.baglanti());
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(reader2[0], reader2[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac > 10 && sayac <= 15)
            {
                chartControl1.Series["Aylar"].Points.Clear();
                groupBox11.Text = "Doğalgaz Faturaları";
                SqlCommand cmd3 = new SqlCommand("select TOP 4 AY ,DOGALGAZ from TBL_GIDERLER ORDER BY GIDERID desc", bgl.baglanti());
                SqlDataReader reader3 = cmd3.ExecuteReader();
                while (reader3.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(reader3[0], reader3[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac > 15 && sayac <= 20)
            {
                chartControl1.Series["Aylar"].Points.Clear();
                groupBox11.Text = "İnternet Faturaları";
                SqlCommand cmd4 = new SqlCommand("select TOP 4 AY ,INTERNET from TBL_GIDERLER ORDER BY GIDERID desc", bgl.baglanti());
                SqlDataReader reader4 = cmd4.ExecuteReader();
                while (reader4.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(reader4[0], reader4[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac == 21)
            {
                sayac = 0;
            }

        }
        int sayac2 =0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            sayac2++;
            if (sayac2 > 0 &&  sayac2 <= 5)
            {
                groupBox12.Text = "Su Faturaları";
                SqlCommand cmd = new SqlCommand("select TOP 4 AY ,SU from TBL_GIDERLER ORDER BY GIDERID desc", bgl.baglanti());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(reader[0], reader[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac2 > 5 &&  sayac2 <= 10)
            {
                chartControl2.Series["Aylar"].Points.Clear();
                groupBox12.Text = "Doğalgaz Faturaları";
                SqlCommand cmd2 = new SqlCommand("select TOP 4 AY ,DOGALGAZ from TBL_GIDERLER ORDER BY GIDERID desc", bgl.baglanti());
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(reader2[0], reader2[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac2 > 10 && sayac2 <= 15)
            {
                chartControl2.Series["Aylar"].Points.Clear();
                groupBox12.Text = "İnternet Faturaları";
                SqlCommand cmd3 = new SqlCommand("select TOP 4 AY ,INTERNET from TBL_GIDERLER ORDER BY GIDERID desc", bgl.baglanti());
                SqlDataReader reader3 = cmd3.ExecuteReader();
                while (reader3.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(reader3[0], reader3[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac2 > 15 && sayac2 <= 20)
            {
                chartControl2.Series["Aylar"].Points.Clear();
                groupBox12.Text = "Elektrik Faturaları";
                SqlCommand cmd4 = new SqlCommand("select TOP 4 AY ,ELEKTRIK from TBL_GIDERLER ORDER BY GIDERID desc", bgl.baglanti());
                SqlDataReader reader4 = cmd4.ExecuteReader();
                while (reader4.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(reader4[0], reader4[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac2 > 20 && sayac2 <= 25)
            {
                chartControl2.Series["Aylar"].Points.Clear();
                groupBox12.Text = "Ekstra Faturaları";
                SqlCommand cmd4 = new SqlCommand("select TOP 4 AY ,EKSTRA from TBL_GIDERLER ORDER BY GIDERID desc", bgl.baglanti());
                SqlDataReader reader4 = cmd4.ExecuteReader();
                while (reader4.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(reader4[0], reader4[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac2 == 26)
            {
                sayac = 0;
            }
        }
    }
}
