﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace SavuDiary.Server.DataLayers
{
    public class StockManagementRepository : IRepository<StockMangementEntity>, IDisposable 
    {
        private bool disposedValue;

        private SavuDiaryDBContext Context { get; }
        public StockManagementRepository(SavuDiaryDBContext context )
        {
            Context = context;
        }

        public async Task<StockMangementEntity> Insert(StockMangementEntity entity)
        {
            Context.Add(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<StockMangementEntity> Update(StockMangementEntity entity)
        {
            if (entity.Id != Guid.Empty)
            {
                var myentity = Context.StockMangement.FirstOrDefault(x => x.Id == entity.Id);
                if (myentity != null)
                {
                    Context.Entry(myentity).State = EntityState.Detached;

                }
                Context.Entry(entity).State = EntityState.Modified;
                await Context.SaveChangesAsync();
            }
            return entity;
        }
        public async Task<StockMangementEntity> Delete(StockMangementEntity entity)
        {
            if (entity.Id != Guid.Empty)
            {
                entity.IsActive = false;
                var myentity = Context.StockMangement.FirstOrDefault(x => x.Id == entity.Id);
                if (myentity != null)
                {
                    Context.Entry(myentity).State = EntityState.Detached;

                }
                Context.Entry(entity).State = EntityState.Modified;
                await Context.SaveChangesAsync();
            }
            return entity;
        }

        public IQueryable<StockMangementEntity> GetAll()
        {
            return Context.Set<StockMangementEntity>().AsNoTracking().AsQueryable();
        }

        public Task<StockMangementEntity> GetById(Guid id)
        {
            var res = Context.Set<StockMangementEntity>().Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
            if (res != null)
            {
                return Task.FromResult(res);

            }
            return Task.FromResult(new StockMangementEntity());
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
        ~StockManagementRepository()
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