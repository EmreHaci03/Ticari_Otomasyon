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
using DevExpress.Data.Linq.Helpers;


namespace Ticari_Otomasyon
{
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into TBL_BANKALAR(BANKAAD,Il,Ilce,SUBE,IBAN,HESAPNO,BANKAYETKILI,YETKILITELEFON,TARIH,HESAPTURU,FIRMAID) " +
                "VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",txtbankaad.Text);
            cmd.Parameters.AddWithValue("@p2",cmbil.Text);
            cmd.Parameters.AddWithValue("@p3",cmbilce.Text);
            cmd.Parameters.AddWithValue("@p4",txtsube.Text);
            cmd.Parameters.AddWithValue("@p5",txtiban.Text);
            cmd.Parameters.AddWithValue("@p6",txthesapno.Text);
            cmd.Parameters.AddWithValue("@p7",txtyetkili.Text);
            cmd.Parameters.AddWithValue("@p8",mskyetkilitel.Text);
            cmd.Parameters.AddWithValue("@p9",msktarih.Text);
            cmd.Parameters.AddWithValue("@p10",txthesaptür.Text);
            cmd.Parameters.AddWithValue("@p11",lookUpEdit1.EditValue);
            cmd.ExecuteNonQuery();
            BankaListele();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Başarıyla Kaydedildi", "Kayıt",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }
        void BankaListele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("execute bankaBilgi", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void ilListele()
        {
            SqlCommand cmd = new SqlCommand("SELECT SEHIR FROM TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbil.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();

        }
        void firmalistele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT ID,FIRMAAD FROM TBL_FIRMALAR",bgl.baglanti());
            adapter.Fill(dt);
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "FIRMAAD";
            lookUpEdit1.Properties.DataSource = dt;

        }
       
        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            BankaListele();
            ilListele();
            firmalistele();
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            txtbankaad.Text = "";
            cmbil.Text = "";
            cmbilce.Text = "";
            txtsube.Text = "";
            txtiban.Text = "";
            txthesapno.Text = "";
            txtyetkili.Text = "";
            mskyetkilitel.Text = "";
            msktarih.Text = "";
            txthesaptür.Text = "";
            lookUpEdit1.Properties.ValueMember = "";
            //lookUpEdit1.Properties.DisplayMember = "";
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM TBL_BANKALAR WHERE BANKAID=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",txtbankaıd.Text);
            cmd.ExecuteNonQuery();
            BankaListele();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE TBL_BANKALAR SET BANKAAD = @p1, Il = @p2, Ilce = @p3, SUBE = @p4, IBAN = @p5, HESAPNO = @p6, " +
    "BANKAYETKILI = @p7, YETKILITELEFON = @p8, TARIH = @p9, HESAPTURU = @p10 WHERE BANKAID = @p12", bgl.baglanti());

            cmd.Parameters.AddWithValue("@p1", txtbankaad.Text);
            cmd.Parameters.AddWithValue("@p2", cmbil.Text);
            cmd.Parameters.AddWithValue("@p3", cmbilce.Text);
            cmd.Parameters.AddWithValue("@p4", txtsube.Text);
            cmd.Parameters.AddWithValue("@p5", txtiban.Text);
            cmd.Parameters.AddWithValue("@p6", txthesapno.Text);
            cmd.Parameters.AddWithValue("@p7", txtyetkili.Text);
            cmd.Parameters.AddWithValue("@p8", mskyetkilitel.Text);
            cmd.Parameters.AddWithValue("@p9", msktarih.Text);
            cmd.Parameters.AddWithValue("@p10", txthesaptür.Text);
            cmd.Parameters.AddWithValue("@p11",lookUpEdit1.EditValue);
            cmd.Parameters.AddWithValue("@p12", txtbankaıd.Text);
            cmd.ExecuteNonQuery();
            BankaListele();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Başarıyla Güncellendi", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void cmbil_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cmbilce.Properties.Items.Clear();
            SqlCommand cmd = new SqlCommand("SELECT ILCE FROM TBL_ILCELER WHERE SEHIR=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", cmbil.SelectedIndex + 1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbilce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
            cmbilce.Text = "";
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtbankaıd.Text= dr["BANKAID"].ToString();
            txtbankaad.Text = dr["BANKAAD"].ToString();
            cmbil.Text = dr["Il"].ToString();
            cmbilce.Text = dr["Ilce"].ToString();
            txtsube.Text = dr["SUBE"].ToString();
            txtiban.Text = dr["IBAN"].ToString();
            txthesapno.Text = dr["HESAPNO"].ToString();
            txtyetkili.Text = dr["YETKILIADSOYAD"].ToString();
            mskyetkilitel.Text= dr["YETKILITELEFON"].ToString();
            msktarih.Text= dr["TARIH"].ToString();
            txthesaptür.Text = dr["HESAPTURU"].ToString();
            lookUpEdit1.Text = dr["FIRMAAD"].ToString();
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
