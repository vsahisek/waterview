using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using waterview.Data;
using waterview.Data.Model;

namespace _02_02_2024.Pages.StationPages
{
    public class IndexModel : PageModel
    {
        private readonly waterview.Data.ApplicationDbContext _context;

        public IndexModel(waterview.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Station> Station { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Stations != null)
            {
                Station = await _context.Stations
                    .OrderByDescending(v => v.Name)
                    .ToListAsync();
            }
        }
    }
}
