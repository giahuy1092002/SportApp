using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Helper
{
    public  static class CreateEndpoint
    {
        public static string AddEndpoint(string name)
        {
            var array = name.ToLower().Split(" ");
            return string.Join("-", array);
        }
    }
}
