using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Image = iTextSharp.text.Image;

namespace TiffToPdf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Çevrilecek tif dosyası seçilir.
        /// </summary>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openFileDialog.Title = "Browse Text Files";
            openFileDialog.Filter = "Tif Files (*.tif)|*.tif|Tiff Files (*.tiff)|*.tiff";
        }
        /// <summary>
        /// Çevrilecek tif dosyası seçilir.
        /// </summary>
        private void openFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sourceDocument.Text = openFileDialog.FileName;

            string FilePath = GetFilePath(openFileDialog.FileName);

            targetDocument.Text = $"{FilePath}.pdf";
        }
        /// <summary>
        /// PDF Kayıt için klasör seçilir.
        /// </summary>
        private void btnSaveBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();

            targetDocument.Text = $"{folderBrowserDialog.SelectedPath}\\{GetFileName(sourceDocument.Text)}.pdf";
        }

        /// <summary>
        /// Path'e göre dosyanın extension'ı olmadan path'ini döner.
        /// </summary>
        /// <param name="path">C:\Users\Admin\source\repos\TiffToPdf\TiffToPdf\test\test.tif</param>
        /// <returns>C:\Users\Admin\source\repos\TiffToPdf\TiffToPdf\test</returns>
        private string GetFilePath(string path)
        {
            return System.IO.Path.ChangeExtension(path, null);
        }
        /// <summary>
        /// Path'e göre dosyanın adını döner.
        /// </summary>
        /// <param name="path">C:\Users\Admin\source\repos\TiffToPdf\TiffToPdf\test\test.tif</param>
        /// <returns>test</returns>
        private string GetFileName(string path)
        {
            return System.IO.Path.GetFileNameWithoutExtension(path);
        }
        /// <summary>
        /// To PDF Butonuna tıklandığında çalışır.
        /// </summary>
        private void btnConvertPDF_Click(object sender, EventArgs e)
        {
            byte[] PdfByteArray = TiffToPDFByteArrayFromPath(sourceDocument.Text);

            System.IO.File.WriteAllBytes(targetDocument.Text, PdfByteArray);

        }
        /// <summary>
        /// Path'e göre tif dosyasını bulur ve pdf'e çevirir
        /// </summary>
        /// <param name="path">C:\Users\Admin\source\repos\TiffToPdf\TiffToPdf\test\test.tif</param>
        /// <returns>PDF Byte Array</returns>
        private byte[] TiffToPDFByteArrayFromPath(string path)
        {
            List<System.Drawing.Image> imagesInSource = new List<System.Drawing.Image>();

            using (System.Drawing.Image src = System.Drawing.Image.FromFile(path))
            {
                imagesInSource = GetAllPages(src);
            }

            // TIFF dosyasını MemoryStream'a yükleyin
            using (MemoryStream ms = new MemoryStream())
            {
                using (Document document = new Document())
                {
                    using (PdfWriter pdfWriter = PdfWriter.GetInstance(document, ms))
                    {
                        document.Open();

                        // TIFF dosyasını PDF sayfalarına dönüştürün
                        foreach (var image in imagesInSource)
                        {
                            // TIFF sayfasını PDF sayfasına ekleyin
                            document.NewPage();
                            document.Add(Image.GetInstance(image, ImageFormat.Tiff));
                        }
                        document.Close();
                        pdfWriter.Close();
                    }
                }
                ms.Close();
                return ms.ToArray();
            }
        }
        /// <summary>
        /// Tif dosyasında birden fazla sayfa varsa ona göre generic listte byte array döner
        /// </summary>
        public static List<System.Drawing.Image> GetAllPages(System.Drawing.Image multiTiff)
        {
            var images = new List<System.Drawing.Image>();
            var bitmap = (Bitmap)multiTiff;
            int count = bitmap.GetFrameCount(FrameDimension.Page);

            for (int idx = 0; idx < count; idx++)
            {
                bitmap.SelectActiveFrame(FrameDimension.Page, idx);
                using (var byteStream = new MemoryStream())
                {
                    bitmap.Save(byteStream, ImageFormat.Tiff);

                    images.Add(System.Drawing.Image.FromStream(byteStream));

                    byteStream.Close();
                }
            }
            return images;
        }

    }
}
