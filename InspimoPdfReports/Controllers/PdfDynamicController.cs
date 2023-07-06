using InspimoPdfReports.DAL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Utilities;
using System.Text;

namespace InspimoPdfReports.Controllers
{
    public class PdfDynamicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PdfDynamic()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dynamicfile.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            using var context = new Context();
            var length = context.Customers.Count() +1;
            PdfPTable pdfPTable = new PdfPTable(length);
            pdfPTable.AddCell("Id");
            pdfPTable.AddCell("Ad");
            pdfPTable.AddCell("Soyad");
            pdfPTable.AddCell("Şehir");
            foreach ( var c in context.Customers)
            {
                pdfPTable.AddCell(c.CustomerID.ToString());
                pdfPTable.AddCell(c.CustomerName.ToString());
                pdfPTable.AddCell(c.CustomerSurname.ToString());
                pdfPTable.AddCell(c.CustomerCity.ToString());
            }
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            document.Add(pdfPTable);
            document.Close();
            return File("/pdfreports/dynamicfile.pdf/", "application/pdf", "dynamicfile.pdf");
        }



    }
}
