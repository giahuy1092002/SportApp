using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Seeding
{
    public static class Seeding
    {
        public static async Task Seed(SportAppDbContext context, RoleManager<Role> roleManager)
        {
            var rolesToAdd = new List<Role>
            {
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
                },
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                }
    };

            foreach (var role in rolesToAdd)
            {
                if (!await roleManager.RoleExistsAsync(role.NormalizedName))
                {
                    await roleManager.CreateAsync(role);
                }
            }
        }

    }
}
