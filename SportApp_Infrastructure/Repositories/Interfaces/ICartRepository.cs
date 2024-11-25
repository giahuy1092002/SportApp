using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.CartModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task<bool> AddItem(AddItemModel request);
        Task<bool> DeleteItem(DeleteItemModel request);
        Task<Cart> CreateCart(string buyerId);
        Task<Cart> RetriveCart(string buyerId);
        Task<bool> RemoveCart(Guid cartId);
    }
}
