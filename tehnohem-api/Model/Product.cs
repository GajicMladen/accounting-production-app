using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tehnohem_api.Model
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public string BarCode { get; set; }
        public string Name { get; set; }
        public string Volume { get; set; }
        public float SinglePrice { get; set; }
        public float CurrentAmount { get; set; }
        public float TotalValue { get; set; }

        public Product() { }

        public Product(Product x) {
            this.ID = x.ID;
            this.BarCode = x.BarCode;
            this.Name = x.Name;
            this.Volume = x.Volume;
            this.SinglePrice = x.SinglePrice;
            this.CurrentAmount = x.CurrentAmount;
            this.TotalValue = x.TotalValue;
        }
    }
}
