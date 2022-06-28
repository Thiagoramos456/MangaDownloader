using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMangaDownloader.Core.Services
{
    public class MangaService
    {
        public async Task GetMangaFromURL(string? mangaUrl, string? pdfSavePath)
        {
            var client = new HttpClient();
            var parser = new HtmlParser();
            
            var mangaHtml = await client.GetStringAsync(mangaUrl);
            var document = await parser.ParseDocumentAsync(mangaHtml);

            var mangaImgs = document.QuerySelectorAll("#readerarea img").Cast<IHtmlImageElement>();

            var allImagesBytes = new List<byte[]>();

            foreach (var img in mangaImgs)
            {
                var imageBytes = await client.GetByteArrayAsync(img.Source);
                allImagesBytes.Add(imageBytes);
            }

            GeneratePdf(allImagesBytes, @"C:\Users\Thiago Ramos de Lima\testepdf.pdf");
        }

        public void GeneratePdf(List<byte[]> imagesBytes, string? pdfSavePath)
        {
            var document = new Document(PageSize.A3);
            document.SetMargins(0, 0, 0, 0);

            PdfWriter.GetInstance(document, new FileStream(pdfSavePath, FileMode.Create));
            
            document.Open();

            foreach (var bytes in imagesBytes)
            {
                var image = Image.GetInstance(bytes);
                image.ScaleToFit(document.PageSize.Width, document.PageSize.Height);

                image.SetAbsolutePosition(0, 0);
                document.Add(image);
                document.NewPage();
            }

            document.Close();
        }
    }
}
