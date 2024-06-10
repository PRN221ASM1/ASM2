using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment.Models;

namespace Assignment.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly Assignment.Models.MyStoreContext _context;

        public IndexModel(Assignment.Models.MyStoreContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get; set; } = new List<Order>();
        [BindProperty(SupportsGet = true)]
        public DateTime? FilterDate { get; set; }

        public async Task OnGetAsync()
        {
            if (FilterDate == null)
            {
                FilterDate = DateTime.Now;
            }

            if (_context.Orders != null)
            {
                Order = await _context.Orders
                    .Where(o => o.OrderDate == FilterDate)
                    .Include(o => o.Staff)
                    .ToListAsync();
            }
        }
    }
}
