using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Dto.UserDto;
using SportApp_Infrastructure.Model.UserModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SportApp_Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.Routing;
using SportApp_Infrastructure.Model.Mail;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using Org.BouncyCastle.Security;



namespace SportApp_Infrastructure.Repositories
{
    public class UserRepository : Repository<User>,IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUrlHelper _urlHelper;
        public UserRepository(SportAppDbContext context,UserManager<User> userManager,IUnitOfWork unitOfWork,IUrlHelper urlHelper) :base(context)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _urlHelper = urlHelper;
        }

        public async Task<bool> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return await Task.FromResult(true);
                }
            }
            return await Task.FromResult(false);
        }

        public async Task<ForgetLinkModel> ForgetPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var decodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
                var link = _urlHelper.Action("ResetPassword", new { decodedToken });
                var result = new ForgetLinkModel
                {
                    Email = email,
                    Link = link
                };
                return await Task.FromResult(result);
            }
            throw new AppException(ErrorMessage.EmailNotExist);
        }

        public async Task<ConfirmLinkModel> GetConfirmEmail(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            if(user==null) throw new AppException(ErrorMessage.EmailNotExist);
            if (user.EmailConfirmed == true)
            {
                throw new AppException(ErrorMessage.AccountConfirmed);
            }
            try
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var endcodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
                var confirmLink = _urlHelper.Action("ConfirmEmail", new { endcodedToken, email });
                return await Task.FromResult(new ConfirmLinkModel { Email = email, Link = confirmLink });
            }
            catch
            {
                throw;
            } 
            
        }

        public async Task<bool> ResetPassword(ResetPasswordModel request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                var result = await _userManager.ResetPasswordAsync(user, request.Token, request.Password);
                if (result.Succeeded)
                {
                    return await Task.FromResult(true);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        throw new Exception(error.Description);
                    }

                }
            }
            return false;
        }
        public async Task<bool> ChangePassword(ChangePasswordModel changePasswordModel, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.ChangePasswordAsync(user, changePasswordModel.CurrentPassword, changePasswordModel.NewPassword);
            if (result.Succeeded)
            {
                return await Task.FromResult(true);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    if (error.Code == "PasswordMismatch")
                    {
                        throw new PasswordException("Current password is incorrect.");
                    }
                }

            }
            return false;
        }

        public async Task<User> SignIn(SignInModel request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if(user==null)
            {
                throw new AppException(ErrorMessage.EmailNotExist);
            }
            if(!await _userManager.CheckPasswordAsync(user, request.Password))
            {
                throw new AppException(ErrorMessage.WrongPassword);
            }    
            return user;
        }

        public async Task<IdentityResult> SignUp(SignUpRequest request)
        {
            var userTest = await _userManager.FindByEmailAsync(request.Email);
            if (userTest != null)
            {
                throw new AppException(ErrorMessage.EmailExist);
            }
            var user = new User
            {
                Email = request.Email,
                UserName = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            return result;
        }

        public async Task<bool> Update(UpdateUserModel request)
        {
            try
            {
                var user = await Entities.FirstOrDefaultAsync(u => u.Id == request.UserId);
                if (user == null)
                {
                    throw new Exception("User is not exist");
                }
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.Gender = request.Gender;
                user.DateOfBirth = request.DateOfBirth;
                user.PhoneNumber = request.PhoneNumber;
                user.Location = request.Location;
                Entities.Update(user);
                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAvatar(UpdateAvatarModel request)
        {
            try
            {
                var user = await Entities.FirstOrDefaultAsync(u => u.Id == request.UserId);
                if (user == null)
                {
                    throw new AppException("User is not exist");
                }
                user.Avatar = request.Avatar;
                Entities.Update(user);
                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
