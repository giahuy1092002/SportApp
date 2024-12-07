using SportApp_Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace SportApp_Infrastructure.Repositories
{
    public class GetHtmlBodyRepository : IGetHtmlBodyRepository
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public GetHtmlBodyRepository(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public Task<string> GetBody(string type)
        {
            throw new NotImplementedException();
        }
    }
}
