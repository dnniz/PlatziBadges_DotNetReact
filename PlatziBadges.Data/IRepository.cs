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
        ValueTask<T> GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }
    }
}
