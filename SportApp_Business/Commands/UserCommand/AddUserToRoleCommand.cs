using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SportApp_Business.Common;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.CustomerModel;
using SportApp_Infrastructure.Model.Owner;
using SportApp_Infrastructure.Model.SpecModel;
using SportApp_Infrastructure.Model.UserModel;
using SportApp_Infrastructure.Repositories.Interfaces;


namespace SportApp_Business.Commands.UserCommand
{
    public class AddUserToRoleCommand : ICommand<bool>
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public class AddUserToRoleHandler : ICommandHandler<AddUserToRoleCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public AddUserToRoleHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(AddUserToRoleCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    var userId = await _unitOfWork.Seeds.AddUserToRole(request.Email,request.Role);
                    var result = false;
                    if(request.Role=="Owner")
                    {
                        var owner = new CreateOwnerModel
                        {
                            UserId = userId
                        };
                        result = await _unitOfWork.Owners.Create(owner);
                    }
                    else if(request.Role=="Spec")
                    {
                        var spec = new CreateSpecModel
                        {
                            UserId = userId
                        };
                        result = await _unitOfWork.Specs.Create(spec);
                    }   
                    else if(request.Role=="Customer")
                    {
                        var customer = new CreateCustomerModel
                        {
                            UserId = userId
                        };
                        result = await _unitOfWork.Customers.CreateCustomer(customer);
                    }    
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
