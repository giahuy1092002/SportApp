using Microsoft.Identity.Client;
using SportApp_Business.Common;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.CustomerCommand
{
    public class DeleteCustomer : ICommand<bool>
    {
        public Guid CustomerId { get; set; }
        public class DeleteCustomerHandler : ICommandHandler<DeleteCustomer,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteCustomerHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(DeleteCustomer request, CancellationToken cancellationToken)
            {
                return await _unitOfWork.Customers.DeleteCustomer(request.CustomerId);
            }
        }
    }
}
