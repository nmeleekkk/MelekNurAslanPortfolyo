# .NET Core Modern Portfolyo Mimarisi

Bu proje, bir yazılım geliştiricinin tüm süreçlerini dinamik olarak yönetebileceği, katmanlı mimari prensiplerine (veya profesyonel klasör yapısına) sadık kalınarak geliştirilen bir Portfolyo & CMS projesidir.

## Kullanılan Teknolojiler
* **Backend:** .NET Core 8.0
* **Veritabanı:** Microsoft SQL Server
* **ORM:** Entity Framework Core
* **Arayüz:** HTML5, CSS3, Bootstrap, JavaScript
* **Tasarım:** Admin Dashboard Entegrasyonu

## Proje Yol Haritası
Proje, profesyonel bir yazılım geliştirme sürecini simüle etmek adına 12 ana aşama üzerine kurgulanmıştır:

- [✓] **Adım 1:** Proje altyapısının kurulması ve dosya mimarisinin oluşturulması.
- [✓] **Adım 2:** Veritabanı tasarımının yapılması ve Entity Framework Core entegrasyonu.
- [✓] **Adım 3:** `appsettings.json` üzerinden veritabanı bağlantı konfigürasyonlarının tamamlanması.
- [✓] **Adım 4:** Admin Dashboard (Yönetim Paneli) arayüzünün projeye giydirilmesi.
- [✓] **Adım 5:** Dinamik içerik yönetimi için temel Controller ve View yapılarının kurulması.
- [✓] **Adım 6:** Portfolyo öğeleri için CRUD (Ekleme, Silme, Güncelleme) işlemlerinin kodlanması.
- [ ] **Adım 7:** Hakkımda, Deneyim ve Eğitim bilgilerinin dinamik hale getirilmesi.
- [✓] **Adım 8:** Resim yükleme (Image Upload) servisinin yazılması.
- [✓] **Adım 9:** İletişim formu mesajlarının veritabanına kaydedilmesi ve mail entegrasyonu.
- [✓] **Adım 10:** Kullanıcı (Admin) yetkilendirme ve giriş işlemlerinin (Identity/Session) yapılması.
- [ ] **Adım 11:** Frontend (Ziyaretçi Paneli) arayüzünün dinamik verilerle bağlanması.
- [ ] **Adım 12:** Projenin canlıya (Deployment) hazır hale getirilmesi ve son testler.

## Kurulum
1. Bu repoyu bilgisayarınıza clone'layın.
2. `appsettings.json` dosyasındaki `ConnectionStrings` bölümünü kendi yerel SQL Server bilgilerinize göre güncelleyin.
3. Paket Yöneticisi Konsolu'nu (Package Manager Console) açın ve `update-database` komutunu çalıştırarak veritabanı tablolarını oluşturun.
4. Projeyi çalıştırın.

---
*Bu proje geliştirilmeye devam etmektedir.*
