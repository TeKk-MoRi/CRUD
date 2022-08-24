using Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer.Context
{
    public partial class CRUDContext : DbContext
    {
        public CRUDContext(DbContextOptions<CRUDContext> options)
                : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasQueryFilter(m => !m.IsDeleted);

            base.OnModelCreating(modelBuilder);
        }
    }
}
