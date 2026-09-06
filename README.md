# NotDefteriUygulamasi

Sakarya Üniversitesi - Nesneye Dayalı Programlama dersi kapsamında hazırlanmış, C# ve Windows Forms ile geliştirilmiş, birden fazla sekmeyi destekleyen zengin metin editörü (not defteri) uygulamasıdır.

## Neler Yapıldı?

- **Çoklu sekme (tab) desteği**: `TabControl` üzerinde her sekme kendi `RichTextBox`'ına sahip; yeni sekme açma, seçili sekmeyi kapatma, tüm sekmeleri kapatma ve seçili hariç tümünü kapatma işlemleri destekleniyor.
- **Dosya işlemleri**: Belgeyi RTF olarak kaydetme, farklı isim/formatla (`.txt`, `.cs` vb.) kaydetme ve RTF/TXT dosyası açma.
- **Metin düzenleme**: Geri al / yinele, kes / kopyala / yapıştır, tümünü seç.
- **Biçimlendirme araç çubuğu**: Yazı tipi ve boyutu seçimi (sistemdeki yüklü fontlar otomatik listeleniyor), kalın/italik/altı çizili/üstü çizili yapma, büyük/küçük harfe çevirme, yazı boyutunu artırma/azaltma, yazı rengi ve vurgu (arka plan) rengi değiştirme (yeşil/turuncu/sarı gibi hazır seçeneklerle).
- **Durum çubuğu**: `Timer` ile belirli aralıklarla aktif belgedeki karakter sayısı hesaplanıp ekranda gösteriliyor.
- **Kapatma kontrolü**: Belgede kaydedilmemiş değişiklik varsa, form kapatılmadan önce kullanıcıya uyarı veriliyor.

## Proje Yapısı

| Dosya | Açıklama |
|---|---|
| `Form1.cs` | Uygulamanın tüm mantığı (sekme, dosya, metin ve biçimlendirme işlemleri) |
| `Form1.Designer.cs` | Arayüz bileşenlerinin (menü, araç çubuğu, kontroller) tasarımcı tarafından üretilen kodu |
| `Program.cs` | Uygulama giriş noktası |

## Bilinen Notlar

- Sekmeler ve içerikleri bellekte tutuluyor; uygulama kapatılınca kaydedilmemiş sekmeler kaybolur (her sekme için ayrı ayrı kaydetme takibi yok, sadece aktif belge için `Modified` kontrolü yapılıyor).
- "Farklı Kaydet" varsayılan olarak düz metin (`RichTextBoxStreamType.PlainText`) olarak kaydediyor, bu nedenle biçimlendirme (kalın, renk vb.) `.rtf` dışındaki formatlarda kaybolur.
