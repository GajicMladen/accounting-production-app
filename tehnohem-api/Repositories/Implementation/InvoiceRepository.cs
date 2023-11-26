using Microsoft.EntityFrameworkCore;
using tehnohem_api.DB;
using tehnohem_api.DTO;
using tehnohem_api.Model;
using tehnohem_api.Model.Enums;
using tehnohem_api.Repositories.Interface;

namespace tehnohem_api.Repositories.Implementation
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private PostgresqlContext postgresqlContext;
        private DbSet<Invoice> invoices;

        public InvoiceRepository(PostgresqlContext postgresqlContext)
        {
            this.postgresqlContext = postgresqlContext;
            this.invoices = this.postgresqlContext.invoices;
        }

        public void AddNewInvoice(Invoice newInvoice)
        {
            this.invoices.Add(newInvoice);
        }

        public List<Invoice> GetAllIncomingInvoices()
        {
            return this.invoices.Where(i => i.InvoiceType == InvoiceType.INCOMING_INVOICE)
                .Include(ii => ii.InvoiceItems)
                .Include(ii => ii.Supplier)
                .Include(ii => ii.Customer)
                .ToList();
        }

        public List<Invoice> GetAllInternalIssueProduct()
        {
            return this.invoices.Where(i => i.InvoiceType == InvoiceType.INTERNAL_ISSUE_PRODUCT)
                .Include(ii => ii.InvoiceItems)
                .Include(ii => ii.Supplier)
                .Include(ii => ii.Customer)
                .ToList();
        }

        public List<Invoice> GetAllInternalIssueRaw()
        {
            return this.invoices.Where(i => i.InvoiceType == InvoiceType.INTERNAL_ISSUE_RAW)
                .Include(ii => ii.InvoiceItems)
                .Include(ii => ii.Supplier)
                .Include(ii => ii.Customer)
                .ToList();
        }

        public List<Invoice> GetAllOutgoingInvoices()
        {
            return this.invoices.Where(i => i.InvoiceType == InvoiceType.OUTGOING_INVOICE)
                .Include(ii => ii.InvoiceItems)
                .Include(ii => ii.Supplier)
                .Include(ii => ii.Customer)
                .ToList();
        }

        public Invoice? GetInvoiceFullInfo(string invoiceID) {
            return this.invoices.Where(i => i.ID == invoiceID)
                .Include(i => i.Customer)
                .Include(i => i.Supplier)
                .Include(i => i.InvoiceItems)
                .FirstOrDefault();
        }
    }
}
