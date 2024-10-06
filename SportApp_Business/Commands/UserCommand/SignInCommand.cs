
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SportApp_Business.Common;
using SportApp_Business.Dtos.UserDtos;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.UserModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using SportApp_Infrastructure.Services;
using System.Security.Claims;

namespace SportApp_Business.Commands.UserCommand
{
    public class SignInCommand : ICommand<UserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public class SignInHandler : ICommandHandler<SignInCommand, UserDto>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly TokenService _tokenService;
            private readonly UserManager<User> _userManager;
            public SignInHandler(IUnitOfWork unitOfWork,IMapper mapper,TokenService tokenService,UserManager<User> userManager)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _tokenService = tokenService;
                _userManager = userManager;
            }
            public async Task<UserDto> Handle(SignInCommand request, CancellationToken cancellationToken)
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
                    var userDto = _mapper.Map<UserDto>(user);
                    userDto.Token = await _tokenService.GenToken(user);
                    var roles = await _userManager.GetRolesAsync(user);
                    userDto.Role = roles[0];
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
