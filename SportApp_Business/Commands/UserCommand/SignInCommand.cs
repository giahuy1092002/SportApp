
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Dtos.UserDtos;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Model.UserModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using SportApp_Infrastructure.Services;
using System.Security.Claims;

namespace SportApp_Business.Commands.UserCommand
{
    public class SignInCommand : ICommand<UserLoginDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public class SignInHandler : ICommandHandler<SignInCommand, UserLoginDto>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly TokenService _tokenService;
            private readonly UserManager<User> _userManager;
            private readonly SportAppDbContext _context;
            public SignInHandler(IUnitOfWork unitOfWork,IMapper mapper,TokenService tokenService,UserManager<User> userManager, SportAppDbContext context)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _tokenService = tokenService;
                _userManager = userManager;
                _context = context;
            }
            public async Task<UserLoginDto> Handle(SignInCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    var signInModel = new SignInModel
                    {
                        Email = request.Email,
                        Password = request.Password,
                    };
                    var user = await _unitOfWork.Users.SignIn(signInModel);
                    var userDto = _mapper.Map<UserLoginDto>(user);
                    userDto.Token = await _tokenService.GenToken(user);
                    var roles = await _userManager.GetRolesAsync(user);
                    userDto.Role = roles[0];
                    if(userDto.Role.ToUpper()=="CUSTOMER")
                    {
                        var customer = await _context.Customer.FirstOrDefaultAsync(c => c.UserId == user.Id);
                        userDto.UserRoleId = customer.Id;
                    }    
                    else if(userDto.Role.ToUpper() == "SPEC")
                    {
                        var spec = await _context.Spec.FirstOrDefaultAsync(c => c.UserId == user.Id);
                        userDto.UserRoleId = spec.Id;
                    }    
                    _unitOfWork.CommitTransaction();
                    return userDto;
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception("Sign in failed");
                }
            }
        }
    }
}
