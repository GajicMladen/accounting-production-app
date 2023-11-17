using tehnohem_api.Model;
using tehnohem_api.Model.Enums;

namespace tehnohem_api.DTO
{
    public class DetailInvoiceInfoDTO
    {
        public string invoiceID { get; set; }
        public InvoiceType invoiceType { get; set; }
        public DateOnly date { get; set; }
        public string supplierID { get; set; }
        public string supplierName { get; set; }
        public string customerID { get; set; }
        public string customerName { get; set; }
        public float valueOutPdv { get; set; }
        public float valuePdv { get; set; }
        public float valueTotal { get; set; }

        public ICollection<IncomingInvoiceItemDTO> items { get; set; }

        public DetailInvoiceInfoDTO() { 
            
        }

        public DetailInvoiceInfoDTO(Invoice invoice) {

            this.invoiceID = invoice.ID;
            this.invoiceType = invoice.InvoiceType;
            this.date = invoice.Date;
            this.supplierID = invoice.SupplierID;
            this.supplierName = invoice.Supplier?.Name;
            this.customerID = invoice.CustomerID;
            this.customerName = invoice.Customer?.Name;
            this.valueOutPdv = invoice.TotalValueWithoutPDV;
            this.valuePdv = invoice.TotalValueOfPDV;
            this.valueTotal = invoice.TotalValue;
            this.items = new List<IncomingInvoiceItemDTO>();
            foreach (InvoiceItem invoiceItem in invoice.InvoiceItems) { 
                this.items.Add(new IncomingInvoiceItemDTO(invoiceItem));
            }
        }
    }
}
