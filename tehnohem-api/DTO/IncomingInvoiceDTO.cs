using tehnohem_api.Model.Enums;
using tehnohem_api.Model;

namespace tehnohem_api.DTO
{
    public class IncomingInvoiceDTO
    {
        public string invoiceID { get; set; }
        public string SupplierID { get; set; }
        public DateOnly Date { get; set; }
        public float TotalValue { get; set; }
        public float TotalValueOfPDV { get; set; }
        public float TotalValueWithoutPDV { get; set; }

        public ICollection<IncomingInvoiceItemDTO> InvoiceItems { get; set; }


    }
}
