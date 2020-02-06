using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlatziBadges.Entity;

namespace PlatziBadges.Data
{
    public class PlatziBadgesContext : DbContext, IDbContext
    {
        public PlatziBadgesContext(DbContextOptions<PlatziBadgesContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Badge>();

            base.OnModelCreating(modelBuilder);
        }
        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

    }
}
