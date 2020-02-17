using System;
using Services;
using Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Managers
{
    /// <summary>
    ///     Implement all the basic CRUD operation
    ///     - All the methods implemented are virtual so it mean that you can override them if you need it.
    /// </summary>
    /// <typeparam name="TEntity">Represent the entity model use by the instance</typeparam>
    public abstract class NormalCrudOperationSQL<TEntity> : IDatabaseServices<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _context;
        protected readonly ILogger<NormalCrudOperationSQL<TEntity>> _logger;

        public NormalCrudOperationSQL(AppDbContext context, ILogger<NormalCrudOperationSQL<TEntity>> logger)
        {
            _context = context;
            _logger = logger;
        }

        public virtual async Task<TEntity> Create(TEntity model)
        {
            var entity = await _context.Set<TEntity>().AddAsync(model);
            await _context.SaveChangesAsync();
            return entity.Entity;
        }

        public virtual async Task<TEntity> Delete(int id)
        {
            TEntity entity = await _context.Set<TEntity>().FindAsync();

            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }

            return entity;
        }

        public virtual async Task<TEntity> Edit(TEntity model)
        {
            var entity = _context.Set<TEntity>().Attach(model);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity.Entity;
        }

        public virtual async Task<TEntity> Get(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            return entity;
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            var entities = await _context.Set<TEntity>().ToListAsync();
            return entities;
        }

        public async Task<List<TEntity>> GetFromPredicate(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = await _context.Set<TEntity>().Where(predicate).ToListAsync();
            return entities;
        }
    }
}