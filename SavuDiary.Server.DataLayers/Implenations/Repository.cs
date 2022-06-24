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
    public class Repository<T> : IRepository<T>, IDisposable where T : BaseEntity, new()
    {
        private bool disposedValue;

        private SavuDiaryDBContext Context { get; }
        public Repository(SavuDiaryDBContext context)
        {
            Context = context;
        }

        public async Task<T> Insert(T entity)
        {
            Context.Add(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            if (entity.Id != Guid.Empty)
            {
                Context.Entry(entity).State = EntityState.Detached;
                Context.Entry(entity).State= EntityState.Modified;

                await Context.SaveChangesAsync();
            }
            return entity;
        }
        public async Task<T> Delete(T entity)
        {
            if (entity.Id != Guid.Empty)
            {
                entity.IsActive = false;
                Context.Entry(entity).State = EntityState.Detached;
                Context.Entry(entity).State = EntityState.Modified;
                await Context.SaveChangesAsync();
            }
            return entity;
        }

        public Task<IEnumerable<T>> GetAll()
        {
            return Task.FromResult(Context.Set<T>().AsNoTracking().AsEnumerable());
        }

        public Task<T> GetById(Guid id)
        {
            var res = Context.Set<T>().Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
            if (res != null)
            {
                return Task.FromResult(res);

            }
            return Task.FromResult(new T());
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
        ~Repository()
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
