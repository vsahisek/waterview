using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using waterview.Data;
using waterview.Data.Model;

namespace _02_02_2024.Pages.StationPages
{
    public class EditModel : PageModel
    {
        private readonly waterview.Data.ApplicationDbContext _context;

        public EditModel(waterview.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Station Station { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id, Station station)
        {
            if (id == null || _context.Stations == null)
            {
                return NotFound();
            }
            if (_context.Stations.Where(x => x.Name.Equals(station.Name)).Any())
            {
                return StatusCode(400,
                    new JsonResult("Duplicate are not allowed. Sorry."));
            }
            var stations =  await _context.Stations.FirstOrDefaultAsync(m => m.Id == id);
            if (stations == null)
            {
                return NotFound();
            }
            Station = stations;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Station).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StationExists(Station.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StationExists(int id)
        {
          return (_context.Stations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
