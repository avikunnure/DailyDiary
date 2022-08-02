using SavuDiary.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavuDiary.Server.DataLayers
{
    public class TaxRuleDetailsEntity : BaseEntity
    {
        [ForeignKey("TaxRule")]
        public Guid TaxRuleId { get; set; }
        public virtual TaxRulesEntity TaxRule { get; set; }

        [Required]
        public string PerticularNames { get; set; } = "";
        [Required]
        public decimal TaxPercentage { get; set; }
        public string? Descriptions { get; set; }


        public static implicit operator TaxRuleDetailsEntity(TaxRuleDetail taxRuleDetail)
        {
            return new TaxRuleDetailsEntity()
            {
              Descriptions=taxRuleDetail.Descriptions,
              PerticularNames=taxRuleDetail.PerticularNames,
              TaxPercentage=taxRuleDetail.TaxPercentage,
              TaxRuleId=taxRuleDetail.TaxRuleId,

                Id = taxRuleDetail.Id,
                IsActive = taxRuleDetail.IsActive,
            };
        }

        public static implicit operator TaxRuleDetail(TaxRuleDetailsEntity taxRuleDetail)
        {
            return new TaxRuleDetail()
            {
                Descriptions = taxRuleDetail.Descriptions,
                PerticularNames = taxRuleDetail.PerticularNames,
                TaxPercentage = taxRuleDetail.TaxPercentage,
                TaxRuleId = taxRuleDetail.TaxRuleId,

                Id = taxRuleDetail.Id,
                IsActive = taxRuleDetail.IsActive,
            };
        }
    }
}
