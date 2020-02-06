using PlatziBadges.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlatziBadges.Service
{
    public interface IBadgeService
    {
        public abstract Badge Add(Badge entity);
    }
}
