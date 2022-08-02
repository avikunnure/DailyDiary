using SavuDiary.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavuDiary.Server.DataLayers
{
    public class TemplateEntity :BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public Decimal Quantity { get; set; }
        public DateTime ApplicableDatetime { get; set; }

        [NotMapped]
        public string ProductName { get; set; }
        [NotMapped]
        public string CustomerName { get; set; }

        public static implicit operator TemplateEntity(Template template)
        {
            return new TemplateEntity()
            {
                ApplicableDatetime = template.ApplicableDatetime,
                ProductName = template.ProductName,
                CustomerName = template.CustomerName,
                Quantity = template.Quantity,
                CustomerId = template.CustomerId,
                Id = template.Id,
                IsActive = template.IsActive,
                ProductId = template.ProductId,

            };
        }

        public static implicit operator Template(TemplateEntity template)
        {
            return new Template()
            {
                ApplicableDatetime = template.ApplicableDatetime,
                ProductName = template.ProductName,
                CustomerName = template.CustomerName,
                Quantity = template.Quantity,
                CustomerId = template.CustomerId,
                Id = template.Id,
                IsActive = template.IsActive,
                ProductId = template.ProductId,
                
            };
        }
    }
}
