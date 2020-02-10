using PlatziBadges.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatziBadges.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        ValueTask<T> GetByIdAsync(object id);
        ValueTask<int> InsertAsync(T entity);
        ValueTask<int> UpdateAsync(T entity);
        ValueTask<int> DeleteAsync(T entity);
        IQueryable<T> Table { get; }
    }
}
