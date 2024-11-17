using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Model.SubCategoryModel
{
    public class UpdateSubCategoryModel
    {
        public Guid SubCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
