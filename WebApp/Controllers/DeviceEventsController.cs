using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DesafioIControlSmart.Data;
using DesafioIControlSmart.WebApp.Data;

namespace DesafioIControlSmart.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceEventsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DeviceEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DeviceEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeviceEvent>>> GetDeviceEvents()
        {
            return await _context.DeviceEvents.ToListAsync();
        }

        // GET: api/DeviceEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeviceEvent>> GetDeviceEvent(int id)
        {
            var deviceEvent = await _context.DeviceEvents.FindAsync(id);

            if (deviceEvent == null)
            {
                return NotFound();
            }

            return deviceEvent;
        }

        // PUT: api/DeviceEvents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeviceEvent(int id, DeviceEvent deviceEvent)
        {
            if (id != deviceEvent.Id)
            {
                return BadRequest();
            }

            _context.Entry(deviceEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceEventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DeviceEvents
        [HttpPost]
        public async Task<ActionResult<DeviceEvent>> PostDeviceEvent(DeviceEvent deviceEvent)
        {
            deviceEvent.Timestamp = DateTimeOffset.Now;
            _context.Update(deviceEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeviceEvent", new { id = deviceEvent.Id }, deviceEvent);
        }

        // DELETE: api/DeviceEvents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeviceEvent>> DeleteDeviceEvent(int id)
        {
            var deviceEvent = await _context.DeviceEvents.FindAsync(id);
            if (deviceEvent == null)
            {
                return NotFound();
            }

            _context.DeviceEvents.Remove(deviceEvent);
            await _context.SaveChangesAsync();

            return deviceEvent;
        }

        private bool DeviceEventExists(int id)
        {
            return _context.DeviceEvents.Any(e => e.Id == id);
        }
    }
}
