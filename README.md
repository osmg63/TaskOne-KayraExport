# TaskTwoKayraExport

**TaskTwoKayraExport**, .NET 6 ile geliştirilmiş, katmanlı mimariyi  kullanan bir Web API uygulamasıdır.

---

## Başlangıç

Projeyi kendi bilgisayarınıza almak için:  

git clone https://github.com/osmg63/TaskOne-KayraExport.git

Projeyi klonladıktan sonra gerekli NuGet paketlerini yükleyin ve veritabanı için migration çalıştırın:  

dotnet restore

dotnet ef database update


## Veritabanı Ayarları (PostgreSQL)

Projede PostgreSQL kullanılmaktadır. `appsettings.json` dosyasında aşağıdaki bağlantı ayarlarını kendi ortamınıza göre düzenlemelisiniz:

- **Host:** Veritabanı sunucunuz (örneğin: localhost)  
- **Port:** PostgreSQL portu (varsayılan: 5432)  
- **Database:** Kullanılacak veritabanı adı (`TaskTwo`)  
- **Username / Password:** PostgreSQL kullanıcı adı ve şifre  



