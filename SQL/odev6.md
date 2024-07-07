# Ödev-6 Soru Çözümleri

1. **film**  tablosunda bulunan rental_rate sütunundaki değerlerin ortalaması nedir?
```
SELECT ROUND(AVG(rental_rate),4) AS avarage_rental_rate FROM film;

```
2. **film** tablosunda bulunan filmlerden kaç tanesi 'C' karakteri ile başlar?
```
SELECT COUNT(*) AS start_with_c FROM film
  WHERE title LIKE 'C%';
```
3. **film**  tablosunda bulunan filmlerden rental_rate değeri 0.99 a eşit olan en uzun (length) film kaç dakikadır?
```  
SELECT MAX(length) FROM film
  WHERE rental_rate = 0.99;
```
4. **film**  tablosunda bulunan filmlerin uzunluğu 150 dakikadan büyük olanlarına ait kaç farklı replacement_cost değeri vardır?
```  
SELECT COUNT(DISTINCT(replacement_cost)) FROM film
  WHERE length > 150
```
---
