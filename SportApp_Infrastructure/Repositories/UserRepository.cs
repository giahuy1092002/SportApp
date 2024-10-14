using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Dto.UserDto;
using SportApp_Infrastructure.Model.UserModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories
{
    public class UserRepository : Repository<User>,IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        public UserRepository(SportAppDbContext context,UserManager<User> userManager,IUnitOfWork unitOfWork):base(context)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<User> SignIn(SignInModel request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if(user==null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                throw new Exception("Wrong password or email");
            }
            return user;
        }

        public async Task<SignUpDto> SignUp(SignUpRequest request)
        {
            var userTest = await _userManager.FindByEmailAsync(request.Email);
            if (userTest != null)
            {
                throw new Exception("Email exist");
            }
            var user = new User
            {
                Email = request.Email,
                UserName = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            };
            await _userManager.CreateAsync(user, request.Password);
            return new SignUpDto
            {
                Email = request.Email
            };
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
                    throw new Exception("User is not exist");
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
