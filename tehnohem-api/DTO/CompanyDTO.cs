namespace tehnohem_api.DTO
{
    public class CompanyDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string JIB { get; set; }
        public string IB { get; set; }
        public string Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int CompanyType { get; set; }
        public string? ContactPerson { get; set; }

        public string? HeadCompanyId { get; set; }
    }
}
