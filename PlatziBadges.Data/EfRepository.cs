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

        public EfRepository(DbContext context) => _context = context;

        public IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        public async ValueTask<int> DeleteAsync(T entity)
        {

            if (entity == null)
                throw new ArgumentNullException("entity");

            Entities.Remove(entity);
            return await _context.SaveChangesAsync();
        
        }

        public async ValueTask<T> GetByIdAsync(object id)
        {
            return await Entities.FindAsync(id);
        }

        public async ValueTask<int> InsertAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            Entities.Add(entity);
            
            return await _context.SaveChangesAsync();
        }

        public async ValueTask<int> UpdateAsync(T entity)
        {
            
            if (entity == null)
                throw new ArgumentNullException("entity");

            Entities.Update(entity);

            return await _context.SaveChangesAsync();
            
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
