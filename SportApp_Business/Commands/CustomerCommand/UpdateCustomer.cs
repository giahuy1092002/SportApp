using AutoMapper;
using SportApp_Business.Common;
using SportApp_Infrastructure.Model.CustomerModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.CustomerCommand
{
    public class UpdateCustomer : ICommand<bool>
    {
        public Guid CustomerId { get; set; }
        public string? Interest { get; set; }
        public long? Height { get; set; }
        public long? Weight { get; set; }
        public string? Skills { get; set; }
        public class UpdateCustomerHandler : ICommandHandler<UpdateCustomer,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public UpdateCustomerHandler(IUnitOfWork unitOfWork,IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<bool> Handle(UpdateCustomer request, CancellationToken cancellationToken)
            {
                var model = _mapper.Map<UpdateCustomerModel>(request);
                return await _unitOfWork.Customers.UpdateCustomer(model);
            }
        }
    }
}
