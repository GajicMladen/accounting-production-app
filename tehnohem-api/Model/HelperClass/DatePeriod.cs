namespace tehnohem_api.Model.HelperClass
{
    public class DatePeriod
    {
        public Invoice.Invoice? Invoice { get; set; }
        public DateOnly StartDate {  get; set; }
        public DateOnly EndDate { get; set; }
    }
}
