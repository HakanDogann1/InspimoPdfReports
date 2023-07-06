using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace InspimoPdfReports.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "file1.pdf");
            var stream = new FileStream(path,FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            Paragraph paragraph = new Paragraph("Raporumuz Hazırlandı");
            document.Add(paragraph);
            document.Close();
            return File("/pdfreports/file1.pdf/","application/pdf","file1.pdf");
        }

        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "file2.pdf");
            var stream = new FileStream(path,FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            PdfPTable pdfPTable = new PdfPTable(3);
            pdfPTable.AddCell("Müşteri Adı");
            pdfPTable.AddCell("Müşteri Soyadı");
            pdfPTable.AddCell("Müşteri Şehri");
            pdfPTable.AddCell("Ahmet");
            pdfPTable.AddCell("Yıldız");
            pdfPTable.AddCell("İstanbul");
            pdfPTable.AddCell("Hakan");
            pdfPTable.AddCell("Doğan");
            pdfPTable.AddCell("Karabük");
            pdfPTable.AddCell("Faruk");
            pdfPTable.AddCell("Yıldız");
            pdfPTable.AddCell("Ankara");

            document.Add(pdfPTable);
            document.Close();
            return File("/pdfreports/file2.pdf/", "application/pdf", "file2.pdf");
        }
    }
}
