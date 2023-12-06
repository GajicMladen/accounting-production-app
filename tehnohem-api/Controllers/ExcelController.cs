using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tehnohem_api.Excel;

namespace tehnohem_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        public IExcelService ExcelService;

        public ExcelController(IExcelService excelService)
        {
            this.ExcelService = excelService;
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
    }
}
