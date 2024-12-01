using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Dtos.CustomerDtos;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.CustomerQuery
{
    public class GetAllCustomerQuery : IQuery<List<CustomerDto>>
    {
        public class GetAllCustomerHandler : IQueryHandler<GetAllCustomerQuery,List<CustomerDto>>
        {
            private readonly SportAppDbContext _context;
            private readonly IMapper _mapper;   
            public GetAllCustomerHandler(SportAppDbContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<CustomerDto>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var listCustomer = await _context.Customer
                        .Include(c=>c.User)
                        .ToListAsync();
                    return _mapper.Map<List<CustomerDto>>(listCustomer);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                } 
                
            }
        }
    }
}
