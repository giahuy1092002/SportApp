using SportApp_Business.Common;
using SportApp_Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.SportFieldQuery
{
    public class GetGeoCodeQuery : IQuery<GeoObject>
    {
        public string Address { get; set; }
        public class GetGeoCodeHandler : IQueryHandler<GetGeoCodeQuery, GeoObject>
        {
            private readonly GeoCodeService _geoCodeService;
            public GetGeoCodeHandler(GeoCodeService geoCodeService)
            {
                _geoCodeService = geoCodeService;
            }
            public async Task<GeoObject> Handle(GetGeoCodeQuery request,CancellationToken cancellationToken)
            {
                return await _geoCodeService.ConvertAddress(request.Address);
            }
        }
    }
}
