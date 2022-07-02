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
    public class SaleRepository : IRepository<SaleEntity>, IDisposable 
    {
        private bool disposedValue;

        private SavuDiaryDBContext Context { get; }
        public SaleRepository(SavuDiaryDBContext context )
        {
            Context = context;
        }

        public async Task<SaleEntity> Insert(SaleEntity entity)
        {
            Context.Add(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<SaleEntity> Update(SaleEntity entity)
        {
            if (entity.Id != Guid.Empty)
            {
                var myentity = Context.Sales.FirstOrDefault(x => x.Id == entity.Id);
                if (myentity != null)
                {
                    Context.Entry(myentity).State = EntityState.Detached;

                }
                Context.Entry(entity).State = EntityState.Modified;
                await Context.SaveChangesAsync();
            }
            return entity;
        }
        public async Task<SaleEntity> Delete(SaleEntity entity)
        {
            if (entity.Id != Guid.Empty)
            {
                entity.IsActive = false;
                var myentity = Context.Sales.FirstOrDefault(x => x.Id == entity.Id);
                if (myentity != null)
                {
                    myentity = entity;
                    await Context.SaveChangesAsync();
                }
            }
            return entity;
        }

        public IQueryable<SaleEntity> GetAll()
        {
            return Context.Set<SaleEntity>().AsNoTracking().AsQueryable();
        }

        public Task<SaleEntity> GetById(Guid id)
        {
            var res = Context.Set<SaleEntity>().Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
            if (res != null)
            {
                return Task.FromResult(res);

            }
            return Task.FromResult(new SaleEntity());
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
        ~SaleRepository()
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
