Net Bootcamp Assessment
Bir sitede yöneticisiniz. Sitenizde yer alan dairelerin aidat ve ortak kullanım elektrik, su ve doğalgaz faturalarının yönetimini bir sistem üzerinden yapacaksınız.
2 Tip kullanıcı bulunmaktadır :  Yönetici/Daire sahipleri-kiracı
Yönetici aşağıdaki işlemler gerçekleştirebilir.
-	İkamet eden kullancı bilgilerini için oluşturma/güncellme ve silme işlemleri gerçekleştirebilir.
-	Daire başına ödenmesi gereken aidat bilgilerini  toplu olarak veya tek tek  dairelere atama yaparak gerçekleştirebilir.
-	Bina olarak ödenmesi gereken  fatura bilgilerini(Elektirik/Su/Doğalgaz) aylık olarak girer.
-	Daire’lerin yapmış olduğu ödemeleri görebilir.
-	Aylık ve Yıllık olarak Daire başına borç durumunu görebilir.
-	Ödemesini düzenlı olarak yapan kullanıcıları görebilir  (BONUS)
Daire sahipleri aşağıdaki işlemleri gerçekleştirebilir.
-	Kendisine atanan fatura ve aidat bilgilerini görür.
-	Aidat veya Faturalar için ödeme yapabilir.


Daire bilgileri:
•	Blok bilgisi
•	Durumu (Dolu-boş)
•	Tipi (2+1 vb.)
•	Bulunduğu kat
•	Daire numarası
•	Daire sahibi veya kiracı




Kullanıcı Bilgileri:
•	Ad-soyad
•	TCNo
•	E-Mail
•	Telefon
 

Ödeme Bilgileri :
•	KrediKart/Nakit
•	Ödeme yapıldığı tarih
•	Ödeme türü / Aidat/Fatura(Elektirk-Su-Doğalgaz)
•	Tutar
•	Aidat/Fatura için YIL ve AY bilgisi
•	Hangi Daire için hangi kullanıcı ödeme yaptı bilgileri.


Projenin İşleyişi :
Yönetici Aşaması :
-	Sistem ilk ayağa kalktığında daha önce yok ise yönetici rolune sahip bir kullanıcı otomatik oluşturur.
-	Daire ile ilgili işlemleri yapabilmek için ; otomatik olarak oluşturulmuş username ve password ile token alır.
-	Yönetici rolune sahip olan kullanıcı ; Tüm daire bilgilerini ve kullanıcı(Daire sahibi veya kiracı ) bilgilerini girer. Daha sonra hangi dairenin hangi kullanıcıya ailt olduğu bilgisi için tek tek eşleştirmeleri gerçekleştirir.
-	Yönetici ; Ay bazlı olarak aidat bilgilerini ve fatura bilgilerini girer. 
-	Yönetici;  Hangi kullanıcınn ne kadar ödemesi olduğunu tek tek görebilir. Veya toplu olarak binanın ödenmiş veya ödenmemiş aidat ve faturalarını görebilir.


Kullanıcı Aşaması :
-	Kullanıcı(Diare sahibi veya kiracı )  TC No ve TEL No ile giriş yapabilir (SMS doğrulaması olmayacak)
-	Ay bazlı olarak ödenmiş veya ödenmemiş fatura ve aidat’ları görebilir.
-	Aidat veya Faturalar için ödeme yapabilir.

Kurallar :
-	Her daireye sadece bir kullanıcı atanabilir.
-	Ödemeler ilgili ayın sonuna kadar yapılır. Geciken ödemeler için %10 fazla tahsilat yapılır. (BONUS)
-	1 sene boyunca aidatlarını düzenli ödeyen kullanıcılar, bir sonraki sene aidatları %10 daha az öder (BONUS) 
-	Token/RefreshToken projede kullanılacaktır.
-	Filter yapısı uygun senaryolarda mutlaka kullanılacaktır.
-	Middleware yapısı uygun senaryolarda mutlaka kullanılacaktır.
-	Her iki projede de (API ve MVC) veri girişlerini doğrulamak için model validasyonları kullanın.
-	Hata yönetimi için uygun hata mesajlarını ve kullanıcı dostu geri bildirimleri ekleyin.




Gereksinimler :
-	Uygulamanın sadece backend tarafı yapılacaktır. UI tarafı hazırlanması isteğe bağlıdır.
-	Proje .Net 8 API ile hazırlanacaktır. (RESTful servisleri kullanılacaktır)
-	Database olarak MS SQL Server kullanılacaktır.
-	ORM olarak EF CORE kullanılacaktır.
-	Tablo ilişkisi olarak bire-bir ve bire-çok ilişki mutlaka kullanılacaktır.

