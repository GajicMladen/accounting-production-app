using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using tehnohem_api.Model.Enums;
using tehnohem_api.Model.Invoice;

namespace tehnohem_api.Model
{
    [Table("Company")]
    public class Company
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        public string JIB { get; set; }
        public string IB { get; set; }
        public string Address { get; set; }   
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ContactPerson { get; set; }
        public CompanyType companyType { get; set; }
        [JsonIgnore]
        public ICollection<Company> ?  DeliveryPlaces{ get; set; }
        [JsonIgnore]
        public Company? HeadCompany { get; set; }
        public string ? HeadCompanyID { get; set; }

        public virtual ICollection<Invoice.Invoice>? Invoices_Supplier { get; set; }
        public virtual ICollection<Invoice.Invoice>? Invoices_Customer { get; set; }

        public virtual ICollection<Payment>? Payments_Payer { get; set; }
        public virtual ICollection<Payment>? Payments_Receiver{ get; set; }

    }
}
