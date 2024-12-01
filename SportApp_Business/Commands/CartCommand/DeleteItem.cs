using SportApp_Business.Common;
using SportApp_Infrastructure.Model.CartModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportApp_Business.Commands.CartCommand
{
    public class DeleteItem : ICommand<bool>
    {
        public Guid SportProductVariantId { get; set; }
        public int Quantity { get; set; }
        public string BuyerId { get; set; }

        public class DeleteItemHandler : ICommandHandler<DeleteItem,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteItemHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;   
            }

            public async Task<bool> Handle(DeleteItem request, CancellationToken cancellationToken)
            {
                var model = new DeleteItemModel
                {
                    SportProductVariantId = request.SportProductVariantId,
                    Quantity = request.Quantity,
                    BuyerId = request.BuyerId,
                };
                return await _unitOfWork.Carts.DeleteItem(model);
            }
        }
    }
}
