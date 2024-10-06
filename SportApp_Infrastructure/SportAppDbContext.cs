using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure
{
    public class SportAppDbContext: IdentityDbContext<User,Role,Guid>
    {
        public SportAppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<SportField> SportField { get; set; }
        public DbSet<FieldType> FieldType { get; set; }
        public DbSet<TimeSlot> TimeSlot { get; set; } 
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Spec> Spec { get; set; }
        public DbSet<Image> Images { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                },
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = "Owner",
                    NormalizedName = "OWNER"
                },
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = "Spec",
                    NormalizedName = "SPEC"
                }
                );
        }
    }
}
