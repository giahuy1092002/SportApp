using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.CartDtos
{
    public class CartDto
    {
        public Guid Id { get; set; }
        public string BuyerId { get; set; }
        public List<CartItemDto> Items { get; set; }
        public long TotalPrice { get; set; }
        public int TotalQuantity { get; set; }
    }
    public class CartItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EndPoint { get; set; }
        public string SizeValue { get; set; }
        public string ColorName { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
        public long Price { get; set; }
    }
}
