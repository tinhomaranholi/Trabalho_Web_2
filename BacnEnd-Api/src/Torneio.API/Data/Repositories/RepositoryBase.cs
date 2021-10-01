using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Torneio.API.Contexts;
using Torneio.API.Models.Entities;
using Torneio.API.Interfaces;

namespace Torneio.API.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity: BaseModel
    {
        protected TorneioContext Db;
        protected DbSet<TEntity> Set;
        public RepositoryBase(TorneioContext context)
        {
            Db = context;
            Set = Db.Set<TEntity>();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            var objReturn = await Set.AddAsync(entity);
            await Db.SaveChangesAsync();
            return objReturn.Entity;
        }

        public Task<List<TEntity>> Get()
        {
            return Set.ToListAsync();
        }

        public async Task<TEntity> Get(Guid id)
        {
            return await Set.FindAsync(id);
        }

        public async Task Remove(Guid id)
        {
            var objectToRemove = await Get(id);
            Db.Remove(objectToRemove);
            await Db.SaveChangesAsync();
        }

        public async Task<TEntity> Update(Guid id, TEntity entity)
        {
            Set.Update(entity);
            await Db.SaveChangesAsync();
            return entity;
        }
    }
}
