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
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ValuesController(ApplicationDbContext context)
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

            // Zkontrolujte, zda stanice existuje
            var station = await _context.Stations.FindAsync(value.StationId);
            if (station == null)
            {
                return NotFound($"Station with ID {value.StationId} not found.");
            }

            value.TimeStamp = DateTime.Now; // Nastavte aktuální čas jako časové razítko

            _context.Values.Add(value);
            await _context.SaveChangesAsync();

            // Načtěte hodnotu znovu se zahrnutím stanice
            var valueWithStation = await _context.Values.Include(v => v.Station).FirstOrDefaultAsync(v => v.Id == value.Id);
            _context.SaveChanges();
            return Ok(valueWithStation);
        }
    }
}
