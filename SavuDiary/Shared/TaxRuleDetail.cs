using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SavuDiary.Shared
{
    public class TaxRuleDetail : Base
    {
        public Guid TaxRuleId { get; set; }

        [Required]
        public string PerticularNames { get; set; } = "";
        [Required]
        public decimal TaxPercentage { get; set; }
        public string? Descriptions { get; set; }
    }
}
