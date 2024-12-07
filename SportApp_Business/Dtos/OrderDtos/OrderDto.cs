using SportApp_Domain.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.OrderDtos
{
    public class OrderDto
    {
        public string OrderStatus { get; set; }
        public long SubTotal { get; set; }
        public long DeliveryFee { get; set; }
        public DateTime OrderDate { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }
    public class OrderAdminDto
    {
        public string OrderStatus { get; set; }
        public long SubTotal { get; set; }
        public long DeliveryFee { get; set; }
        public DateTime OrderDate { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
    }
    public class ListOrderDto
    {
        public List<OrderDto> Orders { get; set; }
        public int Count { get; set; }
    }
    public class ListOrderAdminDto
    {
        public List<OrderAdminDto> Orders { get; set; }
        public int Count { get; set; }
    }
    public class OrderItemDto
    {
        public string PictureUrl { get; set; }
        public string Name  { get; set; }
        public string ColorName { get; set; }
        public string SizeName { get; set; }
        public int Quantity { get; set; }
        public string EndPoint { get; set; }
        public long Price { get; set; }
        public bool IsRating {  get; set; }
    }
}
