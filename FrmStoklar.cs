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
    public partial class Stoklar : Form
    {
        public Stoklar()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();

        void urunlistele()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select URUNAD,SUM(ADET) AS 'Miktar' from TBL_URUNLER group by URUNAD", bgl.baglanti());
            adapter.Fill(dataTable);
            gridControl1.DataSource = dataTable;
        }
        void urunMiktarlisteleme()
        {
            SqlCommand cmd = new SqlCommand("select URUNAD,SUM(ADET) AS 'Miktar' from TBL_URUNLER group by URUNAD", bgl.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            bgl.baglanti().Close();

        }

        void firmasehirlisteleme()
        {
            SqlCommand cmd = new SqlCommand("select IL ,COUNT(*) FROM TBL_FIRMALAR GROUP BY IL", bgl.baglanti());
            SqlDataReader dr2 = cmd.ExecuteReader(); 
            while (dr2.Read())
            {
                chartControl2.Series["Series 1"].Points.AddPoint(Convert.ToString(dr2[0]),Convert.ToInt32(dr2[1]));
            }
        }
        private void Stoklar_Load(object sender, EventArgs e)
        {
            urunlistele();
            urunMiktarlisteleme();
            firmasehirlisteleme();
            
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmStokDetay frmStokDetay = new FrmStokDetay();
            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(row != null )
            {
                frmStokDetay.urunad = row["URUNAD"].ToString();
            }
            frmStokDetay.Show();
        }
    }
}
