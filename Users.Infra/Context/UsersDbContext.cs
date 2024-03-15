using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Bank_Users.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Users.Infra.Context
{
    public class UsersDbContext: DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
        }

        public DbSet<UsersEntity> Users { get; set; }
        public DbSet<RolesEntity> Roles { get; set; }
        public DbSet<UsersRolesEntity> UsersRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = Assembly.GetAssembly(typeof(UsersDbContext));

            if (assembly is not null)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            }

            modelBuilder.Entity<UsersEntity>()
                .HasIndex(c => c.Email)
                .IsUnique();
        }
    }
}
