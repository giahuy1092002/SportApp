using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Dtos.CustomerDtos;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.CustomerQuery
{
    public class GetCustomer : IQuery<CustomerDtoDetail>
    {
        public Guid CustomerId { get; set; }
        public class GetCustomerHandler : IQueryHandler<GetCustomer, CustomerDtoDetail>
        {
            private readonly SportAppDbContext _context;
            private readonly IMapper _mapper;
            public GetCustomerHandler(SportAppDbContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CustomerDtoDetail> Handle(GetCustomer request, CancellationToken cancellationToken)
            {
                var customer =  await _context.Customer
                    .Include(c=>c.User)
                    .FirstOrDefaultAsync(c => c.Id == request.CustomerId);
                var result = _mapper.Map<CustomerDtoDetail>(customer);  
                return result;
            }
        }
    }
}
