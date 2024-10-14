using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Model.SportFieldModel
{
    public class UpdateSportFieldModel
    {
        public Guid SportFieldId { get; set; }
        public string Name { get; set; }
        public string Sport { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}
