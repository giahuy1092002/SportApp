using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Dtos.BookingDtos;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.BookingQuery
{
    public class GetBookingByCustomer : IQuery<BookingListDto>
    {
        public Guid CustomerId { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string? Status {  get; set; }
        public class GetBookingByCustomerHandler : IQueryHandler<GetBookingByCustomer, BookingListDto>
        {
            private readonly SportAppDbContext _context;
            private readonly IMapper _mapper;
            public GetBookingByCustomerHandler(SportAppDbContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BookingListDto> Handle(GetBookingByCustomer request, CancellationToken cancellationToken)
            {
                var list = await _context.Booking
                    .Include(b=>b.SportField)
                    .Where(b => b.CustomerId == request.CustomerId).ToListAsync();
                if(!String.IsNullOrEmpty(request.Status))
                {
                    list = list.Where(b=>b.Status.ToString() == request.Status).ToList();
                }    
                int count = list.Count;
                list = list.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
                var result = _mapper.Map<List<BookingDto>>(list);
                return new BookingListDto
                {
                    BookingList = result,
                    Count = count
                };
            }
        }
    }
}
