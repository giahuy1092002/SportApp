using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories.Interfaces
{
    public interface IGetHtmlBodyRepository
    {
        Task<string> GetBody(string type);
    }
}
