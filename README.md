# 🌟 E-Ticaret Mikroservis Projesi

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

## 📂 Görseller


 **Giriş Sayfası**
  
 ![LoginIndex](https://github.com/user-attachments/assets/9a93b8bb-ab16-4922-bdfe-936ed2825e5e)


 **Ana Sayfa**
  
 ![DefaultIndex](https://github.com/user-attachments/assets/9c0fa24d-7c8e-4b95-84e5-c5328abc6c94)
 ![DefaultIndex2](https://github.com/user-attachments/assets/be8c2a68-5cc8-4189-9935-ec671db71621)
 ![DefaultIndex3](https://github.com/user-attachments/assets/7fa21b73-13ac-4805-b50e-16606086e564)


 **Ürün Sayfası**
  
 ![UrunIndex](https://github.com/user-attachments/assets/cf0719f9-9531-449a-9687-96ee61cd748e)


 **Ürün Detay Sayfası**
  
 ![UrunDetayIndex](https://github.com/user-attachments/assets/db3642b2-06f4-449e-8748-2a8e0876356b)
 ![UrunDetay2Index](https://github.com/user-attachments/assets/05caca86-6bd2-44ad-bfbf-0cbbbc0735e9)


 **Sepet Sayfası**
  
 ![SepetIndex](https://github.com/user-attachments/assets/ebc7ca56-0e41-49ff-972a-c5ca0b1a2213)


 **Admin Sayfası**

 ![Admin2](https://github.com/user-attachments/assets/e8e6847c-9ce3-4171-aa31-03640ebcf699)
 ![AdminUrun](https://github.com/user-attachments/assets/f632d546-bd6c-4925-8c87-1792666a5fcd)
  

## 💡 Katkıda Bulunma
Projeye katkıda bulunmak isteyenler için geri bildirim ve pull request’ler açıktır.

## 📜 Lisans
Bu proje [MIT Lisansı](LICENSE) ile lisanslanmıştır.

---
Herhangi bir sorunuz olursa bizimle iletişime geçebilirsiniz!

