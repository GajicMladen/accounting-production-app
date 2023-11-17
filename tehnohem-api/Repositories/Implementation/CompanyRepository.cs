using Microsoft.EntityFrameworkCore;
using tehnohem_api.DB;
using tehnohem_api.DTO;
using tehnohem_api.Model;
using tehnohem_api.Model.Enums;
using tehnohem_api.Repositories.Interface;

namespace tehnohem_api.Repositories.Implementation
{
    public class CompanyRepository : ICompanyRepository
    {   
        private PostgresqlContext postgresqlContext;
        private DbSet<Company> companies;
        public CompanyRepository(PostgresqlContext postgresqlContext) {
            this.postgresqlContext = postgresqlContext;
            companies = this.postgresqlContext.companies;
        }
        public void Add(Company entity)
        {
            this.companies.Add(entity);
        }

        public void Delete(Company companyToDelete)
        {
            this.companies.Remove(companyToDelete);
        }

        public void Update(Company updateCompany,CompanyDTO company) {

            updateCompany.Address = company.Address;
            updateCompany.PhoneNumber = company.PhoneNumber;
            updateCompany.Name = company.Name;
            updateCompany.Email = company.Email;
            updateCompany.ContactPerson = company.ContactPerson;
            updateCompany.JIB = company.JIB;
            updateCompany.IB = company.IB;
        }

        public IList<Company> getAllCompanies()
        {
            return this.companies.ToList();
        }

        public IList<Company> getAllCustomerCompanies()
        {
            return this.companies.Where(c => c.companyType == CompanyType.CUSTOMER).ToList();
        }

        public IList<Company> getAllDeliveryPlaces(Company company)
        {
            return this.companies.Where(c => c.HeadCompanyID == company.ID && c.companyType == CompanyType.CUSTOMER_DELIVERY_PLACE ).ToList();
        }

        public IList<Company> getAllSupplierCompanies()
        {
            return this.companies.Where(c => c.companyType == CompanyType.SUPPLIER).ToList();
        }

        public IList<Company> getAllThirdPartyCompanies()
        {
            return this.companies.Where(c => c.companyType == CompanyType.THIRD_PARTY).ToList();
        }

        public Company getById(string companyId)
        {
            return this.companies.Where(c => c.ID == companyId).FirstOrDefault();
        }
    }
}
