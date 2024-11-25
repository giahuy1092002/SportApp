using Microsoft.AspNetCore.Identity;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Dto.UserDto;
using SportApp_Infrastructure.Model.Mail;
using SportApp_Infrastructure.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IdentityResult> SignUp(SignUpRequest request);
        Task<User> SignIn(SignInModel request);
        Task<bool> Update(UpdateUserModel request);
        Task<bool> UpdateAvatar(UpdateAvatarModel request);
        Task<ConfirmLinkModel> GetConfirmEmail(string email);
        Task<bool> ConfirmEmail(string token,string email);
        Task<bool> ResetPassword(ResetPasswordModel request);
        Task<ForgetLinkModel> ForgetPassword(string email);
        Task<bool> ChangePassword(ChangePasswordModel request, string email);
    }
}
