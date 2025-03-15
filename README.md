# E-Ticaret Mikroservis Projesi

## 📌 Genel Bakış
Bu proje, **ASP.NET Core 6.0** ile geliştirilen **mikroservis tabanlı bir e-ticaret sistemi**dir. **N-Tier Architecture** ve **Onion Architecture** kullanılarak ölçeklenebilir ve sürdürülebilir bir yapı oluşturulmuştur.

## 🛠️ Teknolojiler ve Mimari
- **Mimari:** N-Tier Architecture, Onion Architecture
- **Tasarım Desenleri:** CQRS, Mediator, Repository Design Pattern
- **Veritabanı:** MSSQL, MongoDB, Dapper, Redis (MSSQL, Docker üzerinden çalıştırılmaktadır)
- **Kimlik Doğrulama ve Yetkilendirme:** IdentityServer
- **API Gateway:** Ocelot
- **Mikroservisler:** Çeşitli e-ticaret fonksiyonlarını yöneten birden fazla mikroservis

## 📂 Mikroservislerin Genel Görünümü
Sistem, farklı işlevleri yerine getiren çeşitli mikroservislerden oluşmaktadır:

- **Ürün Servisi:** Ürün kataloğunu yönetir (CRUD işlemleri, filtreleme vb.)
- **Sipariş Servisi:** Sipariş oluşturma, takip etme ve işleme alma işlemlerini yürütür
- **Müşteri Servisi:** Kullanıcı profillerini ve tercihlerini yönetir
- **Ödeme Servisi:** Güvenli ödeme işlemlerini gerçekleştirir
- **Envanter Servisi:** Stok seviyelerini ve ürün müsaitliğini yönetir
- **Bildirim Servisi:** Kullanıcılara e-posta/SMS bildirimleri gönderir

## 🔐 Kimlik Doğrulama ve Güvenlik
Bu proje, güvenli kimlik doğrulama ve yetkilendirme için **IdentityServer** kullanmaktadır. Her mikroservis, güvenli etkileşimler sağlamak için belirlenen erişim kontrol politikalarına uymaktadır.

## 🌍 API Gateway - Ocelot
Tüm mikroservisler **Ocelot API Gateway** altında yönetilmektedir. Bu yapı sayesinde:
- Merkezi istek yönlendirme
- Yük dengeleme
- Kimlik doğrulama ve yetkilendirme
- Hız sınırlama ve önbellekleme sağlanmaktadır.

## 💡 Katkıda Bulunma
Projeye katkıda bulunmak isteyenler için geri bildirim ve pull request’ler açıktır.

## 📜 Lisans
Bu proje [MIT Lisansı](LICENSE) ile lisanslanmıştır.

---
Herhangi bir sorunuz olursa bizimle iletişime geçebilirsiniz!

