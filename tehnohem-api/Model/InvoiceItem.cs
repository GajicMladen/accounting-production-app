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

        public float? Discount { get; set; }
        public float? Rabat { get; set; }

        public float? SinglePriceNoPdv { get; set; }
        public float? SinglePricePdv { get; set; }

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
        public InvoiceItem(OutgoingInvoiceItemDTO outgoingInvoiceItemDTO, Invoice newInvoice)
        {
            this.Invoice = newInvoice;
            this.Name = outgoingInvoiceItemDTO.name;
            this.TotalValueWithoutPDV = outgoingInvoiceItemDTO.value_out_pdv;
            this.TotalValueOfPDV = outgoingInvoiceItemDTO.value_pdv;
            this.TotalValue = outgoingInvoiceItemDTO.value_total;
            this.Amount = outgoingInvoiceItemDTO.amount;
            this.SinglePrice = outgoingInvoiceItemDTO.price_single;
            this.Unit = outgoingInvoiceItemDTO.unit;
            this.Pdv = outgoingInvoiceItemDTO.pdv;
            this.SinglePriceNoPdv = outgoingInvoiceItemDTO.price_single_no_pdv;
            this.SinglePricePdv = outgoingInvoiceItemDTO.price_single_pdv;
            this.Discount = outgoingInvoiceItemDTO.discount;
            this.Rabat = outgoingInvoiceItemDTO.rabat;
        }
    }
}
