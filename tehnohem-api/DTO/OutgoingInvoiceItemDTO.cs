using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using tehnohem_api.Model;

namespace tehnohem_api.DTO
{
    public class OutgoingInvoiceItemDTO
    {
        public int productId { get; set; }
        public string name { get; set; }
        public float amount { get; set; }
        public string unit{ get; set; }
        public float price_single { get; set; }
        public float? discount { get; set; }
        public float? rabat { get;set; }

        public float pdv {  get; set; }
        public float value_out_pdv { get; set; }
        public float value_pdv { get; set; }
        public float value_total { get; set; }

        public float? price_single_no_pdv { get; set; }
        public float? price_single_pdv { get; set; }

        public OutgoingInvoiceItemDTO() { }
        public OutgoingInvoiceItemDTO(InvoiceItem invoiceItem) {
            this.productId = (int)invoiceItem.itemID;
            this.unit = invoiceItem.Unit;
            this.price_single = invoiceItem.SinglePrice;
            this.value_total = invoiceItem.TotalValue;
            this.value_out_pdv = invoiceItem.TotalValueWithoutPDV;
            this.value_pdv = invoiceItem.TotalValueOfPDV;
            this.amount = invoiceItem.Amount;
            this.pdv = invoiceItem.Pdv;
            this.name = invoiceItem.Name;
            this.price_single_no_pdv = invoiceItem.SinglePriceNoPdv;
            this.price_single_pdv = invoiceItem.SinglePricePdv;
            this.discount = invoiceItem.Discount;
            this.rabat = invoiceItem.Rabat;

        }
    }
}
