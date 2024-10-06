using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Model.SpecModel
{
    public class CreateSpecModel
    {
        public Guid UserId { get; set; }
        public string? Skills { get; set; }
        public string? Note { get; set; }
    }
}
