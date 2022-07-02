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
    public class ProductRepository : IRepository<ProductEntity>, IDisposable 
    {
        private bool disposedValue;

        private SavuDiaryDBContext Context { get; }
        public ProductRepository(SavuDiaryDBContext context )
        {
            Context = context;
        }

        public async Task<ProductEntity> Insert(ProductEntity entity)
        {
            Context.Add(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<ProductEntity> Update(ProductEntity entity)
        {
            if (entity.Id != Guid.Empty)
            {
                var myentity = Context.Products.FirstOrDefault(x => x.Id == entity.Id);
                if (myentity != null)
                {
                    Context.Entry(myentity).State=EntityState.Detached;
                
                }
                Context.Entry(entity).State = EntityState.Modified;
              await  Context.SaveChangesAsync();
            }
            return entity;
        }
        public async Task<ProductEntity> Delete(ProductEntity entity)
        {
            if (entity.Id != Guid.Empty)
            {
                entity.IsActive = false;
                var myentity = Context.Products.FirstOrDefault(x => x.Id == entity.Id);
                if (myentity != null)
                {
                    Context.Entry(myentity).State = EntityState.Detached;

                }
                Context.Entry(entity).State = EntityState.Modified;
                await Context.SaveChangesAsync();
            }
            return entity;
        }

        public IQueryable<ProductEntity> GetAll()
        {
            return Context.Set<ProductEntity>().AsNoTracking().AsQueryable();
        }

        public Task<ProductEntity> GetById(Guid id)
        {
            var res = Context.Set<ProductEntity>().Where(x => x.Id == id).AsNoTrackingWithIdentityResolution().FirstOrDefault();
            if (res != null)
            {
                return Task.FromResult(res);

            }
            return Task.FromResult(new ProductEntity());
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
        ~ProductRepository()
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
