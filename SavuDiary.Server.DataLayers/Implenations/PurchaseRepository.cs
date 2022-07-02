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
    public class PurchaseRepository : IRepository<PurchaseEntity>, IDisposable
    {
        private bool disposedValue;

        private SavuDiaryDBContext Context { get; }
        public PurchaseRepository(SavuDiaryDBContext context)
        {
            Context = context;
        }

        public async Task<PurchaseEntity> Insert(PurchaseEntity entity)
        {
            Context.Add(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<PurchaseEntity> Update(PurchaseEntity entity)
        {
            if (entity.Id != Guid.Empty)
            {
                var myentity = Context.Purchase.FirstOrDefault(x => x.Id == entity.Id);
                if (myentity != null)
                {
                    Context.Entry(myentity).State = EntityState.Detached;

                }
                Context.Entry(entity).State = EntityState.Modified;
                await Context.SaveChangesAsync();
            }
            return entity;
        }
        public async Task<PurchaseEntity> Delete(PurchaseEntity entity)
        {
            if (entity.Id != Guid.Empty)
            {
                entity.IsActive = false;
                var myentity = Context.Purchase.FirstOrDefault(x => x.Id == entity.Id);
                if (myentity != null)
                {
                    Context.Entry(myentity).State = EntityState.Detached;

                }
                Context.Entry(entity).State = EntityState.Modified;
                await Context.SaveChangesAsync();
            }
            return entity;
        }

        public IQueryable<PurchaseEntity> GetAll()
        {
            var result = from p in Context.Purchase
                         join s in Context.Suppliers on p.SupplierId equals s.Id
                         into sp
                         from s in sp.DefaultIfEmpty()
                         select new PurchaseEntity()
                         {
                             Amount = p.Amount,
                             DateTime = p.DateTime,
                             DiscountAmount = p.DiscountAmount,
                             Id = p.Id,
                             IsActive = p.IsActive,
                             NetAmount = p.NetAmount,
                             Notes = p.Notes,
                             PurchaseNo = p.PurchaseNo,
                             SupplierId = p.SupplierId,
                             SupplierName = s!=null?$"{s.FirstName} {s.LastName}":"",
                         };
            return result.AsNoTracking().AsQueryable();
        }

        public Task<PurchaseEntity> GetById(Guid id)
        {
            var result = from p in Context.Purchase
                         join s in Context.Suppliers on p.Id equals s.Id
                         into sp
                         from s in sp.DefaultIfEmpty()
                         where p.Id == id
                         select new PurchaseEntity()
                         {
                             Amount = p.Amount,
                             DateTime = p.DateTime,
                             DiscountAmount = p.DiscountAmount,
                             Id = p.Id,
                             IsActive = p.IsActive,
                             NetAmount = p.NetAmount,
                             Notes = p.Notes,
                             PurchaseNo = p.PurchaseNo,
                             SupplierId = p.SupplierId,
                             SupplierName = s != null ? $"{s.FirstName} {s.LastName}" : "",
                         };
            var res = result.AsNoTracking().FirstOrDefault();

            if (res != null)
            {

                return Task.FromResult(res);

            }
            return Task.FromResult(new PurchaseEntity());
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                disposedValue = true;
            }
        }

        // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~PurchaseRepository()
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
