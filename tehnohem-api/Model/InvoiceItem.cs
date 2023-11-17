using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using tehnohem_api.DTO;

namespace tehnohem_api.Model
{
    public class InvoiceItem
    {
        [Key]
        public string ID { get; set; }

        public int? itemID { get; set; }

        [JsonIgnore]
        public Invoice Invoice {  get; set; }
        public string InvoiceID { get; set; }
        public string Name { get; set; }
        public string? Unit { get; set; }

        public float SinglePrice { get; set; }
        public float Amount { get; set; }

        public float Pdv { get; set; }
        public float TotalValue { get; set; }
        public float TotalValueOfPDV { get; set; }
        public float TotalValueWithoutPDV { get; set; }

        public InvoiceItem() { }
        public InvoiceItem(IncomingInvoiceItemDTO incomingInvoiceItemDTO,Invoice newInvoice) {
            this.Invoice = newInvoice;
            this.Name = incomingInvoiceItemDTO.name;
            this.TotalValueWithoutPDV = incomingInvoiceItemDTO.value_out_pdv;
            this.TotalValueOfPDV = incomingInvoiceItemDTO.value_pdv;
            this.TotalValue = incomingInvoiceItemDTO.value_total;
            this.Amount = incomingInvoiceItemDTO.count;
            this.SinglePrice = incomingInvoiceItemDTO.price_single;
            this.Unit = incomingInvoiceItemDTO.unit;
            this.Pdv = incomingInvoiceItemDTO.pdv;
        }

    }
}
