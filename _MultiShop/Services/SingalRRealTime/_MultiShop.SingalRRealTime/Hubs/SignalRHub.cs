using _MultiShop.SingalRRealTime.Services;
using _MultiShop.SingalRRealTime.Services.SignalMessageServices;
using _MultiShop.SingalRRealTime.Services.SignalRCommentServices;
using Microsoft.AspNetCore.SignalR;

namespace _MultiShop.SingalRRealTime.Hubs
{
    public class SignalRHub: Hub
    {
        private readonly ISignalRCommentService _signalRCommentService;

        public SignalRHub(ISignalRCommentService signalRCommentService)
        {
            _signalRCommentService = signalRCommentService;
        }

        public async Task SendStatisticCount()
        {
            var getTotalCommentCount = await _signalRCommentService.GetTotalCommentCount();
            await Clients.All.SendAsync("ReceiveCommentCount", getTotalCommentCount);
        }
    }
}
