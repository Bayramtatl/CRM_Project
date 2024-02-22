# CRM_Project
Bu proje .Net 6.0 ve Sql Server kullanılarak oluşturulmuştur ve müşterilerine teknik destek sağlayan bir firmanın müşterisi olan şirketlere verdiği destek hizmetlerinin yönetimini, takibini, şirket bazlı raporlama sistemini, personel bazlı raporlama sistemini gerçekleştirir. Aynı zamanda müşteriler de müşteri girişi yaparak talep kaydı açabilir, açtığı talep üzerinden aldığı servisleri kontrol edebilir ve puanlandırabilir.

## Kullanılan Teknolojiler
### FrontEnd
* Bootstrap
* Font-awesome
* Datatables
* Alertify
* Jquery
* Javascript
### Backend
* .Net 7.0
* EntityFramework
* Swagger
* Microsoft Sql Server

## Sistemin Akışı ve Bileşenleri

Proje müşteri iletişimi ve iş sürecini yönetmek amacıyla üretilmiştir. Daha çok teknik destek, siber güvenlik gibi kullanıcıların süreç boyunca bilgilendirilmelerini gerektiren sektörlere yöneliktir. Sistem bir web otomasyonu olarak tasarlanmıştır. Sistemde 3 farklı kullanıcı vardır. Bunlar müşteri firmalar ve destek firmanın personelleridir. Personel kullanıcısının da kendi içinde farklı rolleri vardır. Bu roller destek elemanı ve müdürdür. Bu 3 kullanıcının sistemdeki genel aktiviteleri aşağıdaki Şekil 3.5’te görülmektedir. Firmalar sisteme öncelikle kaydolduktan sonra bilgiler ile giriş yaparak sistemde teknik destek veya ilgili sorunlarıyla alakalı yardım talebi gönderebilir ve bu talepleri takip edebilirler. Destek firması kısmında ise ilgili personeller gelen talepleri yönetebilir güncelleyebilir bu taleplere yeni adımlar ekleyebilir ve müdür rolüne sahip olan kullanıcılar servisler ve elemanlar hakkında çeşitli raporlara erişebilirler. Aşağıdaki alt başlıklarda sistem adım adım detaylı olarak anlatılmıştır.

