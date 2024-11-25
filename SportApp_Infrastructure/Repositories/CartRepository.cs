using Microsoft.EntityFrameworkCore;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.CartModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public CartRepository(SportAppDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Cart> CreateCart(string buyerId)
        {
            try
            {
                var cart = new Cart
                {
                    BuyerId = buyerId
                };
                Entities.Add(cart);
                await _unitOfWork.SaveChangesAsync();
                return cart;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> AddItem(AddItemModel request)
        {
            try
            {
                var cart = await Entities.FirstOrDefaultAsync(c => c.BuyerId == request.BuyerId);
                cart.AddItem(request.SportProductVariant, request.Quantity);
                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteItem(DeleteItemModel request)
        {
            try
            {
                var cart = await Entities.FirstOrDefaultAsync(c => c.BuyerId == request.BuyerId);
                cart.RemoveItem(request.SportProductVariantId,request.Quantity);
                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch
            {
                throw;
            }
        }
        public async Task<Cart> RetriveCart(string buyerId)
        {
            var cart = await Entities
                .Include(c=>c.Items)
                    .ThenInclude(i=>i.SportProductVariant)
                        .ThenInclude(s=>s.Color)
                .Include(c => c.Items)
                    .ThenInclude(i => i.SportProductVariant)
                        .ThenInclude(s => s.Size)
                .Include(c => c.Items)
                    .ThenInclude(i => i.SportProductVariant)
                        .ThenInclude(s => s.SportProduct)
                            .ThenInclude(s=>s.ImageProducts)
                .FirstOrDefaultAsync(c=>c.BuyerId == buyerId);
            return cart;
        }
        public async Task<bool> RemoveCart(Guid cartId)
        {
            try
            {
                var cart = await Entities.FirstOrDefaultAsync(c => c.Id == cartId);
                if (cart == null) throw new AppException("Giỏ hàng không tồn tại");
                Entities.Remove(cart);
                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch
            {
                throw;
            }
        }
    }
}
