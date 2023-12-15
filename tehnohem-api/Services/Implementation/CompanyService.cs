using tehnohem_api.DTO;
using tehnohem_api.Model;
using tehnohem_api.Services.Interface;
using tehnohem_api.UnitOfWork.Interface;

namespace tehnohem_api.Services.Implementation
{
    public class CompanyService : ICompanyService
    {
        private IUnitOfWork unitOfWork;
        public CompanyService(IUnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
        }

        public void addNewCompany(Company company)
        {
            this.unitOfWork.CompanyRepository.Add(company);
            this.unitOfWork.Commit();
        }

        public void deleteCompany(string companyId)
        {
            Company companyToDelete = this.unitOfWork.CompanyRepository.getById(companyId);
            this.unitOfWork.CompanyRepository.Delete(companyToDelete);
            this.unitOfWork.Commit();
        }

        public IList<Company> GetAllCompanies()
        {
            return this.unitOfWork.CompanyRepository.getAllCompanies();
        }

        public IList<Company> GetAllCustomerCompanies()
        {
            return this.unitOfWork.CompanyRepository.getAllCustomerCompanies();
        }

        public IList<Company> GetAllDeliveryPlaces(string companyId)
        {
            Company company = this.unitOfWork.CompanyRepository.getById(companyId);
            return this.unitOfWork.CompanyRepository.getAllDeliveryPlaces(company);
        }

        public IList<Company> GetAllSupplierCompanies()
        {
            return this.unitOfWork.CompanyRepository.getAllSupplierCompanies();
        }

        public IList<Company> GetAllThirdPartyCompanies()
        {
            return this.unitOfWork.CompanyRepository.getAllThirdPartyCompanies();
        }

        public Company GetCompanyById(string companyId)
        {
            return this.unitOfWork.CompanyRepository.getById(companyId);
        }

        public void updateCompany(CompanyDTO companyDTO)
        {
            Company company = this.unitOfWork.CompanyRepository.getById(companyDTO.ID);
            this.unitOfWork.CompanyRepository.Update(company,companyDTO);
            this.unitOfWork.Commit();
        }
    }
}
