using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;

namespace InspimoPdfReports.Controllers
{
    public class ExcelReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CustomerExcelReport()
        {
            var workbook = new XLWorkbook();
            var workSheet = workbook.Worksheets.Add("Müşteri Listesi");
            workSheet.Cell(1, 1).Value = "Müşeri ID";
            workSheet.Cell(1, 2).Value = "Müşeri Adı";
            workSheet.Cell(1, 3).Value = "Müşeri Soyadı";
            workSheet.Cell(1, 4).Value = "Müşeri Şehir";
            workSheet.Cell(2, 1).Value = "1";
            workSheet.Cell(2, 2).Value = "Hakan";
            workSheet.Cell(2, 3).Value = "Doğan";
            workSheet.Cell(2, 4).Value = "Karabük";
            workSheet.Cell(3, 1).Value = "2";
            workSheet.Cell(3, 2).Value = "Ahmet";
            workSheet.Cell(3, 3).Value = "Yıldız";
            workSheet.Cell(3, 4).Value = "Bartın";

            var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();
            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "customerList.xlsx");

        }
    }
}
