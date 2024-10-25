using Microsoft.AspNetCore.SignalR;
using SportApp_Business.Dtos.TimeSlotDtos;
using System.Threading.Tasks;

namespace SportApp_Business.Hubs
{
    public class GetSchedulerHub : Hub
    {
        // Hub context for sending messages
        private readonly IHubContext<GetSchedulerHub> _hubContext;

        public GetSchedulerHub(IHubContext<GetSchedulerHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendScheduler(Guid sportFieldId, Guid timeSlotId)
        {
            await _hubContext.Clients.All.SendAsync("GetScheduler", sportFieldId, timeSlotId);
        }
    }

}
