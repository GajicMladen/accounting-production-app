using tehnohem_api.DTO;
using tehnohem_api.Model;

namespace tehnohem_api.Services.Interface
{
    public interface IPaymentService
    {
        void addNewPayment(PaymentDTO paymentDTO);
        void deletePayment(string paymentId);
        List<Payment> getAllPaymentsOfIncomingInvoices();
        List<Payment> getAllPaymentsOfThirdParty();
        List<Payment> getAllPaymentsOfOutgoingInvoices();
        List<Payment> getAllPaymentsOfOutgoingCashInvoices();

        List<PaymentDTO> getPaymentDTOs(List<Payment> payments);
    }
}
