using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tehnohem_api.Model.Enums;

namespace tehnohem_api.Model
{
    [Table("Raws")]
    public class Raw
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public float SinglePrice { get; set; }
        public float? CurrentAmount { get; set; }
        public float? TotalValue { get; set; }
        public RawType RawType { get; set; }   

    }
}
