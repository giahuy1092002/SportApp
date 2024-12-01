using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class Image
    {
        public Guid Id { get; set; }
        public string PictureUrl { get; set; }
        public string PublicId { get; set; }
        public Guid SportFieldId { get; set; }
    }
}
