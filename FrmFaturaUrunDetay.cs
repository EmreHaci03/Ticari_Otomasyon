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
    public partial class FrmFaturaUrunDetay : Form
    {
        public FrmFaturaUrunDetay()
        {
            InitializeComponent();
        }
        public string ID;
        SqlBaglanti bgl=new SqlBaglanti();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM TBL_FATURADETAY WHERE FATURAID = @p1", bgl.baglanti());
            adapter.SelectCommand.Parameters.AddWithValue("@p1", ID); 
            adapter.Fill(dt);
            gridControl1.DataSource = dt;
        }
        
        

        private void FrmFaturaUrunDetay_Load(object sender, EventArgs e)
        {
            label1.Text = ID ;
            listele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaUrunDuzenleme urunDuzenleme = new FrmFaturaUrunDuzenleme();
            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (row != null)
            {
                urunDuzenleme.id = row["FATURAURUNID"].ToString();
            }
            urunDuzenleme.Show();

        }
    }
}
