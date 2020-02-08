using Microsoft.EntityFrameworkCore;
using PlatziBadges.Data;
using PlatziBadges.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatziBadges.Service
{
    public class BadgeService : IBadgeService
    {
        private readonly PlatziBadgesContext _context;

        public BadgeService(PlatziBadgesContext context) => _context = context; 


        public async Task<Badge> Add(Badge entity)
        {
            try
            {
                IRepository<Badge> rep = new EfRepository<Badge>(_context);
                var result = await rep.Insert(entity);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Badge>> GetAll()
        {
            try
            {
                IRepository<Badge> rep = new EfRepository<Badge>(_context);

                var result = await rep.Table.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
