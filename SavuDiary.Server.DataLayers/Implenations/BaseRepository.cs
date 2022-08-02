using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace SavuDiary.Server.DataLayers
{
    public class BaseRepository<TEnity> : IRepository<TEnity>, IDisposable where TEnity : BaseEntity
    {
        private bool disposedValue;

        protected SavuDiaryDBContext Context { get; }
        public BaseRepository(SavuDiaryDBContext context)
        {
            Context = context;
        }

        public virtual async Task<TEnity> Insert(TEnity entity)
        {
            Context.Add(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEnity> Update(TEnity entity)
        {
            if (entity.Id != Guid.Empty)
            {
                var myentity = Context.Customers.FirstOrDefault(x => x.Id == entity.Id);
                if (myentity != null)
                {
                    Context.Entry(myentity).State = EntityState.Detached;

                }
                Context.Entry(entity).State = EntityState.Modified;
                await Context.SaveChangesAsync();
            }
            return entity;
        }
        public virtual async Task<TEnity> Delete(TEnity entity)
        {
            if (entity.Id != Guid.Empty)
            {
                entity.IsActive = false;
                var myentity = Context.Customers.FirstOrDefault(x => x.Id == entity.Id);
                if (myentity != null)
                {
                    Context.Entry(myentity).State = EntityState.Detached;

                }
                Context.Entry(entity).State = EntityState.Modified;
                await Context.SaveChangesAsync();
            }
            return entity;
        }

        public virtual IEnumerable<TEnity> GetAll()
        {
            return Context.Set<TEnity>().Where(x => x.IsActive).AsNoTracking().AsEnumerable();
        }

        public virtual Task<TEnity> GetById(Guid id)
        {
            var res = Context.Set<TEnity>().Where(x => x.Id == id).AsNoTracking().ToList().FirstOrDefault();
            if (res != null)
            {
                return Task.FromResult(res);

            }
            return Task.FromResult(default(TEnity));
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
        ~BaseRepository()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public virtual void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public virtual IEnumerable<TEnity> Get(Expression<Func<TEnity, bool>> predicate)
        {
            return Context.Set<TEnity>().Where(predicate).AsEnumerable();
        }
    }
}
