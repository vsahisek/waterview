using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using waterview.Data;
using waterview.Data.Model;

namespace _02_02_2024.Pages.ValuePages
{
    public class IndexModel : PageModel
    {
        private readonly waterview.Data.ApplicationDbContext _context;

        public IndexModel(waterview.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Value> Values { get;set; } = default!;
        public IList<Station> Stations { get;set; }
        [BindProperty(SupportsGet = true)]
        public int? SelectedStationId { get; set; }
        public async Task OnGetAsync()
        {
            Stations = await _context.Stations.ToListAsync();

            if (SelectedStationId.HasValue)
            {
                Values = await _context.Values
                    .Where(v => v.StationId == SelectedStationId.Value)
                    .Include(v => v.Station)
                    .OrderByDescending(v => v.TimeStamp)
                    .ToListAsync();
            }
            else
            {
                Values = await _context.Values
                    .Include(v => v.Station)
                    .OrderByDescending(v => v.TimeStamp)
                    .ToListAsync();
            }
        }
    }
}
