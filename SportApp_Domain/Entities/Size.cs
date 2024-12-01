using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class Size
    {
        public Guid Id { get; set; }
        public string Value { get; set; }

    }
}
