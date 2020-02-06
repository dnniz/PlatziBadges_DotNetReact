using System;
using Microsoft.EntityFrameworkCore;
using PlatziBadges.Entity;

namespace PlatziBadges.Data
{
    public class PlatziBadgesContext : DbContext, IDbContext
    {
        public PlatziBadgesContext(DbContextOptions<PlatziBadgesContext> options) : base(options)
        {

        }
        //public PlatziBadgesContext()
        //    : base("DefaultConnectionString")
        //{

        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Badge>();
            //optionsBuilder
            base.OnModelCreating(modelBuilder);
        }
        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

    }
}
