using PlatziBadges.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlatziBadges.Service
{
    public interface IBadgeService
    {
        public abstract Task<Badge> AddAsync(Badge entity);
        public abstract Task<IEnumerable<Badge>> GetAllAsync();
        public abstract Task<Badge> GetByIdAsync(int badgeId);
        public abstract Task<Badge> UpdateAsync(Badge entity);
        public abstract Task<int> DeleteAsync(int badgeId);
        public abstract Task<int> DeleteLogicAsync(int badgeId);
    }
}
