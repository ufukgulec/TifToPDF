using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace DocConverter
{
    public static class Tif2Pdf
    {
        /// <summary>
        /// Tif dosyasının path'i ile birlikte Pdf dosyası oluşturur ve kaydedilir.
        /// </summary>
        /// <param name="tiffPath">Kaynak Dosya: Tif dosyasının dosya yolu</param>
        /// <param name="pdfPath">Hedef Dosya: Pdf dosyasının dosya yolu</param>
        public static void ConvertFromPath(string tiffPath, string pdfPath)
        {
            using (System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(tiffPath))
            {
                int numberOfPages = bitmap.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);

                // Pdf sayfası
                using (Document document = new Document(PageSize.A4, 50, 50, 50, 50))
                {
                    using (FileStream fs = new FileStream(pdfPath, FileMode.CreateNew))
                    {
                        using (PdfWriter writer = PdfWriter.GetInstance(document, fs))
                        {
                            document.Open();
                            PdfContentByte cb = writer.DirectContent;

                            for (int page = 0; page < numberOfPages; page++)
                            {
                                bitmap.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, page);

                                using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                                {
                                    bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(stream.ToArray());

                                    stream.Close();

                                    img.ScalePercent(72f / bitmap.HorizontalResolution * 100);

                                    img.ScaleAbsolute(document.PageSize);

                                    img.SetAbsolutePosition(0, 0);

                                    cb.AddImage(img);

                                    document.NewPage();
                                }

                            }

                            document.Close();
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Tif dosyasının path'i ile birlikte Pdf dosyası oluşturur ve byte array olarak döner.
        /// </summary>
        /// <param name="tiffPath">Kaynak Dosya: Tif dosyasının dosya yolu</param>
        /// <returns>Hedef Dosyanın (Pdf dosyasının) byte array'ini döner</returns>
        public static byte[] ConvertFromPath(string tiffPath)
        {
            using (System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(tiffPath))
            {
                int numberOfPages = bitmap.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);

                // Pdf sayfası
                using (Document document = new Document(PageSize.A4, 50, 50, 50, 50))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (PdfWriter writer = PdfWriter.GetInstance(document, memoryStream))
                        {
                            document.Open();
                            PdfContentByte cb = writer.DirectContent;

                            for (int page = 0; page < numberOfPages; page++)
                            {
                                bitmap.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, page);

                                using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                                {
                                    bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(stream.ToArray());

                                    stream.Close();

                                    img.ScalePercent(72f / bitmap.HorizontalResolution * 100);

                                    img.ScaleAbsolute(document.PageSize);

                                    img.SetAbsolutePosition(0, 0);

                                    cb.AddImage(img);

                                    document.NewPage();
                                }
                            }

                            document.Close();
                        }
                        return memoryStream.ToArray();
                    }
                }
            }
        }

        /// <summary>
        /// Tif dosyasının byte array'i ile birlikte Pdf dosyası oluşturur ve kaydedilir.
        /// </summary>
        /// <param name="tiffBytes">Kaynak Dosya: Tif dosyasının byte array'i</param>
        /// <param name="pdfPath">Hedef Dosya: Pdf dosyasının dosya yolu</param>
        public static void ConvertFromByteArray(byte[] tiffBytes, string pdfPath)
        {
            using (Stream stream = new MemoryStream(tiffBytes))
            {
                using (System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(stream))
                {
                    int numberOfPages = bitmap.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
                    // Pdf sayfası
                    using (Document document = new Document(PageSize.A4, 50, 50, 50, 50))
                    {
                        using (FileStream fs = new FileStream(pdfPath, FileMode.CreateNew))
                        {
                            using (PdfWriter writer = PdfWriter.GetInstance(document, fs))
                            {
                                document.Open();
                                PdfContentByte cb = writer.DirectContent;

                                for (int page = 0; page < numberOfPages; page++)
                                {
                                    bitmap.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, page);

                                    using (System.IO.MemoryStream str = new System.IO.MemoryStream())
                                    {

                                        bitmap.Save(str, System.Drawing.Imaging.ImageFormat.Png);

                                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(str.ToArray());

                                        str.Close();

                                        img.ScalePercent(72f / bitmap.HorizontalResolution * 100);

                                        img.ScaleAbsolute(document.PageSize);

                                        img.SetAbsolutePosition(0, 0);

                                        cb.AddImage(img);

                                        document.NewPage();
                                    }

                                }
                                document.Close();
                            }
                        }

                    }
                }
                stream.Close();
            }
        }

        /// <summary>
        /// Dosyanın byte array halini döner.
        /// </summary>
        /// <param name="Path">Kaynak Dosya: Tif dosyasının dosya yolu</param>
        /// <returns>Kaynak Dosyanın (Tif dosyasının) byte arrayi döner</returns>
        public static byte[] GetByteArray(string Path)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(Path);

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Tiff);
                return ms.ToArray();
            }
        }
        /// <summary>
        /// Tif dosyasını Jpeg olarak ayırır.
        /// </summary>
        /// <param name="Path">Kaynak Dosya: Tif dosyasının dosya yolu</param>
        /// <returns>Çıktı olarak oluşturulan jpeg dosyalarının konumlarını döner</returns>
        public static string[] SplitToJpeg(string path)
        {
            using (System.Drawing.Image imageFile = System.Drawing.Image.FromFile(path))
            {
                FrameDimension frameDimensions = new FrameDimension(
                    imageFile.FrameDimensionsList[0]);

                // Gets the number of pages from the tiff image (if multipage) 
                int frameNum = imageFile.GetFrameCount(frameDimensions);
                string[] jpegPaths = new string[frameNum];

                for (int frame = 0; frame < frameNum; frame++)
                {
                    // Selects one frame at a time and save as jpeg. 
                    imageFile.SelectActiveFrame(frameDimensions, frame);
                    using (Bitmap bmp = new Bitmap(imageFile))
                    {
                        jpegPaths[frame] = String.Format("{0}\\{1}{2}.jpg",
                            Path.GetDirectoryName(path),
                            Path.GetFileNameWithoutExtension(path),
                            frame);
                        bmp.Save(jpegPaths[frame], ImageFormat.Jpeg);
                    }
                }

                return jpegPaths;
            }
        }
    }
}
