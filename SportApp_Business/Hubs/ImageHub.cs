using Microsoft.AspNetCore.SignalR;
using SportApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Hubs
{
    public class ImageHub : Hub
    {
        private readonly IHubContext<ImageHub> _hubContext;

        public ImageHub(IHubContext<ImageHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task AddSportFieldImage(Image image)
        {
            await _hubContext.Clients.All.SendAsync("AddSportFieldImage", image);
        }
        public async Task DeleteSportFieldImage(Guid imageId)
        {
            await _hubContext.Clients.All.SendAsync("DeleteSportFieldImage",imageId);
        }
    }
}
