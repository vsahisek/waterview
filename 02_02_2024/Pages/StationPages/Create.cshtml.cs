using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using waterview.Data;
using waterview.Data.Model;
using static System.Collections.Specialized.BitVector32;

namespace _02_02_2024.Pages.StationPages
{
    public class CreateModel : PageModel
    {
        private readonly waterview.Data.ApplicationDbContext _context;

        public CreateModel(waterview.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Station Station { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(Station station)
        {
          if (!ModelState.IsValid || _context.Stations == null || Station == null)
            {
                return Page();
            }
            if (_context.Stations.Where(x => x.Name.Equals(station.Name)).Any())
            {
                return StatusCode(400,
                    new JsonResult("Duplicate are not allowed. Sorry."));
            }
            _context.Stations.Add(Station);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
