using System.ComponentModel.DataAnnotations.Schema;

namespace SavuDiary.Shared
{
    public class TaxRuleModel:Base
    {
       public TaxRule TaxRule { get; set; }
        public List<TaxRuleDetail> TaxRuleDetails { get; set; }
        public TaxRuleModel() {

            TaxRule = new TaxRule();
            TaxRuleDetails = new List<TaxRuleDetail>();
        }
    }
}
