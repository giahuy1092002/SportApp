using SportApp_Business.Commands.UserCommand;
using SportApp_Business.Common;
using SportApp_Infrastructure.Model.CustomerModel;
using SportApp_Infrastructure.Model.Owner;
using SportApp_Infrastructure.Model.SpecModel;
using SportApp_Infrastructure.Model.UserModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportApp_Business.Commands.SpecCommand
{
    public class CreateSpecCommand : ICommand<bool>
    {
        // Create user
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string? Gender { get; set; }
        public string? Avatar { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Location { get; set; }
        // Create spec
        public string? Skills { get; set; }
        public string? Note { get; set; }
        public class AddUserToRoleHandler : ICommandHandler<CreateSpecCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public AddUserToRoleHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(CreateSpecCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    var userId = await _unitOfWork.Seeds.AddUserToRole(request.Email, "Spec");
                    var result = false;
                    var spec = new CreateSpecModel
                    {
                      UserId = userId,
                      Skills = request.Skills,
                      Note = request.Note
                    };
                    result = await _unitOfWork.Specs.Create(spec);
                    _unitOfWork.CommitTransaction();
                    return result;
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception("Add user to role failed");
                }
            }
        }
    }
}
