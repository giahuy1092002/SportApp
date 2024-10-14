using AutoMapper;
using SportApp_Business.Common;
using SportApp_Infrastructure.Model.UserModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.UserCommand
{
    public class UpdateUserCommand : ICommand<bool>
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public class UpdateUserHanlder : ICommandHandler<UpdateUserCommand,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public UpdateUserHanlder(IUnitOfWork unitOfWork,IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    var updateUser = _mapper.Map<UpdateUserModel>(request);
                    _unitOfWork.CommitTransaction();
                    return await _unitOfWork.Users.Update(updateUser);
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
