# Ödev-2 Soru Çözümleri

1. **film** tablosunda bulunan tüm sütunlardaki verileri **replacement cost** değeri 12.99 dan büyük eşit ve 16.99 küçük olma koşuluyla sıralayınız
```
SELECT film_id, title, description, release_year, 
	language_id, rental_duration, rental_rate, 
	length, replacement_cost, 
	rating, last_update, special_features, fulltext
FROM public.film
WHERE replacement_cost Between 12.99 and 16.99
```
2. **actor** tablosunda bulunan first_name ve last_name sütunlardaki verileri first_name 'Penelope' veya 'Nick' veya 'Ed' değerleri olması koşuluyla sıralayınız.
```
SELECT first_name, last_name
	FROM public.actor
	WHERE first_name IN('Penelope','Nick','Ed');
```
3. **film** tablosunda bulunan tüm sütunlardaki verileri rental_rate 0.99, 2.99, 4.99 VE replacement_cost 12.99, 15.99, 28.99 olma koşullarıyla sıralayınız.
```
SELECT film_id, title, description, release_year, 
	language_id, rental_duration, rental_rate, 
	length, replacement_cost, 
	rating, last_update, special_features, fulltext
FROM public.film
WHERE rental_rate IN(0.99, 2.99, 4.99) AND replacement_cost IN(12.99, 15.99, 28.99)
```

---
