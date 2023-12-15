using tehnohem_api.Model.Enums;
using tehnohem_api.Model;

namespace tehnohem_api.DTO
{
    public class OutgoingInvoiceDTO
    {
        public string InvoiceID { get; set; }
        public string BuyerID { get; set; }
        public DateOnly Date { get; set; }
        public float TotalValue { get; set; }
        public float TotalValueOfPDV { get; set; }
        public float TotalValueWithoutPDV { get; set; }

        public ICollection<OutgoingInvoiceItemDTO> InvoiceItems { get; set; }


    }
}
