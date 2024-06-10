using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment.Models;

namespace Assignment.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly Assignment.Models.MyStoreContext _context;

        public CreateModel(Assignment.Models.MyStoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "StaffId");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Orders == null || Order == null)
            {
                return Page();
            }

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
