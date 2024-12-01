using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SportApp_Business.Common;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.CartCommand
{
    public class RemoveCart : ICommand<bool>
    {
        public Guid CartId { get; set; }
        public class RemoveCartHandler : ICommandHandler<RemoveCart,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly SportAppDbContext _context;
            public RemoveCartHandler(IUnitOfWork unitOfWork,SportAppDbContext context)
            {
                _unitOfWork = unitOfWork;
                _context = context;
            }

            public async Task<bool> Handle(RemoveCart request, CancellationToken cancellationToken)
            {
                return await _unitOfWork.Carts.RemoveCart(request.CartId);
            }
        }
    }
}
