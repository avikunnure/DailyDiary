using SavuDiary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavuDiary.Server.DataLayers
{
    public class TaxRecordDetailEntity : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid TaxId { get; set; }
        public string TaxName { get; set; }
        public DateTime Dated { get; set; }
        public decimal TaxPercenatage { get; set; }
        public decimal TaxAmount { get; set; }
        public Guid RecordId { get; set; }
        public Guid RecordDetailId { get; set; }
        public long RecordNo { get; set; }
        public string RecordTypeName { get; set; }

        public static implicit operator TaxRecordDetailEntity(TaxRecordDetails taxRecord)
        {

            if (taxRecord == null)
            {
                return null;
            }
            return new TaxRecordDetailEntity()
            {
                Dated = taxRecord.Dated,
                Id = taxRecord.Id,
                IsActive = taxRecord.IsActive,
                ProductId = taxRecord.ProductId,
                RecordId = taxRecord.RecordId,
                RecordNo = taxRecord.RecordNo,
                RecordTypeName = taxRecord.RecordTypeName,
                TaxAmount = taxRecord.TaxAmount,
                TaxId = taxRecord.TaxId,
                TaxName = taxRecord.TaxName,
                TaxPercenatage = taxRecord.TaxPercenatage,
                RecordDetailId=taxRecord.RecordDetailId,
            };
        }

        public static implicit operator TaxRecordDetails(TaxRecordDetailEntity taxRecord)
        {
            if (taxRecord == null)
            {
                return null;
            }
            return new TaxRecordDetails()
            {
                Dated = taxRecord.Dated,
                Id = taxRecord.Id,
                IsActive = taxRecord.IsActive,
                ProductId = taxRecord.ProductId,
                RecordId = taxRecord.RecordId,
                RecordNo = taxRecord.RecordNo,
                RecordTypeName = taxRecord.RecordTypeName,
                TaxAmount = taxRecord.TaxAmount,
                TaxId = taxRecord.TaxId,
                TaxName = taxRecord.TaxName,
                TaxPercenatage = taxRecord.TaxPercenatage,
                RecordDetailId = taxRecord.RecordDetailId,
            };
        }
    }
}
