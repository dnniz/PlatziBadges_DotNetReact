using PlatziBadges.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlatziBadges.Service
{
    public interface IBadgeService
    {
        public abstract Task<Badge> Add(Badge entity);
        public abstract Task<IEnumerable<Badge>> GetAll();
    }
}
