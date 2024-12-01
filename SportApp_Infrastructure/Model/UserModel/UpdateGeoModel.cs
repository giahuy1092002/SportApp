using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Model.UserModel
{
    public class UpdateGeoModel
    {
        public Guid UserId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
