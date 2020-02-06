﻿using PlatziBadges.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PlatziBadges.Data
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
}
