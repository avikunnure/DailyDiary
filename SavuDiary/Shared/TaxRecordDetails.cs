using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavuDiary.Shared
{
    public class TaxRecordDetails:Base
    {
        public Guid ProductId { get; set; }
        public Guid TaxId { get; set; }
        public string TaxName { get; set; }
        public DateTime Dated { get; set; }
        public decimal TaxPercenatage { get; set; }
        public decimal TaxAmount { get; set; }
        public Guid RecordId { get; set; }
        public long RecordNo { get; set; }
        public Guid RecordDetailId { get; set; }
        public string RecordTypeName { get; set; }
    }
}
