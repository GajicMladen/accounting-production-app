using tehnohem_api.DTO;
using tehnohem_api.Model;

namespace tehnohem_api.Services.Interface
{
    public interface ICompanyService
    {
        IList<Company> GetAllCompanies();
        IList<Company> GetAllSupplierCompanies();
        IList<Company> GetAllCustomerCompanies();
        IList<Company> GetAllThirdPartyCompanies();
        IList<Company> GetAllDeliveryPlaces(string companyId);

        Company GetCompanyById(string companyId);
        void addNewCompany(Company company);

        void deleteCompany(string companyId);

        void updateCompany(CompanyDTO company);  

    }
}
