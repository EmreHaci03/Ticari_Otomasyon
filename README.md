# Ticari Otomasyon

**Ticari_Otomasyon**, küçük ve orta ölçekli işletmelerin ticari süreçlerini (stok, cari, fatura, personel, kasa vb.) kolayca yönetebilmesini sağlayan bir **masaüstü otomasyon** sistemidir. Windows Forms (WinForms) mimarisiyle geliştirilmiş bu uygulama, doğrudan **SQL Server** veritabanı ile `SqlCommand` kullanılarak etkileşime geçer.

---

## 🛠️ Kullanılan Teknolojiler

| Teknoloji | Açıklama |
|----------|----------|
| **C# (.NET Framework)** | Masaüstü uygulama geliştirme (Windows Forms) |
| **Microsoft SQL Server** | Veritabanı yönetimi |
| **(SqlCommand, SqlConnection, SqlDataAdapter)** | Veritabanı işlemleri |
| **Visual Studio** | Geliştirme ortamı |
| **.xsd DataSet** | Raporlama ve grid veri bağlantıları için veri kümesi tanımlamaları |

---

## 📦 Modüller

Aşağıda uygulama içeriğinde yer alan başlıca modüller yer almaktadır:

- **FrmAnaModul** – Ana kontrol paneli
- **FrmMusteriler** – Müşteri listesi ve işlemleri
- **FrmFirmalar** – Firma yönetimi
- **FrmStoklar / FrmStokDetay** – Ürün stok takibi
- **FrmFaturalar / FrmFaturaUrunDetay** – Fatura işlemleri
- **FrmPersoneller** – Personel takibi
- **FrmGiderler** – Aylık gider kayıtları
- **FrmKasa** – Gelir/gider kasa hareketleri
- **FrmRaporlar** – Rapor görüntüleme (RDLC)
- **FrmMail** – SMTP üzerinden e-posta gönderimi
- **FrmNotlar / FrmNotDetay** – Not alma modülü
- **FrmAyarlar** – Uygulama ayarları ve admin yönetimi

---

## 🔌 Veritabanı Kullanımı

Uygulamada veritabanı işlemleri **ADO.NET** ile doğrudan yapılmaktadır. `SqlCommand`, `SqlDataReader`, `SqlDataAdapter` gibi sınıflar kullanılmıştır.


