using SportApp_Business.Common;
using SportApp_Infrastructure.Model.AdminModel;
using SportApp_Infrastructure.Model.CustomerModel;
using SportApp_Infrastructure.Model.Owner;
using SportApp_Infrastructure.Model.SpecModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.UserCommand
{
    public class AddRoleCommand : ICommand<bool>
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public class AddRoleHandler : ICommandHandler<AddRoleCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public AddRoleHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(AddRoleCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    var userId = await _unitOfWork.Seeds.AddUserToRole(request.Email, request.Role);     
                    _unitOfWork.CommitTransaction();
                    return await Task.FromResult(true);
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
