using Microsoft.AspNetCore.Http;
using Service;
using SportApp_Business.Common;
using SportApp_Domain.Entities;
using SportApp_Domain.Entities.OrderAggregate;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Model.PaymentModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using SportApp_Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.OrderCommand
{
    public class CreateOrderCommand : ICommand<string>
    {
        public ShippingAddress ShippingAddress { get; set; }
        public string BuyerId { get; set; }
        public class CreateOrderHandler : ICommandHandler<CreateOrderCommand,string>
        {
            private readonly SportAppDbContext _context;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IVnPayService _vnPayService;
            private readonly IHttpContextAccessor _httpContextAccessor;
            public CreateOrderHandler(SportAppDbContext context,IUnitOfWork unitOfWork,IVnPayService vnPayService,IHttpContextAccessor httpContextAccessor)
            {
                _context = context;
                _unitOfWork = unitOfWork;
                _vnPayService = vnPayService;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<string> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var cart = await _unitOfWork.Carts.RetriveCart(request.BuyerId);
                    var items = new List<OrderItem>();
                    foreach (var item in cart.Items)
                    {
                        var orderItem = new OrderItem
                        {
                            SportProductVariant = item.SportProductVariant,
                            Price = item.SportProductVariant.Price,
                            Quantity = item.Quantity
                        };
                        items.Add(orderItem);
                    }
                    var subtotal = items.Sum(item => item.Price * item.Quantity);
                    var deliveryFee = subtotal > 10000 ? 0 : 500;
                    var order = new Order
                    {
                        Items = items,
                        BuyerId = request.BuyerId,
                        SubTotal = subtotal,
                        DeliveryFee = deliveryFee,
                        ShippingAddress = request.ShippingAddress,
                    };
                    _context.Order.Add(order);
                    _context.Cart.Remove(cart);
                    _context.SaveChanges();
                    var model = new PaymentInformationModel
                    {
                        BookingType = "Thanh toán đơn hàng",
                        BookingDescription = $"Thanh toán đơn hàng {order.Id.ToString()}",
                        Amount = subtotal,
                        BookingId = order.Id.ToString(),
                        Name = $"Thanh toán đơn hàng {order.Id.ToString()}"
                    };
                    var url = _vnPayService.CreatePaymentUrl(model, _httpContextAccessor.HttpContext);
                    return url;
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
