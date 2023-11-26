using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tehnohem_api.DTO;
using tehnohem_api.Model.Enums;
using tehnohem_api.Model.HelperClass;

namespace tehnohem_api.Model
{
    [Table("Invoices")]
    public class Invoice
    {
        [Key]
        public string ID { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public Company? Supplier { get; set; }
        public string? SupplierID { get; set; }
        public Company? Customer { get; set; }
        public string? CustomerID { get; set; }
        public DateOnly Date {  get; set; }
        //public DatePeriod? DatePeriod { get; set; }
        public float TotalValue {  get; set; }
        public float TotalValueOfPDV { get; set; }
        public float TotalValueWithoutPDV { get; set; }

        public ICollection<InvoiceItem> InvoiceItems { get; set; }

        public Invoice() { }
        public Invoice(IncomingInvoiceDTO incomingInvoiceDTO,Company? supplier, Company? customer, InvoiceType invoiceType) {
            this.ID = incomingInvoiceDTO.invoiceID;
            this.Date = incomingInvoiceDTO.Date;
            this.TotalValueWithoutPDV = incomingInvoiceDTO.TotalValueWithoutPDV;
            this.TotalValueOfPDV = incomingInvoiceDTO.TotalValueOfPDV;
            this.TotalValue = incomingInvoiceDTO.TotalValue;
            this.InvoiceType = invoiceType;
            this.SupplierID = supplier?.ID;
            this.Supplier = supplier;
            this.Customer = customer;
            this.CustomerID = customer?.ID;
        }

        public Invoice(OutgoingInvoiceDTO incomingInvoiceDTO, Company? supplier, Company? customer, InvoiceType invoiceType)
        {
            this.ID = incomingInvoiceDTO.InvoiceID;
            this.Date = incomingInvoiceDTO.Date;
            this.TotalValueWithoutPDV = incomingInvoiceDTO.TotalValueWithoutPDV;
            this.TotalValueOfPDV = incomingInvoiceDTO.TotalValueOfPDV;
            this.TotalValue = incomingInvoiceDTO.TotalValue;
            this.InvoiceType = invoiceType;
            this.SupplierID = supplier?.ID;
            this.Supplier = supplier;
            this.Customer = customer;
            this.CustomerID = customer?.ID;
        }
    }
}
