using tehnohem_api.DTO;
using tehnohem_api.Model;

namespace tehnohem_api.Services.Interface
{
    public interface IInvoicesService
    {
        List<Invoice> GetAllIncomingInvoices();
        List<Invoice> GetAllInternalIssueRaw();
        List<Invoice> GetAllOutgoingInvoices();
        List<Invoice> GetAllOutgoingCashInvoices();

        void AddNewIncomingInvoice(IncomingInvoiceDTO newIncomingInvoice);
        void AddNewInternalIssueRaw(IncomingInvoiceDTO newIncomingInvoice);

        List<GeneralInvoiceInfoDTO> GetGeneralInvoicesInfo(List<Invoice> invoices);
        List<DetailInvoiceInfoDTO> GetDetailInvoicesInfo(List<Invoice> invoices);

        DetailInvoiceInfoDTO GetIncomingInvoice(string invoiceID);
    }
}
