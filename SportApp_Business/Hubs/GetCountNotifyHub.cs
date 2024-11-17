using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Hubs
{
    public class GetCountNotifyHub : Hub
    {
        private readonly IHubContext<GetSchedulerHub> _hubContext;

        public GetCountNotifyHub(IHubContext<GetSchedulerHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task GetCountNotify(Guid userId)
        {
            await _hubContext.Clients.All.SendAsync("GetCountNotify", userId);
        }
    }
}
