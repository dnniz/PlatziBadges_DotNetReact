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


        public async Task<Badge> AddAsync(Badge entity)
        {
            try
            {
                IRepository<Badge> rep = new EfRepository<Badge>(_context);
                await rep.InsertAsync(entity);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> DeleteAsync(int badgeId)
        {
            try
            {
                var rep = new EfRepository<Badge>(_context);
                await rep.DeleteAsync(rep.GetByIdAsync(badgeId).Result);

                return badgeId;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> DeleteLogicAsync(int badgeId)
        {
            try
            {
                var rep = new EfRepository<Badge>(_context);

                var badge = rep.GetByIdAsync(badgeId).Result;
                badge.FlagEliminado = true;

                await rep.UpdateAsync(badge);

                return badge.BadgeId;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Badge>> GetAllAsync()
        {
            try
            {
                IRepository<Badge> rep = new EfRepository<Badge>(_context);

                return await rep.Table.Where(x => !x.FlagEliminado).ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Badge> GetByIdAsync(int badgeId)
        {
            try
            {
                IRepository<Badge> rep = new EfRepository<Badge>(_context);
                return await rep.GetByIdAsync(badgeId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Badge> UpdateAsync(Badge entity)
        {
            try
            {
                var rep = new EfRepository<Badge>(_context);
                await rep.UpdateAsync(entity);

                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
