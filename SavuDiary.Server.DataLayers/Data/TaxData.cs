using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavuDiary.Server.DataLayers.Data
{
    public static class TaxData
    {
        private const decimal first = 5;
        private const decimal second = 12;
        private const decimal third = 18;
        private const decimal fourth = 28;

        public static IEnumerable<TaxRulesEntity> TaxRules
        {
            get
            {
                return new List<TaxRulesEntity>()
                {
                    new TaxRulesEntity(){  Id=Guid.Parse("BCEF795A-159F-40DC-A906-BD022C7A3070"), Descriptions="TaxFree", IsActive=true, RuleName="FREE",TaxPercentage=0,TaxType="0" },
                    new TaxRulesEntity(){  Id=Guid.Parse("E5B7FF14-7CB1-4956-9E0E-B98E74FC593C"), Descriptions="5", IsActive=true, RuleName="5",TaxPercentage=5,TaxType="5" },
                    new TaxRulesEntity(){  Id=Guid.Parse("B53D0455-197E-465E-AA18-D20EEAAE8415"), Descriptions="12", IsActive=true, RuleName="12",TaxPercentage=12,TaxType="12" },
                    new TaxRulesEntity(){  Id=Guid.Parse("29869748-E7BE-4570-9BAF-28281FDCEDD9"), Descriptions="18", IsActive=true, RuleName="18",TaxPercentage=18,TaxType="18" },
                    new TaxRulesEntity(){  Id=Guid.Parse("260C617B-822D-4C87-A079-82E5CC30E899"), Descriptions="28", IsActive=true, RuleName="28",TaxPercentage=28,TaxType="28" },

                };
            }
        }

        public static IEnumerable<TaxRuleDetailsEntity> TaxRuleDetails
        {
            get
            {
                return new List<TaxRuleDetailsEntity>() {
                    new TaxRuleDetailsEntity(){ Id = Guid.Parse("046D1252-E445-4A54-95A5-6509E16BE04E"), PerticularNames="CGST", Descriptions ="CGST", TaxRuleId=Guid.Parse("E5B7FF14-7CB1-4956-9E0E-B98E74FC593C"),TaxPercentage=first/2 },
                    new TaxRuleDetailsEntity(){ Id = Guid.Parse("FF4061C1-6789-4608-A5A7-231E85750342"), PerticularNames="SGST", Descriptions ="SGST", TaxRuleId=Guid.Parse("E5B7FF14-7CB1-4956-9E0E-B98E74FC593C"),TaxPercentage=first/2 },
                    new TaxRuleDetailsEntity(){ Id = Guid.Parse("7A62A5E0-3D03-4265-9D83-15C93B275CBD"), PerticularNames="IGST", Descriptions ="IGST", TaxRuleId=Guid.Parse("E5B7FF14-7CB1-4956-9E0E-B98E74FC593C"),TaxPercentage=first/2 },

                    new TaxRuleDetailsEntity(){ Id = Guid.Parse("49DB3A14-B001-40C7-9935-7BEE1D59F856"), PerticularNames="CGST", Descriptions ="CGST", TaxRuleId=Guid.Parse("B53D0455-197E-465E-AA18-D20EEAAE8415"),TaxPercentage=second/2 },
                    new TaxRuleDetailsEntity(){ Id = Guid.Parse("9FF082B3-5C51-43FB-8EBA-EC9B61734A2F"), PerticularNames="SGST", Descriptions ="SGST", TaxRuleId=Guid.Parse("B53D0455-197E-465E-AA18-D20EEAAE8415"),TaxPercentage=second/2 },
                    new TaxRuleDetailsEntity(){ Id = Guid.Parse("F253BA7C-E982-4537-9CD8-CE6791C4F13D"), PerticularNames="IGST", Descriptions ="IGST", TaxRuleId=Guid.Parse("B53D0455-197E-465E-AA18-D20EEAAE8415"),TaxPercentage=second/2 },

                    new TaxRuleDetailsEntity(){ Id = Guid.Parse("2F3CF2C9-EA9F-4EA9-B118-C28BB1896AFD"), PerticularNames="CGST", Descriptions ="CGST", TaxRuleId=Guid.Parse("29869748-E7BE-4570-9BAF-28281FDCEDD9"),TaxPercentage=third/2 },
                    new TaxRuleDetailsEntity(){ Id = Guid.Parse("A36C3222-3580-4970-ADFB-64272E00145C"), PerticularNames="SGST", Descriptions ="SGST", TaxRuleId=Guid.Parse("29869748-E7BE-4570-9BAF-28281FDCEDD9"),TaxPercentage=third/2 },
                    new TaxRuleDetailsEntity(){ Id = Guid.Parse("882AD2E7-7E86-471F-8F96-AC795FB7E677"), PerticularNames="IGST", Descriptions ="IGST", TaxRuleId=Guid.Parse("29869748-E7BE-4570-9BAF-28281FDCEDD9"),TaxPercentage=third/2 },

                    new TaxRuleDetailsEntity(){ Id = Guid.Parse("DD1B0A98-13E3-4BAD-953C-06ECCFB8DAB4"), PerticularNames="CGST", Descriptions ="CGST", TaxRuleId=Guid.Parse("260C617B-822D-4C87-A079-82E5CC30E899"),TaxPercentage=fourth/2 },
                    new TaxRuleDetailsEntity(){ Id = Guid.Parse("E9786033-56DF-4343-8D1B-82996B3B8C88"), PerticularNames="SGST", Descriptions ="SGST", TaxRuleId=Guid.Parse("260C617B-822D-4C87-A079-82E5CC30E899"),TaxPercentage=fourth/2 },
                    new TaxRuleDetailsEntity(){ Id = Guid.Parse("FAC7957F-F490-4E21-9889-0892664B8E5D"), PerticularNames="IGST", Descriptions ="IGST", TaxRuleId=Guid.Parse("260C617B-822D-4C87-A079-82E5CC30E899"),TaxPercentage=fourth/2 },
                };
            }
        }
    }
}
