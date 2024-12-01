using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Model.SportModel
{
    public class UpdateSportModel
    {
        public Guid SportId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
