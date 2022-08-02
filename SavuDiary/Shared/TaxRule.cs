using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SavuDiary.Shared
{
    public class TaxRule:Base
    {
        [Required]
        public string RuleName { get; set; } = "";
        [Required]
        public decimal TaxPercentage { get; set; }
        [Required]
        public string TaxType { get; set; } = "";
        public string Descriptions { get; set; } = "";
    }
}
