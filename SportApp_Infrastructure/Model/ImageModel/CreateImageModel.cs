using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Model.ImageModel
{
    public class CreateImageModel
    {
        public string PictureUrl { get; set; }
        public string Type { get; set; }
        public string PublicId { get; set; }
        public Guid SportFieldId { get; set; }
    }
}
