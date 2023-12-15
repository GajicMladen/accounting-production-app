using Microsoft.EntityFrameworkCore;
using tehnohem_api.DB;
using tehnohem_api.Model;
using tehnohem_api.Model.Enums;
using tehnohem_api.Model.Invoice;
using tehnohem_api.Repositories.Interface;

namespace tehnohem_api.Repositories.Implementation
{
    public class PaymentRepository : IPaymentRepository
    {
        private PostgresqlContext postgresqlContext;
        private DbSet<Payment> payments;

        public PaymentRepository(PostgresqlContext postgresqlContext)
        {
            this.postgresqlContext = postgresqlContext;
            this.payments = this.postgresqlContext.payments;
        }

        public void addNewPayment(Payment payment)
        {
            this.payments.Add(payment);
        }

        public void deletePayment(Payment payment)
        {
            this.payments.Remove(payment);
        }

        public List<Payment> getAllPayments()
        {
            return this.payments.Include(p => p.Receiver).Include(p => p.Payer).Include(p => p.PaymentItems).ToList();
        }

        public List<Payment> getAllPaymentsOfIncomingInvoices()
        {
            return this.payments.Where( p => p.PaymentType == PaymentType.INCOMING_INVOICE_PAYMENT ).Include(p => p.Receiver).Include(p => p.Payer).Include(p => p.PaymentItems).ToList();
        }

        public List<Payment> getAllPaymentsOfOutgoingCashInvoices()
        {
            return this.payments.Where(p => p.PaymentType == PaymentType.OUTGOING_INVOICE_CASH_PAYMENT).Include(p => p.Receiver).Include(p => p.Payer).Include(p => p.PaymentItems).ToList();
        }

        public List<Payment> getAllPaymentsOfOutgoingInvoices()
        {
            return this.payments.Where(p => p.PaymentType == PaymentType.OUTGOING_INVOICE_PAYMENT).Include(p => p.Receiver).Include(p => p.Payer).Include(p => p.PaymentItems).ToList();
        }

        public List<Payment> getAllPaymentsOfThirdParty()
        {
            return this.payments.Where(p => p.PaymentType == PaymentType.THIRD_PARTY_COST_PAYMENT).Include(p => p.Receiver).Include(p => p.Payer).Include(p => p.PaymentItems).ToList();
        }

        public Payment? getPayment(string paymentId)
        {
            return this.payments.Where(p => p.PaymentId == paymentId).FirstOrDefault();
        }
    }
}
