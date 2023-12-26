using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using tehnohem_api.Model.Invoice;

namespace tehnohem_api.Excel
{
    public interface IExcelService
    {

        public XLWorkbook gnerateXMLFile();
        public XLWorkbook gnerateXMLFile(Invoice invoice);
    }
}
