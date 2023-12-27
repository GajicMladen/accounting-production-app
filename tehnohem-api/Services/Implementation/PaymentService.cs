using tehnohem_api.DTO;
using tehnohem_api.Model;
using tehnohem_api.Services.Interface;
using tehnohem_api.UnitOfWork.Interface;

namespace tehnohem_api.Services.Implementation
{
    public class PaymentService : IPaymentService
    {
        private IUnitOfWork unitOfWork;

        public PaymentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void addNewPayment(PaymentDTO paymentDTO)
        {
            Payment newPayment = new Payment(paymentDTO);
            List<PaymentItem> paymentItems = new List<PaymentItem>();
            foreach (var item in paymentDTO.PaymentItems)
            {
                PaymentItem newPaymentItem = new PaymentItem(item);
                newPaymentItem.Payment = newPayment;
                paymentItems.Add(newPaymentItem);
            }
            newPayment.PaymentItems = paymentItems;
            Company? payer = this.unitOfWork.CompanyRepository.getById(paymentDTO.PayerID);
            Company? receiver = this.unitOfWork.CompanyRepository.getById(paymentDTO.ReceiverID);

            newPayment.Payer = payer;
            newPayment.Receiver = receiver;
            newPayment.PaymentIdSystem = Guid.NewGuid().ToString();

            this.unitOfWork.PaymentRepository.addNewPayment(newPayment);
            this.unitOfWork.Commit();

        }

        public void deletePayment(string paymentId)
        {
            Payment? payment = this.unitOfWork.PaymentRepository.getPayment(paymentId);
            if (payment != null) {
                this.unitOfWork.PaymentRepository.deletePayment(payment);
                this.unitOfWork.Commit();
            }
        }

        public List<Payment> getAllPaymentsOfIncomingInvoices()
        {
            return this.unitOfWork.PaymentRepository.getAllPaymentsOfIncomingInvoices();
        }

        public List<Payment> getAllPaymentsOfOutgoingCashInvoices()
        {
            return this.unitOfWork.PaymentRepository.getAllPaymentsOfOutgoingCashInvoices();
        }

        public List<Payment> getAllPaymentsOfOutgoingInvoices()
        {
            return this.unitOfWork.PaymentRepository.getAllPaymentsOfOutgoingInvoices();
        }

        public List<Payment> getAllPaymentsOfThirdParty()
        {
            return this.unitOfWork.PaymentRepository.getAllPaymentsOfThirdParty();
        }

        public List<PaymentDTO> getPaymentDTOs(List<Payment> payments)
        {
            List<PaymentDTO> paymentDTOs = new List<PaymentDTO>();
            foreach (Payment payment in payments)
            {
                paymentDTOs.Add(new PaymentDTO(payment));
            }
            return paymentDTOs;
        }
    }
}
