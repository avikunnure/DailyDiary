using SavuDiary.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavuDiary.Server.DataLayers
{
    public class TaxRulesEntity : BaseEntity
    {
        [Required]
        public string RuleName { get; set; } = "";
        [Required]
        public decimal TaxPercentage { get; set; }
        [Required]
        public string TaxType { get; set; } = "";
        public string Descriptions { get; set; } = "";


        public static implicit operator TaxRulesEntity(TaxRule taxRule)
        {
            return new TaxRulesEntity()
            {
                TaxType=taxRule.TaxType,
                TaxPercentage=taxRule.TaxPercentage,
                Descriptions=taxRule.Descriptions,
                RuleName=taxRule.RuleName,
                Id = taxRule.Id,
                IsActive = taxRule.IsActive,
            };
        }

        public static implicit operator TaxRule(TaxRulesEntity taxRule)
        {
            return new TaxRule()
            {
                TaxType = taxRule.TaxType,
                TaxPercentage = taxRule.TaxPercentage,
                Descriptions = taxRule.Descriptions,
                RuleName = taxRule.RuleName,
                Id = taxRule.Id,
                IsActive = taxRule.IsActive,
            };
        }
    }
}
