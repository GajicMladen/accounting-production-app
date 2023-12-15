using Microsoft.AspNetCore.Mvc;
using tehnohem_api.DTO;
using tehnohem_api.Model;
using tehnohem_api.Model.Enums;
using tehnohem_api.Services.Interface;
using tehnohem_api.UnitOfWork.Interface;

namespace tehnohem_api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class CompanyController : ControllerBase
    {
        private ICompanyService companyService;
        public CompanyController(ICompanyService companyService) {
            this.companyService = companyService;
        }

        [HttpGet(Name ="All")]
        public ICollection<Company> getAllCompanies() { 
            
            return this.companyService.GetAllCompanies();
        }


        [HttpGet("suppliers")]
        public ICollection<Company> getAllSupplierCompanies()
        {

            return this.companyService.GetAllSupplierCompanies();
        }
        [HttpGet("customers")]
        public ICollection<Company> getAllCustomerCompanies()
        {

            return this.companyService.GetAllCustomerCompanies();
        }
        [HttpGet("thirdPartyCompanies")]
        public ICollection<Company> getAllThirdPartyCompanies()
        {

            return this.companyService.GetAllThirdPartyCompanies();
        }

        [HttpPost("addNewCompany")]
        public IActionResult addNewCompany(CompanyDTO companyDTO)
        {
            Company newCompany = new Company()
            {
                Name = companyDTO.Name,
                PhoneNumber = companyDTO.PhoneNumber,
                Address = companyDTO.Address,
                Email = companyDTO.Email,
                IB = companyDTO.IB ,
                JIB =  companyDTO.JIB,
                ContactPerson = companyDTO.ContactPerson
            };
            if (companyDTO.CompanyType == 0)
                newCompany.companyType = CompanyType.SUPPLIER;
            else if (companyDTO.CompanyType == 1)
                newCompany.companyType = CompanyType.CUSTOMER;
            else if (companyDTO.CompanyType == 2)
            {
                newCompany.companyType = CompanyType.CUSTOMER_DELIVERY_PLACE;
                newCompany.HeadCompanyID = companyDTO.HeadCompanyId;
                newCompany.HeadCompany = this.companyService.GetCompanyById(companyDTO.HeadCompanyId);
            }
            else
                newCompany.companyType = CompanyType.THIRD_PARTY;

            this.companyService.addNewCompany(newCompany);

            return Ok();
        }

        [HttpDelete("deleteCompany/{id}")]
        public IActionResult deleteCompany(string id) {
            this.companyService.deleteCompany(id);
            return Ok();
        }

        [HttpGet("deliveryPlaces/{id}")]
        public ICollection<Company> getDeliveryPlaces(string id) { 
            return this.companyService.GetAllDeliveryPlaces(id);
        }

        [HttpPost("update")]
        public IActionResult updateCompany(CompanyDTO company) {

            this.companyService.updateCompany(company);

            return Ok();
        }

        [HttpGet("info/{id}")]
        public Company GetCompany(string id)
        {
            return this.companyService.GetCompanyById(id);
        }
    }
}
