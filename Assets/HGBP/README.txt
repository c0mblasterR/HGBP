====================================
HGBP - Have Gamers Been Pwned?
Unity Asset README
====================================

------------------------------------
🔐 TÜRKÇE BİLGİLENDİRME
------------------------------------

Bu Unity varlık paketi, oyun geliştiricilerinin kullanıcıların parolalarının daha güvenli olmasını sağlamak amacıyla geliştirilmiştir. HaveIBeenPwned servisi kullanılarak hem parola hem de (isteğe bağlı) e-posta sızıntı kontrolü sağlar.

⚙️ Öne Çıkan Özellikler:
✅ Yapıldı:
- HIBP API ile parola sızıntı kontrolü (demo sahne dahil)
- (Opsiyonel) E-posta kontrolü sistemi (API key ile çalışır)
- Demo sahne entegrasyonu
- Offline sözlük desteği (modüler sistem)

🔄 Yapılıyor:
- Geliştirici dokümantasyonlarının genişletilmesi
- Kod tabanının test altyapısı ile güçlendirilmesi

📌 Planlandı:
- Geliştirici dostu GUI inspector arayüzü
- Offline şifre sözlüğü oluşturucu aracı (standalone)
- Çoklu dil desteği (UI & hata mesajları)
- Unity Asset Store için görsel destek dosyaları (ikonlar, tanıtım görselleri)

🧪 Kullanım:
1. Demo sahnesini açın.
2. Girdi alanlarını kendi sahnenize entegre edin.
3. EmailChecker.cs yalnızca HIBP Premium API anahtarı ile çalışır.
4. Gelişmiş kullanım için GitHub sayfamıza bakınız.

🔒 Geliştirici Notu:
Bu sistem doğrudan veri toplamaz. Amaç yalnızca oyun içi şifrelerin tekrarlı ya da sızmış olmasını engellemeye yardımcı olmaktır. Veriler oyun dışına gönderilmez.

Daha fazla bilgi için:
https://github.com/c0mblasterR

------------------------------------
🔐 ENGLISH DOCUMENTATION
------------------------------------

This Unity asset helps developers secure user passwords using the HaveIBeenPwned API. It currently supports password checking and optional email breach validation.

⚙️ Features:
✅ Implemented:
- Password breach check via HIBP API (demo scene included)
- Optional email breach check (requires API key)
- Basic integration demo scene
- Offline dictionary support (modular implementation)

🔄 In Progress:
- Expanded developer documentation
- Internal testing support structures

📌 Planned:
- Developer-friendly GUI inspector support
- Offline password dictionary builder (standalone tool)
- Multi-language UI & error messages
- Visual materials for Unity Asset Store submission

🧪 How to Use:
1. Open the DemoScene.
2. Integrate the scripts with your own UI.
3. EmailChecker.cs requires a premium HIBP API key.
4. See GitHub for advanced configuration and dictionary systems.

🔒 Developer Note:
This asset does not collect or send any user data. Its sole purpose is to help avoid the use of compromised or weak passwords at registration. Everything runs locally.

For more:
https://github.com/c0mblasterR

------------------------------------
Lisans / License: MIT
Geliştirici / Developer: Ege Berkay Cesur
LinkedIn: https://www.linkedin.com/in/c0mblaster
------------------------------------
