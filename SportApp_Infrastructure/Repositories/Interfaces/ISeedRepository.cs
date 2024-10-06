using Microsoft.AspNetCore.Identity;
using SportApp_Infrastructure.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories.Interfaces
{
    public interface ISeedRepository
    {
        Task<IdentityResult> CreateUser(CreateUserModel request);
        Task<Guid> AddUserToRole(string email, string role);
    }
}
