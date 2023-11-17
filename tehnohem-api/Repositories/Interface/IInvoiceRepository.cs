using tehnohem_api.DTO;
using tehnohem_api.Model;

namespace tehnohem_api.Repositories.Interface
{
    public interface IInvoiceRepository
    {
        public void AddNewIncomingInvoice(Invoice newIncomingInvoice);

        public List<Invoice> GetAllIncomingInvoices();
        public List<Invoice> GetAllInternalIssueRaw();

        public Invoice? GetInvoiceFullInfo(string invoiceID);

    }
}
