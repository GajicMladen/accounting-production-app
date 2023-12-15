using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;

namespace tehnohem_api.Excel
{
    public interface IExcelService
    {

        public XLWorkbook gnerateXMLFile();
    }
}
