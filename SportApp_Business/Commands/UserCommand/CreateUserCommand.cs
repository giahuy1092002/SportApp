using Microsoft.AspNetCore.Identity;
using SportApp_Business.Common;
using SportApp_Infrastructure.Model.UserModel;
using SportApp_Infrastructure.Repositories.Interfaces;

namespace SportApp_Business.Commands.UserCommand
{
    public class CreateUserCommand : ICommand<IdentityResult>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string? Gender { get; set; }
        public string? Avatar { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Location { get; set; }

        public string Role { get; set; }
        public class CreateUserHandler : ICommandHandler<CreateUserCommand, IdentityResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            public CreateUserHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<IdentityResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    var createUserModel = new CreateUserModel
                    {
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Email = request.Email,
                        Password = request.Password,
                        Gender = request.Gender,
                        Avatar = request.Avatar,
                        DateOfBirth = request.DateOfBirth,
                        Location = request.Location,
                        Role = request.Role,
                        ConfirmPassword = request.ConfirmPassword
                    };
                    var result = await _unitOfWork.Seeds.CreateUser(createUserModel);
                    _unitOfWork.CommitTransaction();
                    return result;
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception("Create user failed");
                }
            }
        }
    }
}
