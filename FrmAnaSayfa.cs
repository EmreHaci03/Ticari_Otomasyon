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
using System.Xml;
using static System.Net.WebRequestMethods;

namespace Ticari_Otomasyon
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();

        void azalanstoklar()
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT DISTINCT URUNAD, SUM(ADET) AS Adet\r\nFROM TBL_URUNLER\r\nGROUP BY URUNAD\r\nHAVING SUM(ADET) <= 20\r\nORDER BY Adet ;\r\n", bgl.baglanti());
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();
        }
        void ajanda()
        {
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter("select top 8  NOTTARIH,NOTSAAT,NOTBASLIK from TBL_NOTLAR\r\norder by  NOTSAAT desc", bgl.baglanti());
            DataTable dt = new DataTable();    
            sqlDataAdapter1 .Fill(dt);
            gridControl3.DataSource = dt;
            bgl.baglanti().Close();
        }
        void hareketler()
        {
            SqlDataAdapter sqlDataadapter = new SqlDataAdapter("exec Firmahareketler2", bgl.baglanti());
            DataTable dt = new DataTable();
            sqlDataadapter .Fill(dt);
            gridControl2.DataSource = dt;
            bgl.baglanti().Close();

        }
        void firmaliste()
        {
            SqlDataAdapter sqlDatagetAdapter = new SqlDataAdapter("select FIRMAAD ,FIRMATELEFON FROM TBL_FIRMALAR", bgl.baglanti());
            DataTable dt = new DataTable();
            sqlDatagetAdapter .Fill(dt);
            gridControl4.DataSource = dt;
            bgl.baglanti().Close();
        }
        void haberler()
        {
            string url = "https://www.hurriyet.com.tr/rss/anasayfa";
            using (XmlReader xmlReader = XmlReader.Create(url))
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "description")
                    {
                        listBox1.Items.Add(xmlReader.ReadElementContentAsString());
                    }
                }
            }
        }


        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            azalanstoklar();
            ajanda();
            hareketler();
            firmaliste();
            haberler();
            webBrowser3.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");
            
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

        private void gridView4_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {

        }
    }
}
