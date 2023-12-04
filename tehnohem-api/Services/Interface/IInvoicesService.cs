using tehnohem_api.DTO;
using tehnohem_api.Model.Invoice;

namespace tehnohem_api.Services.Interface
{
    public interface IInvoicesService
    {
        List<Invoice> GetAllIncomingInvoices();
        List<Invoice> GetAllIncomingOtherInvoices();
        List<Invoice> GetAllInternalIssueRaw();
        List<Invoice> GetAllInternalIssueProduct();
        List<Invoice> GetAllOutgoingInvoices();
        List<Invoice> GetAllOutgoingCashInvoices();

        void DeleteInvoice(string invoiceID);

        void AddNewIncomingInvoice(IncomingInvoiceDTO newIncomingInvoice);
        void AddNewIncomingOtherInvoice(IncomingInvoiceDTO newIncomingInvoice);
        void AddNewInternalIssueRaw(IncomingInvoiceDTO newIncomingInvoice);
        void AddNewInternalIssueProduct(IncomingInvoiceDTO newIncomingInvoice);

        void AddNewOutgoingInvoice(OutgoingInvoiceDTO newIncomingInvoice);

        List<GeneralInvoiceInfoDTO> GetGeneralInvoicesInfo(List<Invoice> invoices);
        List<DetailInvoiceInfoDTO> GetDetailInvoicesInfo(List<Invoice> invoices);

        DetailInvoiceInfoDTO GetIncomingInvoice(string invoiceID);
    }
}
