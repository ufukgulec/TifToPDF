# TiffToPdf

**TiffToPdf**, TIFF/TIF formatındaki görüntü dosyalarını PDF dokümanına dönüştürmek amacıyla geliştirilmiş bir .NET uygulamasıdır.

Proje, özellikle taranmış dokümanlar ve TIFF tabanlı belge içeriklerinin PDF formatına dönüştürülmesi gibi senaryolarda kullanılabilecek basit bir doküman dönüştürme yaklaşımını göstermektedir.

## 🎯 Amaç

TIFF formatındaki bir dosyanın PDF formatına dönüştürülmesini sağlamak.

```text
TIFF / TIF
    │
    ▼
TiffToPdf
    │
    ▼
PDF
```

Bu proje aynı zamanda .NET içerisinde görüntü tabanlı dokümanların işlenmesi ve farklı dosya formatlarına dönüştürülmesi konusunda örnek bir çalışma niteliğindedir.

## ✨ Özellikler

* TIFF (`.tif`) dosyalarını PDF'e dönüştürme
* TIFF (`.tiff`) dosyalarını PDF'e dönüştürme
* Doküman dönüştürme işleminin ayrı bir proje üzerinden yönetilmesi
* .NET tabanlı çözüm yapısı
* Dönüştürme işleminin uygulama içerisinden gerçekleştirilebilmesi

## 🏗️ Proje Yapısı

```text
TifToPDF/
│
├── DocConverter/
│   └── Doküman dönüştürme işlemleri
│
├── TiffToPdf/
│   └── TIFF → PDF uygulaması
│
├── TiffToPdf.sln
├── .gitignore
├── .gitattributes
└── README.md
```

### `DocConverter`

Doküman dönüştürme işlemlerinin gerçekleştirildiği temel proje/kütüphane katmanıdır.

Dönüştürme mantığının uygulamadan ayrıştırılmasını sağlayarak farklı doküman dönüşüm senaryolarının ileride eklenebilmesine uygun bir yapı oluşturur.

### `TiffToPdf`

TIFF dosyasının PDF'e dönüştürülmesini sağlayan uygulama katmanıdır.

## 🔄 Çalışma Akışı

Temel işlem akışı:

```text
┌──────────────────┐
│   TIFF / TIF     │
│      Input       │
└────────┬─────────┘
         │
         ▼
┌──────────────────┐
│  DocConverter    │
│                  │
│  Image Processing│
└────────┬─────────┘
         │
         ▼
┌──────────────────┐
│       PDF        │
│      Output      │
└──────────────────┘
```

Uygulama TIFF dosyasını input olarak alır, görüntü/doküman dönüşümünü gerçekleştirir ve PDF çıktısı oluşturur.

## 🛠️ Teknolojiler

| Teknoloji | Kullanım               |
| --------- | ---------------------- |
| **C#**    | Uygulama geliştirme    |
| **.NET**  | Uygulama altyapısı     |
| **TIFF**  | Input doküman formatı  |
| **PDF**   | Output doküman formatı |

## 📋 Kullanım Alanları

TIFF → PDF dönüşümü özellikle aşağıdaki senaryolarda kullanılabilir:

* Taranmış dokümanların PDF'e dönüştürülmesi
* Arşiv dokümanlarının standartlaştırılması
* Belge yönetim sistemleri
* Doküman arşivleme
* Kurumsal belge süreçleri
* TIFF tabanlı legacy sistemlerden PDF üretimi
* Workflow / BPM uygulamalarında doküman dönüşümü

## ⚙️ Gereksinimler

Projeyi çalıştırmak için uygun .NET SDK'nın sistemde kurulu olması gerekir.

Repository'yi klonlayın:

```bash
git clone https://github.com/ufukgulec/TifToPDF.git

cd TifToPDF
```

Solution'ı restore edin:

```bash
dotnet restore
```

Build:

```bash
dotnet build
```

Ardından `TiffToPdf` projesini çalıştırabilirsiniz.

```bash
dotnet run --project TiffToPdf
```

## 🧪 Örnek Senaryo

Input:

```text
document.tif
```

İşlem:

```text
document.tif
      │
      ▼
  Conversion
      │
      ▼
document.pdf
```

Output:

```text
document.pdf
```

## 🚀 Geliştirme Fikirleri

Proje ilerleyen aşamalarda daha kapsamlı bir doküman dönüştürme aracına dönüştürülebilir:

* [ ] Multi-page TIFF desteği
* [ ] Batch conversion
* [ ] TIFF → PDF kalite ayarları
* [ ] PDF compression
* [ ] DPI / resolution yönetimi
* [ ] Sayfa boyutu yönetimi
* [ ] Output directory seçimi
* [ ] CLI parametreleri
* [ ] Drag & Drop desteği
* [ ] Windows GUI
* [ ] REST API
* [ ] Docker desteği
* [ ] Unit tests
* [ ] Logging

## 🎯 Projenin Amacı

Bu repository, basit bir dosya formatı dönüşüm senaryosu üzerinden .NET ile doküman işleme yaklaşımını göstermek amacıyla oluşturulmuştur.

Özellikle:

* File processing
* Document conversion
* Image processing
* PDF generation
* .NET application development

konularında örnek bir çalışma sunmaktadır.

## 📄 License

Bu repository, doküman dönüştürme ve .NET geliştirme çalışmalarında örnek olarak kullanılmak amacıyla oluşturulmuştur.

## 👤 Author

**Ufuk Güleç**

* GitHub: https://github.com/ufukgulec
* Portfolio: https://ufukgulec.github.io/
