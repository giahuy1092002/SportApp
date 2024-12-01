using SportApp_Business.Common;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Model.CartModel;
using Microsoft.EntityFrameworkCore;

namespace SportApp_Business.Commands.CartCommand
{
    public class AddItem : ICommand<bool>
    {
        public string BuyerId { get; set; }
        public Guid SportProductVariantId { get; set; }
        public int Quantity { get; set; }
        public class AddItemHandler : ICommandHandler<AddItem, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly SportAppDbContext _context;
            public AddItemHandler(IUnitOfWork unitOfWork, SportAppDbContext context)
            {
                _unitOfWork = unitOfWork;
                _context = context;
            }

            public async Task<bool> Handle(AddItem request, CancellationToken cancellationToken)
            {
                try
                {
                    var cart = await _context.Cart.FirstOrDefaultAsync(c=>c.BuyerId== request.BuyerId);
                    if (cart == null) cart = await _unitOfWork.Carts.CreateCart(request.BuyerId);
                    var variant = await _unitOfWork.ProductVariants.GetById(request.SportProductVariantId);
                    if (variant == null) throw new AppException("Sản phẩm khôn tồn tại");
                    var model = new AddItemModel
                    {
                        BuyerId = request.BuyerId,
                        SportProductVariant = variant,
                        Quantity = request.Quantity
                    };
                    var result = await _unitOfWork.Carts.AddItem(model);
                    return result;
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
