using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tehnohem_api.Excel;
using tehnohem_api.Model.Invoice;
using tehnohem_api.Services.Interface;

namespace tehnohem_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        public IExcelService ExcelService;
        public IInvoicesService InvoicesService;

        public ExcelController(IExcelService excelService, IInvoicesService invoicesService)
        {
            this.ExcelService = excelService;
            this.InvoicesService = invoicesService;
        }


        [HttpGet("getFile")]
        public IActionResult saveFile() {

            XLWorkbook workbook = this.ExcelService.gnerateXMLFile();
            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                var content = stream.ToArray();
                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "test.xlsx");
            }

        }

        [HttpGet("getInvoiceFile/{id}")]
        public IActionResult getInvoiceFile(string id)
        {

            Invoice invoice = this.InvoicesService.GetInvoice(id);

            XLWorkbook workbook = this.ExcelService.gnerateXMLFile(invoice);
            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                var content = stream.ToArray();
                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "test.xlsx");
            }

        }
    }
}
