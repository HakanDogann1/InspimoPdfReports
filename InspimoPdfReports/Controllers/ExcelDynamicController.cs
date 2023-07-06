using ClosedXML.Excel;
using InspimoPdfReports.DAL;
using Microsoft.AspNetCore.Mvc;

namespace InspimoPdfReports.Controllers
{
    public class ExcelDynamicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ExcelDynamic()
        {
            using var context = new Context();
            var customerList = context.Customers.ToList();
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Müşteri Listesi");
            var customerListLength = customerList.Count() + 1;
            worksheet.Cell(1, 1).Value = "CustomerID";
            worksheet.Cell(1, 2).Value = "CustomerName";
            worksheet.Cell(1, 3).Value = "CustomerSurname";
            worksheet.Cell(1, 4).Value = "CustomerCity";
            int j = 2;
            foreach (var item in customerList)
                {
               
                worksheet.Cell(j, 1).Value = item.CustomerID;
                worksheet.Cell(j, 2).Value = item.CustomerName;
                worksheet.Cell(j, 3).Value = item.CustomerSurname;
                worksheet.Cell(j, 4).Value = item.CustomerCity;
                j++;
                }

            var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();
            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "customerList.xlsx");


        }
    }
}
