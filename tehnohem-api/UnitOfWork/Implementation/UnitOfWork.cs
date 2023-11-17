using Microsoft.EntityFrameworkCore;
using tehnohem_api.DB;
using tehnohem_api.Repositories.Implementation;
using tehnohem_api.Repositories.Interface;
using tehnohem_api.UnitOfWork.Interface;

namespace tehnohem_api.UnitOfWork.Implementation
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public readonly PostgresqlContext _dbContext;
        private bool _disposed;

        private ICompanyRepository _companyRepository = null;
        private IRawRepository _rawRepository = null;
        private IProductRepository _productRepository = null;
        private IInvoiceRepository _invoiceRepository = null;
        public UnitOfWork(PostgresqlContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICompanyRepository CompanyRepository
        {
            get
            {
                if (_companyRepository == null)
                {
                    _companyRepository = new CompanyRepository(_dbContext);
                }
                return _companyRepository;
            }
        }

        public IRawRepository RawRepository
        {
            get {
                if (_rawRepository == null) {
                    _rawRepository = new RawRepository(_dbContext);
                }
                return _rawRepository;
            }
        
        }

        public IProductRepository ProductRepository
        {
            get { 
                if(_productRepository == null)
                {
                    _productRepository = new ProductRepository(_dbContext);
                }
                return _productRepository;
            }
        }

        public IInvoiceRepository InvoiceRepository
        {
            get
            {
                if (_invoiceRepository == null)
                {
                    _invoiceRepository = new InvoiceRepository(_dbContext);
                }
                return _invoiceRepository;
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public void Rollback()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }
        public IRepository<T> Repository<T>() where T : class
        {
            return new Repository<T>(_dbContext);
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
