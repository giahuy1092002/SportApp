using Microsoft.AspNetCore.Identity;
using SportApp_Business.Commands.UserCommand;
using SportApp_Business.Common;
using SportApp_Infrastructure.Model.FieldType;
using SportApp_Infrastructure.Model.UserModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.FieldType
{
    public class CreateFieldTypeCommand : ICommand<bool>
    {
        public string Name { get; set; }
        public class CreateFieldTypeHandler : ICommandHandler<CreateFieldTypeCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public CreateFieldTypeHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(CreateFieldTypeCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    var createFieldType = new CreateFieldTypeModel
                    {
                        Name = request.Name,
                    };
                    var result = await _unitOfWork.FieldTypes.Create(createFieldType);
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
