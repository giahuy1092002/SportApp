using SportApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Model.SportProductVariantModel
{
    public class CreateSportProductVariantModel
    {
        public long Price { get; set; }
        public Guid SportProductId { get; set; }
        public Guid ColorId { get; set; }
        public string EndPoint {  get; set; }
    }
}
