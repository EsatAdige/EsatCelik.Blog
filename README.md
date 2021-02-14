# EsatCelik.Blog

# Sorular

# 1- Projede kullanıdığınız tasarım desenleri hangileridir? Bu desenleri neden kullandınız?
C- Generic repository pattern, option pattern, dependency injection: Genel olarak bu desenleri kullanmak projedeki bağımlılıkları en aza indirmek ve geri dönüldüğünde daha okunabilir bir kod bulmak adına fayda sağlamaktadır. Talep edilebilecek ek modül geliştirmeleri, "Generic repository pattern" deseninin esnek yapısından ötürü daha kolay olacaktır.
# 2- Kullandığınız teknoloji ve kütüphaneler hakkında daha önce tecrübeniz oldu mu? Tek tek yazabilir misiniz?
C- Genel olarak çalıştığım bütün projelerde "Generic Repository pattern" desenini kullandım. Özellikle projede yazmış olduğum "CacheManager" da her projemde yaygın olarak kullandığım bir kütüphanedir.
# 3- Daha geniş vaktiniz olsaydı projeye neler eklemek isterdiniz?
C- Localization alt yapısı getirilebilirdi.

# Proje hakkında notlar:
## Göndermiş olduğum script çalıştırılarak veya proje migrate edilerek veritabanı ayağa kaldırılabilir. 
Database script'i (script.sql) reponun ana dizinindedir. 
"Api Layer" içerisinde migrate edilecek context: "AppIdentityDbContext"
"Data Access Layer" içerisinde migrate edilecek context: "BlogContext"

## Authentication
Authentice olmak için User/Login methodu ile login olunmalıdır. Token bilgisi login olunduktan sonra gelecektir.
Username: Owner
Şifre: blog123
