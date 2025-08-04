# HGBP - Have Gamers Been Pwned?

**HGBP (Have Gamers Been Pwned?)** is a modular Unity asset that helps game developers integrate password (and optional email) leak detection systems into their games using [HaveIBeenPwned](https://haveibeenpwned.com/) APIs.

🎯 **Goal**: To reduce the use of leaked credentials during registration in both online and offline games.

---

## 🧩 Features

### ✅ Implemented

- 🔐 Password Breach Check via HIBP API (k-Anonymity method)
- 📧 Optional Email Breach Check (requires premium API key)
- 🎮 Unity Demo Scene for quick preview and testing
- 🧱 Modular Architecture (can be extended/customized)

### 🔄 In Progress

- 📦 Offline Dictionary System (for fully local integration)
- 📘 Full Developer Documentation
- 🧪 Test Architecture (Unit tests & example use cases)

### 📌 Planned

- 🛠️ Inspector GUI for easy setup
- 🧰 Standalone Dictionary Builder Tool
- 🌐 Multi-language Support
- 🖼️ Asset Store-Ready Marketing Materials (Icons, Screenshots, GIFs)

---

## 🚀 Getting Started

### 1. Requirements

- Unity 2021.3 LTS or later
- Internet connection for API usage
- (Optional) [HIBP API Key](https://haveibeenpwned.com/API/Key) for email checking

### 2. Usage

1. Import the package into your Unity project.
2. Open the `DemoScene` located under `Assets/HGBP/Demo`.
3. Try password and email checking with provided input fields.
4. Customize `PasswordChecker.cs` and `EmailChecker.cs` for your integration.
5. For email checking, assign your API key inside `EmailChecker.cs`.

### 3. Notes

- The asset **does not transmit any personal data** to third parties other than HIBP.
- All queries are hashed and respect k-anonymity protocols.
- Email check is **disabled by default** unless a valid key is provided.

---

## 🧭 Roadmap

| Feature                     | Status         |
|-----------------------------|----------------|
| Password breach API check   | ✅ Completed   |
| Email breach API support    | ✅ Completed   |
| Unity demo scene            | ✅ Completed   |
| Offline leak dictionary     | 🔄 In Progress |
| Inspector GUI               | 📌 Planned     |
| Dictionary builder tool     | 📌 Planned     |
| Multi-language support      | 📌 Planned     |

---

## 📁 Repository Structure

HGBP/
├── Demo/ # Contains demo implementations
│ ├── Scenes/
│ │ ├── Email Checker Demo.unity # Email leak check demo scene
│ │ └── Password Checker Demo.unity # Password leak check demo scene
│ └── Scripts/
│ ├── EmailChecker.cs # Optional email leak checker (HIBP Premium required)
│ └── PasswordChecker.cs # Password validation using k-Anonymity model
├── Readme.txt # Unity Editor-friendly documentation

---

## 🔒 Security & Ethics

- This tool does not collect, store, or transmit credentials.
- All processing is done locally or through HIBP’s anonymized APIs.
- Ideal for developers focused on secure credential handling during user onboarding.

---

## 👨‍💻 Author

**Ege Berkay Cesur**  
Game Developer | Security-Focused Tools  
🔗 [LinkedIn](https://www.linkedin.com/in/c0mblaster)  
📧 Contact: egeberkaycesur@hexamopter.org

---

## 📄 License

MIT License © 2025  
Free for both commercial and non-commercial use. Attribution appreciated but not required.

---

## 🌐 Related Links

- [HaveIBeenPwned API Docs](https://haveibeenpwned.com/API/v3)
- [Unity Asset Store Submission Guidelines](https://unity.com/asset-store/sell-assets)
- [HIBP k-Anonymity Model](https://www.troyhunt.com/ive-just-launched-pwned-passwords-version-2/)