using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tehnohem_api.DTO;
using tehnohem_api.Model.Enums;

namespace tehnohem_api.Model.Invoice
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
        public DateOnly Date { get; set; }
        //public DatePeriod? DatePeriod { get; set; }
        public float TotalValue { get; set; }
        public float TotalValueOfPDV { get; set; }
        public float TotalValueWithoutPDV { get; set; }

        public ICollection<InvoiceItem> InvoiceItems { get; set; }

        public Invoice() { }
        public Invoice(IncomingInvoiceDTO incomingInvoiceDTO, Company? supplier, Company? customer, InvoiceType invoiceType)
        {
            ID = incomingInvoiceDTO.invoiceID;
            Date = incomingInvoiceDTO.Date;
            TotalValueWithoutPDV = incomingInvoiceDTO.TotalValueWithoutPDV;
            TotalValueOfPDV = incomingInvoiceDTO.TotalValueOfPDV;
            TotalValue = incomingInvoiceDTO.TotalValue;
            InvoiceType = invoiceType;
            SupplierID = supplier?.ID;
            Supplier = supplier;
            Customer = customer;
            CustomerID = customer?.ID;
        }

        public Invoice(OutgoingInvoiceDTO incomingInvoiceDTO, Company? supplier, Company? customer, InvoiceType invoiceType)
        {
            ID = incomingInvoiceDTO.InvoiceID;
            Date = incomingInvoiceDTO.Date;
            TotalValueWithoutPDV = incomingInvoiceDTO.TotalValueWithoutPDV;
            TotalValueOfPDV = incomingInvoiceDTO.TotalValueOfPDV;
            TotalValue = incomingInvoiceDTO.TotalValue;
            InvoiceType = invoiceType;
            SupplierID = supplier?.ID;
            Supplier = supplier;
            Customer = customer;
            CustomerID = customer?.ID;
        }
    }
}
