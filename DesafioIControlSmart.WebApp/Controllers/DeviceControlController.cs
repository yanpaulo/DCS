using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioIControlSmart.Data;
using DesafioIControlSmart.WebApp.Data;
using DesafioIControlSmart.WebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DesafioIControlSmart.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceControlController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<MessageHub> _hubContext;

        public DeviceControlController(ApplicationDbContext context, IHubContext<MessageHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        [Route("camera/{id}")]
        public IActionResult ControlCamera(int id, [FromQuery]DeviceStatus status)
        {
            var camera = _context.Cameras.Find(id);
            if (camera == null)
            {
                return NotFound();
            }
            camera.Status = status;

            _hubContext.Clients.All.SendAsync("ChangeCameraStatus", camera);

            return Ok();
        }

        [Route("gate/{id}")]
        public IActionResult ControlGate(int id, [FromQuery]DeviceStatus status)
        {
            var gate = _context.Gates.Find(id);
            if (gate == null)
            {
                return NotFound();
            }
            gate.Status = status;
            _hubContext.Clients.All.SendAsync("ChangeGateStatus", gate);

            return Ok();
        }
    }
}