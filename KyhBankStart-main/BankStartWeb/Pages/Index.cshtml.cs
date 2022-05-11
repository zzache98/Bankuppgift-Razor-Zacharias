using BankStartWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BankStartWeb.Pages
{
    public class IndexModel : PageModel
    {
        
        private readonly ApplicationDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        public int CustomerCount { get; set; }
        public int AccountCount { get; set; }
        public decimal BalanceCount { get; set; }



        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public void OnGet()
        {
            CustomerCount = _context.Customers.Count();
            AccountCount = _context.Accounts.Count();
            BalanceCount = _context.Accounts.Sum(b => b.Balance);
        }

    }
}