using waterview.Data;
using waterview.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace waterview.Controllers
{
    [ApiController]
    [Route("api/")]
    public class StationController : Controller
    {
        private ApplicationDbContext _context { get; set; } 
        public StationController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("get-stations")]
        public IActionResult GetListofStation()
        {
            var list = _context.Stations.ToList();
            return StatusCode(200, new JsonResult(list));
        }
        [HttpPost]
        [Route("add-stations")]
        public IActionResult AddStations(Station station) 
        {
            if(_context.Stations.Where(x=>x.Name.Equals(station.Name)).Any())
            {
                return StatusCode(400,
                    new JsonResult("Duplicate are not allowed. Sorry."));
            }
            _context.Stations.Add(station);
            _context.SaveChanges();
            return StatusCode(200,
                new JsonResult("Station has been succesfully created"));
        }
    }
}
