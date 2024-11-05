# Store Platform WhatsApp Message API

## 🌟 Overview | نظرة عامة | Genel Bakış

🌍 **[EN]** This project is a Web API associated with an e-commerce platform, which enables sending WhatsApp messages. This API is connected to the RabbitMQ message broker, allowing Python applications to access it and send Turkish language WhatsApp messages.

🌍 **[AR]** هذا المشروع هو واجهة برمجة تطبيقات (API) مرتبطة بمنصة متجر إلكتروني، والتي تتيح إرسال رسائل واتساب. تم ربط هذه API مع RabbitMQ، وهو نظام رسائل وسيط، مما يسمح لتطبيقات Python بالوصول إليها وإرسال رسائل واتساب باللغة التركية.

🌍 **[TR]** Bu proje, e-ticaret platformu ile bütünleşik bir WhatsApp mesajı gönderme API'sidir. RabbitMQ mesaj kuyruklama sistemi ile entegre çalışır, böylece Python uygulamaları bu API'ye erişip Türkçe WhatsApp mesajları gönderebilir.

## 🚀 Features | المميزات | Özellikler

### 🔹 Integration | التكامل | Entegrasyon
- RabbitMQ Message Broker
- Python Applications
- WhatsApp API
- E-commerce Platform

### 🔹 Functionality | الوظائف | İşlevsellik
- Message Management
- Automated Processing
- Turkish Language Support
- Scalable Architecture

## 💻 Technical Stack | التقنيات المستخدمة | Teknik Altyapı

- **.NET Core**
- **RabbitMQ**
- **Python**
- **WhatsApp Business API**
- **Docker**

## 📝 Requirements | المتطلبات | Gereksinimler

- .NET Core SDK
- RabbitMQ Server
- Python 3.x
- Docker (optional)

## 🛠️ Installation | التثبيت | Kurulum

```bash
# Clone the repository
git clone https://github.com/yourusername/store-platform-whatsapp-message-api.git

# Navigate to project directory
cd store-platform-whatsapp-message-api

# Install dependencies
dotnet restore
```

## 📦 Configuration | الإعداد | Yapılandırma

1. Set up RabbitMQ connection
2. Configure WhatsApp API credentials
3. Update application settings

## 🔧 Usage | الاستخدام | Kullanım

```csharp
// Example code for sending message
public async Task<ActionResult<string>> Send([FromBody] SendWpMessageCommandRequest request)
{
    return Ok(await mediator.Send(request));
}
```

## 📄 License | الترخيص | Lisans

MIT License

## 👥 Contributors | المساهمون | Katkıda Bulunanlar

- Muhammed Nur Alsammour

## 📞 Contact | التواصل | İletişim

For any inquiries, please reach out to [muhammed2005nour@gmail.com]

---
Made with ❤️ by Muhammed Nur Alsammour
