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
    public class GetBookingByOwner : IQuery<BookingListDto>
    {
        public Guid OwnerId { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public class GetBookingByOwnerHandler : IQueryHandler<GetBookingByOwner,BookingListDto>
        {
            private readonly SportAppDbContext _context;
            private readonly IMapper _mapper;
            public GetBookingByOwnerHandler(SportAppDbContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BookingListDto> Handle(GetBookingByOwner request, CancellationToken cancellationToken)
            {
                var bookings = await _context.Booking
                    .Include(b=>b.SportField)
                    .Where(b => b.SportField.OwnerId == request.OwnerId).ToListAsync();
                var count = bookings.Count;
                bookings = bookings.Skip((request.PageNumber-1)*request.PageSize).Take(request.PageSize).ToList(); 
                var list = _mapper.Map<List<BookingDto>>(bookings);
                return new BookingListDto
                {
                    Count = count,
                    BookingList = list
                };
            }
        }
    }
}
