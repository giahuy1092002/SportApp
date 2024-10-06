using SportApp_Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SportApp_Infrastructure.Repositories.Interfaces;
using SportApp_Infrastructure.Dto.UserDto;

namespace SportApp_Business.Commands.UserCommand
{
    public class SignUpCommand : ICommand<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public class SignUpHandler : ICommandHandler<SignUpCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public SignUpHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(SignUpCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    var signUpRequest = new SignUpRequest
                    {
                        Email = request.Email,
                        Password = request.Password,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        ConfirmPassword = request.ConfirmPassword,
                    };
                    var user = await _unitOfWork.Users.SignUp(signUpRequest);
                    _unitOfWork.CommitTransaction();
                    return true;
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception("Sign up failed");
                }
            }
        }
    }
}
