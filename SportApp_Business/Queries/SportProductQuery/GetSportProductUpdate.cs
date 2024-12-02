//using Microsoft.EntityFrameworkCore;
//using SportApp_Business.Common;
//using SportApp_Business.Dtos.SportProductDtos;
//using SportApp_Infrastructure;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SportApp_Business.Queries.SportProductQuery
//{
//    public class GetSportProductUpdate : IQuery<SportProductUpdateDto>
//    {
//        public Guid SportProductId { get; set; }
//        public class GetSportProductUpdateHandler : IQueryHandler<GetSportProductUpdate, SportProductUpdateDto>
//        {
//            private readonly SportAppDbContext _context;
//            public GetSportProductUpdateHandler(SportAppDbContext context)
//            {
//                _context = context;
//            }
//            public async Task<SportProductUpdateDto> Handle(GetSportProductUpdate request,CancellationToken cancellationToken)
//            {
//                var sportProduct = await _context.SportProduct
//                    .Include(s=>s.ImageProducts)
//                    .Include(s=>s.Variants)
//                        .ThenInclude(sv=>sv.Color)
//                    .Include(s => s.Variants)
//                        .ThenInclude(sv => sv.Size)
//                    .Include(s=>s.Category)
//                    .FirstOrDefaultAsync(s=>s.Id==request.SportProductId);
//                var result = new SportProductUpdateDto
//                {
//                    Name = s
//                }
//            }
//        }
//    }
//}
