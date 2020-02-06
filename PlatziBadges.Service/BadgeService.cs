using PlatziBadges.Data;
using PlatziBadges.Entity;
using System;

namespace PlatziBadges.Service
{
    public class BadgeService : IBadgeService
    {
        private readonly PlatziBadgesContext _context;

        public BadgeService(PlatziBadgesContext context)
        {
            _context = context;
        }
        public Badge Add(Badge entity)
        {
            try
            {
                IRepository<Badge> rep = new EfRepository<Badge>(_context);
                rep.Insert(entity);

                return entity;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
