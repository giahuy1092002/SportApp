using SportApp_Business.Common;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.CartCommand
{
    public class CreateCart : ICommand<Cart>
    {
        public string BuyerId { get; set; }
        public class CreateCartHandler : ICommandHandler<CreateCart,Cart>
        {
            private readonly IUnitOfWork _unitOfWork;
            public CreateCartHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Cart> Handle(CreateCart request, CancellationToken cancellationToken)
            {
                return await _unitOfWork.Carts.CreateCart(request.BuyerId);
            }
        }
    }
}
