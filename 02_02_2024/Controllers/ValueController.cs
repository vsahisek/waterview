using waterview.Data.Model;
using waterview.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace waterview.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ValueController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ValueController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("get-values")]
        public IActionResult GetListofValues()
        {
            var list = _context.Values.Include(v => v.Station).ToList();
            return StatusCode(200, new JsonResult(list));
        }
        [HttpPost]
        [Route("add-values")]
        public async Task<IActionResult> AddValue([FromBody] Value value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var station = await _context.Stations.FindAsync(value.StationId);
            if (station == null)
            {
                return NotFound($"Station with ID {value.StationId} not found.");
            }

            value.TimeStamp = DateTime.Now; 

            _context.Values.Add(value);
            await _context.SaveChangesAsync();

            var valueWithStation = await _context.Values.Include(v => v.Station).FirstOrDefaultAsync(v => v.Id == value.Id);
            _context.SaveChanges();
            return Ok(valueWithStation);
        }
    }
}
