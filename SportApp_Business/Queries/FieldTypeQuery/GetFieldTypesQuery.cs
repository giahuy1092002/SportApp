using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.FieldTypeQuery
{
    public class GetFieldTypesQuery : IQuery<List<FieldType>>
    {
        public class GetFieldTypesHandler : IQueryHandler<GetFieldTypesQuery, List<FieldType>>
        {
            private readonly SportAppDbContext _context;
            public GetFieldTypesHandler(SportAppDbContext context)
            {
                _context = context;
            }
            public async Task<List<FieldType>> Handle(GetFieldTypesQuery request,CancellationToken cancellationToken)
            {
                try
                {
                    var fieldtypeList = await _context.FieldType
                        .ToListAsync();
                    return fieldtypeList;
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                } 
                
            }
        }
    }
}
