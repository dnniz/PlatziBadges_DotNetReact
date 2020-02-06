using Microsoft.EntityFrameworkCore;
using PlatziBadges.Entity;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace PlatziBadges.Data
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        private DbSet<T> _entities;

        public EfRepository(DbContext context)
        {
            this._context = context;
        }
        public IQueryable<T> Table => throw new NotImplementedException();

        public void Delete(T entity)
        {

            if (entity == null)
                throw new ArgumentNullException("entity");

            this.Entities.Remove(entity);
            this._context.SaveChangesAsync();
        
        }

        public ValueTask<T> GetById(object id)
        {
            return this.Entities.FindAsync(id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this.Entities.Add(entity);
            this._context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            
            if (entity == null)
                throw new ArgumentNullException("entity");

            this._context.SaveChangesAsync();
            
        }

        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }

        
        
    }
}
