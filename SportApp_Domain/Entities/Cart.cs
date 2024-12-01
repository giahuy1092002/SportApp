using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class Cart
    {
        public Guid Id { get; set; }
        public string BuyerId { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public void AddItem(SportProductVariant sportProductVariant, int quantity)
        {
            if (Items.All(i => i.SportProductVariantId != sportProductVariant.Id))
            {
                Items.Add(new CartItem { SportProductVariant = sportProductVariant, Quantity = quantity });
                return;
            }
            var existItem = Items.FirstOrDefault(i => i.SportProductVariantId == sportProductVariant.Id);
            if (existItem != null) existItem.Quantity += quantity;
        }
        public void RemoveItem(Guid sportProductVariantId, int quantity)
        {
            var existItem = Items.FirstOrDefault(i => i.SportProductVariantId == sportProductVariantId);
            if (existItem == null) return;
            existItem.Quantity -= quantity;
            if (existItem.Quantity == 0) Items.Remove(existItem);
        }
        public int TotalQuantity()
        {
            int totalQuantity = 0;
            foreach (var item in Items)
            {
                totalQuantity += item.Quantity;
            }
            return totalQuantity;
        }
        public long TotalPrice()
        {
            long totalPrice = 0;
            foreach(var item in Items)
            {
                totalPrice += item.SportProductVariant.Price * item.Quantity;
            } 
            return totalPrice;        
        }
    }
}
