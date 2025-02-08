using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
    public partial class FrmAnaModul : Form
    {
        public FrmAnaModul()
        {
            InitializeComponent();
        }

        FrmUrunler frmUrun;
        FrmMusteriler frmMusteri;
        FrmFirmalar frmfirma;
        FrmPersoneller frmpersonel;
        Rehber frmrehber;
        FrmGiderler frmgider;
        FrmNotlar frmnot;
        FrmBankalar FrmBankalar;
        FrmFaturalar frmfaturalar;
        FrmAyarlar frmAyarlar;
        FrmHareketler frmHareketler;
        FrmRaporlar frmRaporlar;
        Stoklar frmStoklar;
        FrmKasa frmkasa;
        FrmAnaSayfa FrmAnaSayfa;
        public string kullaniciad;
       
        private void BtnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmUrun == null || frmUrun.IsDisposed)
            {
                {
                    frmUrun = new FrmUrunler();
                    frmUrun.MdiParent = this;
                    frmUrun.Show();
                }
               
            }
            else
            {
                frmUrun.Activate(); 
            }
        }

        private void BtnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmMusteri == null || frmMusteri.IsDisposed)
            {
                frmMusteri = new FrmMusteriler();
                frmMusteri.MdiParent = this;
                frmMusteri.Show();
            }
            else
            {
                frmMusteri.Activate();
            }
        }

        private void BtnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmfirma == null || frmfirma.IsDisposed)
            {
                frmfirma = new FrmFirmalar();
                frmfirma.MdiParent = this;
                frmfirma.Show();
            }
            else
            {
                frmfirma.Activate();
            }
        }

        private void BtnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmpersonel == null || frmpersonel.IsDisposed)
            {
                frmpersonel = new FrmPersoneller();
                frmpersonel.MdiParent = this;
                frmpersonel.Show();
            }
            else
            {
                frmpersonel.Activate();
            }
        }

        private void BtnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmrehber == null || frmrehber.IsDisposed)
            {
                frmrehber = new Rehber();
                frmrehber.MdiParent = this;
                frmrehber.Show();
            }
            else
            {
                frmrehber.Activate();
            }
        }

        private void BtnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmgider == null || frmgider.IsDisposed)
            {
                frmgider = new FrmGiderler();
                frmgider.MdiParent = this;
                frmgider.Show();
            }
            else
            {
                frmgider.Activate();
            }
        }

        private void BtnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmnot == null || frmnot.IsDisposed)
            {
                frmnot = new FrmNotlar();
                frmnot.MdiParent = this;
                frmnot.Show();
            }
            else
            {
                frmnot.Activate();
            }
        }

        private void BtnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FrmBankalar == null || FrmBankalar.IsDisposed)
            {
                FrmBankalar = new FrmBankalar();
                FrmBankalar.MdiParent = this;
                FrmBankalar.Show();
            }
            else
            {
                FrmBankalar.Activate();
            }
        }

        private void BtnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmfaturalar == null || frmfaturalar.IsDisposed)
            {
                frmfaturalar = new FrmFaturalar();
                frmfaturalar.MdiParent = this;
                frmfaturalar.Show();
            }
            else
            {
                frmfaturalar.Activate();
            }
        }

        private void BtnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmAyarlar == null || frmAyarlar.IsDisposed)
            {
                frmAyarlar = new FrmAyarlar();
                frmAyarlar.MdiParent = this;
                frmAyarlar.Show();
            }
            else
            {
                frmAyarlar.Activate();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmHareketler == null || frmHareketler.IsDisposed)
            {
                frmHareketler = new FrmHareketler();
                frmHareketler.MdiParent = this;
                frmHareketler.Show();
            }
            else
            {
                frmHareketler.Activate();
            }
        }

        private void FrmAnaModul_Load(object sender, EventArgs e)
        {
            
            
            
        }

        private void BtnRaporlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmRaporlar == null || frmRaporlar.IsDisposed)
            {
                frmRaporlar = new FrmRaporlar();
                frmRaporlar.MdiParent = this;
                frmRaporlar.Show();
            }
            else
            {
                frmRaporlar.Activate();
            }
        }

        private void BtnStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmStoklar == null || frmStoklar.IsDisposed)
            {
                frmStoklar = new Stoklar();
                frmStoklar.MdiParent = this;
                frmStoklar.Show();
            }
            else
            {
                frmStoklar.Activate();
            }
        }

        private void BtnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmkasa == null || frmkasa.IsDisposed)
            {
                frmkasa = new FrmKasa();
                frmkasa.MdiParent = this;
                frmkasa.aktifkullanici = kullaniciad;
                frmkasa.Show();
                
               
            }
            else
            {
                frmkasa.Activate();
            }
        }

        private void BtnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FrmAnaSayfa == null || FrmAnaSayfa.IsDisposed)
            {
                FrmAnaSayfa = new FrmAnaSayfa();
                FrmAnaSayfa.MdiParent = this;
                FrmAnaSayfa.Show();
            }
        }
    }
}

