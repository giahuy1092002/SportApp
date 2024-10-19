using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Model.RatingModel
{
    public class CreateRatingModel
    {
        public int NumberOfStar {  get; set; }
        public string? Comment { get; set; }
        public Guid CustomerId { get; set; }
        public Guid SportFieldId { get; set; }
    }
}
