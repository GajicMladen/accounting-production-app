using tehnohem_api.DTO;
using tehnohem_api.Model;

namespace tehnohem_api.Repositories.Interface
{
    public interface IInvoiceRepository
    {
        public void AddNewInvoice(Invoice newIncomingInvoice);

        public List<Invoice> GetAllIncomingInvoices();
        public List<Invoice> GetAllOutgoingInvoices();
        public List<Invoice> GetAllInternalIssueRaw();
        public List<Invoice> GetAllInternalIssueProduct();

        public Invoice? GetInvoiceFullInfo(string invoiceID);

    }
}
