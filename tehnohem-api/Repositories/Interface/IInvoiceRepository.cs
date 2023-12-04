using tehnohem_api.DTO;
using tehnohem_api.Model.Invoice;

namespace tehnohem_api.Repositories.Interface
{
    public interface IInvoiceRepository
    {
        public void AddNewInvoice(Invoice newIncomingInvoice);

        public void DeleteInvoice(Invoice invoice);

        public List<Invoice> GetAllIncomingInvoices();
        public List<Invoice> GetAllIncomingOtherInvoices();
        public List<Invoice> GetAllOutgoingInvoices();
        public List<Invoice> GetAllInternalIssueRaw();
        public List<Invoice> GetAllInternalIssueProduct();

        public Invoice? GetInvoiceFullInfo(string invoiceID);

    }
}
