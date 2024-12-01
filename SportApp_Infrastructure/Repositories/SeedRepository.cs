using Azure.Core;
using Microsoft.AspNetCore.Identity;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.UserModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories
{
    public class SeedRepository : ISeedRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        public SeedRepository(UserManager<User> userManager,RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> CreateUser(CreateUserModel request)
        {
            if (!(request.Role.ToUpper().Equals("ADMIN") || request.Role.ToUpper().Equals("CUSTOMER")
            || request.Role.ToUpper().Equals("SPEC") || request.Role.ToUpper().Equals("OWNER")))
                throw new Exception("Role is not exist");
            try
            {
                var user = new User
                {
                    Avatar = request.Avatar,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Gender = request.Gender,
                    DateOfBirth = request.DateOfBirth,
                    Location = request.Location,
                    RegistrationDate = DateTime.Now,
                    Email = request.Email,
                    UserName = request.Email,
                    EmailConfirmed = true
                };
                return await _userManager.CreateAsync(user, request.Password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<Guid> AddUserToRole(string email, string role)
        {
            if (!(role.ToUpper().Equals("ADMIN") || role.ToUpper().Equals("CUSTOMER")
                || role.ToUpper().Equals("SPEC") || role.ToUpper().Equals("OWNER")))
                throw new Exception("Role is not exist");
            var user = await _userManager.FindByEmailAsync(email)
                ?? throw new Exception("User is not found");

            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Count > 0) { throw new Exception("Duplicate role"); }
            var result = await _userManager.AddToRoleAsync(user, role);
            if (result.Succeeded) { return user.Id; }
            return Guid.Empty;
        }

    }
}
