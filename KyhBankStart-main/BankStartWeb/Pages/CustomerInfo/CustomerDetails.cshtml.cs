using BankStartWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BankStartWeb.Pages.CustomerInfo
{
    public class CustomerDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CustomerDetailsModel (ApplicationDbContext context)
        {
            _context = context;
        }


        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customers
                        .Include(a => a.Accounts)
                            .ThenInclude(t => t.Transactions)
                        .FirstOrDefaultAsync(m => m.Id == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
