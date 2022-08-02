using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace SavuDiary.Server.DataLayers
{
    public class TemplateRepository : BaseRepository<TemplateEntity>
    {
        public TemplateRepository(SavuDiaryDBContext context) : base(context)
        {
        }
        public override IEnumerable<TemplateEntity> GetAll()
        {
            var result = from s in Context.Template
                         join p in Context.Products on s.ProductId equals p.Id into p2
                         from prod in p2.DefaultIfEmpty()
                         join c in Context.Customers on s.CustomerId equals c.Id into c2
                         from cust in c2.DefaultIfEmpty()
                         where prod.IsActive == true
                         where cust.IsActive == true
                         where s.IsActive == true
                         select new TemplateEntity
                         {
                             ApplicableDatetime = s.ApplicableDatetime,
                             CustomerId = s.CustomerId,
                             ProductId = s.ProductId,
                             CustomerName = cust.FirstName + " " + cust.LastName,
                             Id = s.Id,
                             IsActive = s.IsActive,
                             ProductName = prod.Name,
                             Quantity = s.Quantity,
                         };
            return result.AsEnumerable();

        }

        ~TemplateRepository()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
