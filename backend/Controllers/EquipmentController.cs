using backend.Data;
using backend.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using shared;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<EquipmentHub> _hubContext;
        private readonly ILogger<EquipmentController> _logger;

        public EquipmentController(ApplicationDbContext context, IHubContext<EquipmentHub> hubContext, ILogger<EquipmentController> logger)
        {
            _context = context;
            _hubContext = hubContext;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipment>>> GetEquipment()
        {
            return await _context.Equipment.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Equipment>> GetEquipment(int id)
        {
            var equipment = await _context.Equipment.FindAsync(id);

            if (equipment == null)
            {
                return NotFound();
            }

            return equipment;
        }

        [HttpPut("{id}/state")]
        public async Task<IActionResult> UpdateEquipmentState(int id, [FromBody] EquipmentState newState)
        {
            try
            {
                var equipment = await _context.Equipment.FindAsync(id);
                if (equipment == null)
                {
                    return NotFound();
                }

                equipment.CurrentState = newState;
                await _context.SaveChangesAsync();

                await _hubContext.Clients.All.SendAsync("ReceiveEquipmentStateUpdate", equipment);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error updating equipment: {Id}", id);
                return StatusCode(500);
            }            
        }
    }
}

