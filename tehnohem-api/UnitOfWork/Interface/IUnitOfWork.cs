using tehnohem_api.Repositories.Interface;

namespace tehnohem_api.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();

        ICompanyRepository CompanyRepository { get; }

        IRawRepository RawRepository { get; }

        IProductRepository ProductRepository { get; }

        IInvoiceRepository InvoiceRepository { get; }

        IPaymentRepository PaymentRepository { get; }
    }
}
