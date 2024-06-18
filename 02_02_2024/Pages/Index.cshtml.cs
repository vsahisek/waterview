using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using waterview.Data.Model;

namespace waterview.Pages
{
    public class IndexModel : PageModel
    {
        private readonly waterview.Data.ApplicationDbContext _context;
        public IndexModel(waterview.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Value> LatestValues { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Values != null)
            {
                LatestValues = await _context.Values
                    .Include(v => v.Station)
                    .GroupBy(v => v.StationId)
                    .Select(g => g.OrderByDescending(v => v.TimeStamp).FirstOrDefault())
                    .AsNoTracking()
                    .ToListAsync();
            }
        }

    }

}