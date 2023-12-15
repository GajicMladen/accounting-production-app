using tehnohem_api.Model.Enums;
using tehnohem_api.Model;

namespace tehnohem_api.DTO
{
    public class PaymentDTO
    {
        public string PaymentId { get; set; }

        public PaymentType PaymentType { get; set; }
        public DateOnly Date { get; set; }

        public string PayerName { get; set; }
        public string? PayerID { get; set; }

        public string? ReceiverName { get; set; }
        public string? ReceiverID { get; set; }

        public List<PaymentItemDTO> PaymentItems { get; set; }
        public float TotalValue { get; set; }

        public PaymentDTO() { }
        public PaymentDTO(Payment payment) {
            this.PaymentId = payment.PaymentId;
            this.PaymentType = payment.PaymentType;
            this.PayerName = payment.Payer?.Name;
            this.PayerID = payment.PayerID;
            this.ReceiverID = payment.ReceiverID;
            this.ReceiverName = payment.Receiver?.Name;
            this.Date = payment.Date;
            List<PaymentItemDTO> paymentItemDTOs = new List<PaymentItemDTO>();
            foreach (var item in payment.PaymentItems)
            {
                paymentItemDTOs.Add(new PaymentItemDTO(item));
            }
            this.PaymentItems = paymentItemDTOs;
            this.TotalValue = payment.TotalValue;
        }
    }


    public class PaymentItemDTO
    {
        public string ID { get; set; }
        public string name { get; set; }
        public float value { get; set; }

        public PaymentItemDTO() { }
        public PaymentItemDTO(PaymentItem paymentItem) {
            this.ID = paymentItem.ID;
            this.name = paymentItem.name;
            this.value = paymentItem.value;
        }
    }
}
