using tehnohem_api.Model.Invoice;

namespace tehnohem_api.DTO
{
    public class GeneralInvoiceInfoDTO
    {
        public string invoiceID{get;set; }
        public string invoiceIDSystem { get; set; }
        public DateOnly date {get;set;}
        public string supplierName{get;set;}
        public string customerName{get;set;}
        public float valueOutPdv{get;set;}
        public float valuePdv {get;set;}
        public float valueTotal { get; set; }

        public GeneralInvoiceInfoDTO() { }

        public GeneralInvoiceInfoDTO(Invoice invoice) {
            this.invoiceIDSystem = invoice.ID;
            this.invoiceID = invoice.companyInvoiceID;
            this.date = invoice.Date;
            this.supplierName = invoice.Supplier?.Name;
            this.customerName = invoice.Customer?.Name;
            this.valueOutPdv = invoice.TotalValueWithoutPDV;
            this.valuePdv = invoice.TotalValueOfPDV;
            this.valueTotal = invoice.TotalValue;
        }
    }
}
