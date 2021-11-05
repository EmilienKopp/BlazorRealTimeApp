using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRealTimeApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {

        //The service.addsignalR automatically injects this context
        private readonly IHubContext<NotificationHub> _hubContext;
        
        public NotificationsController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] string title)
        {
            await _hubContext.Clients.All.SendAsync("notification", $"{DateTime.Now} : {title}");
            return Ok("Notification has been sent successfully");
        }

    }
}
