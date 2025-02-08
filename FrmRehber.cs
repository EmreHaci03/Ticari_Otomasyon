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
    public partial class Rehber : Form
    {
        public Rehber()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();

        void musteriListele()
        {
            //Müşteri Listeleme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT AD,SOYAD,TELEFON,TELEFON2,MAIL FROM TBL_MUSTERILER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            ///////////////////
        }

        void firmalistele()
        { 
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT FIRMAAD,YETKILIGOREV,YETKILIADSOYAD,YETKILITELEFON,FIRMATELEFON,MAIL,FAX FROM TBL_FIRMALAR", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
            
        }

        private void FrmRehber_Load(object sender, EventArgs e)
        {
            musteriListele();
            firmalistele();

            

        }
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            e.Appearance.BackColor2 = Color.Aqua;

        }

        private void gridView1_RowStyle_1(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            e.Appearance.BackColor2 = Color.Aqua;
        }

        private void gridView2_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            e.Appearance.BackColor2 = Color.Aqua;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frm = new FrmMail();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr != null )
            {
                frm.mail = dr["MAIL"].ToString();
            }
            frm.Show();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frm2 = new FrmMail();
            DataRow dr2 = gridView2.GetDataRow(gridView2.FocusedRowHandle);

            if(dr2 != null )
            {
                frm2.mail = dr2["MAIL"].ToString();
            }
            frm2.Show();
        }
    }
}
