using SportApp_Business.Common;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Repositories.Interfaces;
using SportApp_Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.SportFieldCommand
{
    public class HandleCreateSportField : ICommand<bool>
    {
        public Guid SportFieldId { get; set; }
        public bool IsAccept {  get; set; }
        public class HandleCreateSportFieldHandler : ICommandHandler<HandleCreateSportField,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly GeoCodeService _geoCodeServie;
            public HandleCreateSportFieldHandler(IUnitOfWork unitOfWork, GeoCodeService geoCodeServie)
            {
                _unitOfWork = unitOfWork;
                _geoCodeServie = geoCodeServie;
            }
            public async Task<bool> Handle(HandleCreateSportField request, CancellationToken cancellationToken)
            {
                var sportfield = await _unitOfWork.SportFields.GetSportField(request.SportFieldId);
                var geocode = await _geoCodeServie.ConvertAddress(sportfield.Address);
                sportfield.Latitude = geocode.Latitude;
                sportfield.Longitude = geocode.Longitude;   
                if (request.IsAccept) sportfield.IsAccept = true;
                await _unitOfWork.SaveChangesAsync();
                return true;

            }
        }
    }
}
