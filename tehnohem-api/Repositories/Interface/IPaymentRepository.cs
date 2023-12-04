using tehnohem_api.Model;

namespace tehnohem_api.Repositories.Interface
{
    public interface IPaymentRepository
    {
        void addNewPayment(Payment payment);

        void deletePayment(Payment payment);

        Payment? getPayment(string paymentId);
        List<Payment> getAllPayments();

        List<Payment> getAllPaymentsOfIncomingInvoices();
        List<Payment> getAllPaymentsOfThirdParty();
        List<Payment> getAllPaymentsOfOutgoingInvoices();
        List<Payment> getAllPaymentsOfOutgoingCashInvoices();

    }
}
