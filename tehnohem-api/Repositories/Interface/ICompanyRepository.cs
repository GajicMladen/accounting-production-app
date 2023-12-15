using tehnohem_api.DTO;
using tehnohem_api.Model;

namespace tehnohem_api.Repositories.Interface
{
    public interface ICompanyRepository
    {
        IList<Company> getAllCompanies();
        IList<Company> getAllSupplierCompanies();
        IList<Company> getAllCustomerCompanies();
        IList<Company> getAllThirdPartyCompanies();

        IList<Company> getAllDeliveryPlaces(Company company);
        Company getById(string companyId);

        void Add(Company newCompany);
        void Delete(Company companyToDelete);

        void Update(Company company,CompanyDTO newCompanny);
    }
}
