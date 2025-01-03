﻿using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.SportProductCommand
{
    public class AddRating : ICommand<bool>
    {
        public Guid OrderItemId { get; set; }
        public int StartRating { get; set; }
        public string Comment { get; set; }
        public Guid CustomerId { get; set; }
        public class AddRatingHandler : ICommandHandler<AddRating, bool>
        {
            private readonly SportAppDbContext _context;
            public AddRatingHandler(SportAppDbContext context)
            {
                _context = context;
            }
            public async Task<bool> Handle(AddRating request,CancellationToken cancellationToken)
            {
                var orderItem = await _context.OrderItem
                    .Include(o=>o.SportProductVariant)
                        .ThenInclude(sv=>sv.SportProduct)
                    .Include(o => o.SportProductVariant)
                        .ThenInclude(sv => sv.Size)
                    .Include(o => o.SportProductVariant)
                        .ThenInclude(sv => sv.Color)
                    .FirstOrDefaultAsync(o => o.Id == request.OrderItemId);
                var customer = await _context.Customer
                    .Include(c=>c.User)
                    .FirstOrDefaultAsync(c=>c.Id== request.CustomerId);
                var rating = new SportProductRating
                {
                    SportProductVariantName = orderItem.SportProductVariant.SportProduct.Name+" " + orderItem.SportProductVariant.Color.Name,
                    SizeValue = orderItem.SportProductVariant.Size.Value,
                    ColorName = orderItem.SportProductVariant.Color.Name,
                    StartRating = request.StartRating,
                    Comment = request.Comment,
                    SportProductVariantId = orderItem.SportProductVariantId,
                    FirstName = customer.User.FirstName,
                    LastName = customer.User.LastName,
                    Avatar = customer.User.Avatar
                };
                _context.SportProductRatings.Add(rating);
                orderItem.IsRating = true;
                _context.OrderItem.Update(orderItem);
                _context.SaveChanges();
                return await Task.FromResult(true);
            }
        }
    }
}
