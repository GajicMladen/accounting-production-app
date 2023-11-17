using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using tehnohem_api.Model;
using tehnohem_api.Model.Enums;

namespace tehnohem_api.DTO
{
    public class IncomingInvoiceItemDTO
    {
        public int itemID { get; set; }
        public RawType rawType { get; set; }
        public string name { get; set; }
        public float count { get; set; }
        public string unit{ get; set; }
        public float price_single { get; set; }
        public float pdv {  get; set; }
        public float value_out_pdv { get; set; }
        public float value_pdv { get; set; }
        public float value_total { get; set; }

        public IncomingInvoiceItemDTO() { }
        public IncomingInvoiceItemDTO(InvoiceItem invoiceItem) {
            this.itemID = (int)invoiceItem.itemID;
            this.unit = invoiceItem.Unit;
            this.price_single = invoiceItem.SinglePrice;
            this.value_total = invoiceItem.TotalValue;
            this.value_out_pdv = invoiceItem.TotalValueWithoutPDV;
            this.value_pdv = invoiceItem.TotalValueOfPDV;
            this.count = invoiceItem.Amount;
            this.pdv = invoiceItem.Pdv;
            this.name = invoiceItem.Name;
        }
    }
}
