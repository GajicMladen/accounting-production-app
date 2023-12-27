using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tehnohem_api.DTO;
using tehnohem_api.Model.Enums;

namespace tehnohem_api.Model
{
    [Table("payments")]
    public class Payment
    {
        [Key]
        public string PaymentId { get; set; }
        public string PaymentIdSystem { get; set; }

        public PaymentType PaymentType { get; set; }
        public DateOnly Date { get; set; }

        public Company? Payer { get; set; }
        public string? PayerID { get; set; }

        public Company? Receiver{ get; set; }
        public string? ReceiverID { get; set; }  

        public List<PaymentItem> PaymentItems { get; set; }
        public float TotalValue { get; set; }

        public Payment() { }

        public Payment(PaymentDTO paymentDTO) { 
            this.PaymentId = paymentDTO.PaymentId;
            this.TotalValue = paymentDTO.TotalValue;
            this.Date = paymentDTO.Date;
            this.PaymentType = paymentDTO.PaymentType;
        }
    }

    public class PaymentItem {

        public string ID { get; set; }

        public Payment Payment { get; set; }   
        public string PaymentID { get; set; }
        public string name { get; set; }

        public float value { get; set; }

        public PaymentItem() { }

        public PaymentItem(PaymentItemDTO paymentItemDTO) { 
            this.name = paymentItemDTO.name;
            this.value = paymentItemDTO.value;
        }

    }
}