![image](https://github.com/Bayramtatl/CRM_Project/assets/92461836/d837d913-4877-4e3b-a114-ecfe0986ebda)

# Oturum Açma İşlemleri

Sistemdeki tüm kullanıcılar otomasyona oturum açarak giriş yapar. Oturum açmak için sistemde kayıtlı olmaları gerekmektedir. Müşteri firmalar sitenin arayüzündeki bağlantı üzerinden öncelikle sisteme firma adı, e-posta gibi bilgilerini kullanarak kaydolduktan sonra giriş yapabilir. Aynı zamanda müşteri firmalar destek şirketi personelleri tarafından da sisteme kaydedilebilir. Destek personelleri ise sisteme müdür tarafından eklenmektedir. Sisteme kaydedildikten sonra giriş yaparak isteğe bağlı olarak şifrelerini güncelleyebilmektedirler. Oturum, başarılı bir giriş senaryosu sonucu açılmaktadır. Oturum açıldıktan sonra toplam 20 dakika boyunca hiçbir işlem yapılmazsa oturum otomatik olarak kapanmaktadır. Tekrar giriş yaparak oturum açılabilmektedir.

# Servis Talebi İşlemleri

Servis talebi müşteri firma tarafından sistemde oturum açıldıktan sonra açılan arayüzde sol taraftaki menüden servis talebi oluştur bağlantısı ile erişilen sayfadan gönderilmektedir. Servis talebi göndermek, kısaca karşılaşılan sorun, konu ile ilgili açıklama gibi şeyler yazıldıktan sonra göndere basarak yapılmaktadır. Gönderilen talep ile servis sistemde açılmış olur. Daha sonra devam eden talepler kısmından müşteri firma personelleri gönderdikleri her bir taleple ilgili destek firmasının güncellemelerini takip edebilir ve servise ek talep açmak ve kapanmış servise puan vermek gibi ekstra girdiler yapabilmektedirler. Müşterilerin firmaya talep açmak yerine telefon ile sorunlarını bildirmeleri gibi durumlara karşı servis talebi destek firması personelleri tarafından da müşteri firmasını seçerek açılabilmektedir. Bu şekilde açılan servisler de ilgili firmaların arayüzüne düşmektedir.

# Servis Yönetimi İşlemleri
Servis talebi açıldıktan sonra servisin işleyiş kısmı destek firmasının personelleri tarafından yönetilir. Yeni bir servis açıldığında bu servis açık talepler kısmına düşmektedir. Personeller bu panelden yeni gelen talepleri kronolojik sıralama ile liste şeklinde görüntüleyebilirler. Bu listede açılan servislerin talep mesajı ve hizmeti isteyen firma gibi verilerini görüntüleyebilmektedirler. Servis adımı ekle butonu ile açılan talebe müdahale edilebilmektedirler. Servis adımı hizmet türü, yapılan müdahalenin açıklanması ve gider bilgisinin girilmesi ile eklenebilmektedir. Her servis adımı eklendiği personel bilgisini taşır. Böylece her bir servis adımından hangi personelin sorumlu olduğu takip edilebilmektedir. Yeni gelen taleplere servis adımı eklenmesiyle o servisin durum bilgisi değişir ve artık yeni gelen talepler yerine devam eden talepler listesine eklenmiş olur.

Devam eden talepler listesinde ilk müdahale yapılmış fakat iş süreci devam etmekte olan taleplerin listesi görüntülenmektedir. Tıpkı yeni gelen talepler panelindeki gibi servisin bilgileri görüntülenebilmektedir ve servise yeni servis adımları eklenebilmektedir. Bu listede ayrıca detaylar sekmesinden devam etmekte olan seçili servisin tüm servis adımları detay bilgileri ile beraber kronolojik olarak bir tablo üzerinde sergilenmektedir. Bu sayede iş süreçlerindeki karışıklıklar önlenmiş olmaktadır. Devam eden talepler panelinde ayrıca her bir servisi kapatma butonu bulunmaktadır. Eğer bir servis başarılı bir şekilde tamamlanmış ise servis kapatma butonu kullanılarak servis kapatılabilir ve bu servis artık kapanmış hizmetler sayfasına düşer. Kapanmış hizmetler sayfasında kapalı olan tüm hizmetler listelenir ve ihtiyaç dahilinde tekrar açılabilmeleri için servisi tekrar aç butonu bulunur.

# Rol ve Yetki Sistemi

Sistemde destek firmasının personelleri iki farklı rol ile ayrılmaktadır. Bu roller müdür ve destek elemanıdır. Bu rol ayrımının olma sebebi personel arayüzündeki bazı bilgilere her personelin ulaşmasını engellemeyi hedeflemektir. Destek elemanı sistemdeki servislerin yönetiminden sorumludur. Servislere servis adımı ekleme, servis açma ve kapama, firma ekleme gibi işlevleri yapabilir. Müdür ise destek elemanının sahip olduğu bütün işlevlere ek olarak sisteme destek elemanı ekleme ve silme işlemleri, servisler ve personeller bazında haftalık ve aylık rapor dokümanlarını görüntüleme gibi ek bileşenleri de görme yetkisine sahiptir.

# Raporlama Sistemi

Sistemde toplamda 2 farklı rapor dökümü bulunmaktadır. Bunlardan bir tanesi müşteri firmaların dökümünü görüntülemeyi amaçlamaktadır. Rapor aylık ve yıllık bazda seçilen bir firmaya verilmiş tüm hizmeti ve o hizmete harcanan gider ve hizmetlerden gelen toplam gelirin hesaplanarak ilgili firmaya verilen hizmetlerden elde edilen kazancı hesaplamaktadır. Bir diğer rapor ise sistemdeki destek elemanlarının iş süreçlerine ne kadar katıldığını ortaya çıkarmayı hedeflemektedir. Bu raporda seçilen bir personelin belirli bir tarih aralığında sistemdeki aktivitesini eklediği hizmet adımlarını listeleyerek ortaya çıkarmakta ve bu personelin diğer personellere göre yüzdelik bazdaki performans katkısını ortaya koymaktadır.

## Sistemden görseller

# Müşteri Paneli

![image](https://github.com/Bayramtatl/CRM_Project/assets/92461836/382aa054-3111-45f5-ac64-734e4f545253)

![image](https://github.com/Bayramtatl/CRM_Project/assets/92461836/e81f4294-0e5c-47f4-94b8-ec6b8c51fe0d)

![image](https://github.com/Bayramtatl/CRM_Project/assets/92461836/3aca5111-872e-4d92-af45-cc11243eb3c7)

# Personel Paneli

![image](https://github.com/Bayramtatl/CRM_Project/assets/92461836/296f2a8d-f6dc-42de-834c-b0ae960e95c7)

![image](https://github.com/Bayramtatl/CRM_Project/assets/92461836/551e92e8-35fc-48f7-bdf7-724393eb62a1)

![image](https://github.com/Bayramtatl/CRM_Project/assets/92461836/0f519498-8538-4fbc-a1ad-4900d6f7e017)

![image](https://github.com/Bayramtatl/CRM_Project/assets/92461836/82594152-504f-4712-bc35-7cfc1930a9e3)

![image](https://github.com/Bayramtatl/CRM_Project/assets/92461836/6d51a6ad-7ce1-4a95-98fc-df58ec577a0b)

![image](https://github.com/Bayramtatl/CRM_Project/assets/92461836/73017769-04b9-416c-b7a9-978d88ee36ec)







