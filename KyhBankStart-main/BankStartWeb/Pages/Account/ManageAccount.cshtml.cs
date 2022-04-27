using BankStartWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

//namespace BankStartWeb.Pages.CustomerInfo
//{
//    [BindProperties]
//    public class ManageAccountModel : PageModel
//    {
//        private readonly BankStartWeb.Data.ApplicationDbContext _context;

//        public ManageAccountModel(BankStartWeb.Data.ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public decimal AccountBalance { get; set; }
//        public Customer Customer { get; set; }
//        public decimal DepositAmount { get; set; }
//        public decimal WithdrawAmount { get; set; }
//        public async Task<IActionResult> OnGetAsync(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            Customer = await _context.Customers
//                .Include(a => a.Account)
//                .ThenInclude(t => t.Transactions)
//                .AsNoTracking()
//                .FirstOrDefaultAsync(m => m.ID == id);

//            if (Customer == null)
//            {
//                return NotFound();
//            }

//            if (!Customer.Account.userVerified)
//            {
//                return RedirectToPage("./Login");
//            }

//            AccountBalance = Customer.Account.Balance;

//            return Page();
//        }

//        public async Task<IActionResult> OnPostWithdraw(int? id)
//        {
//            Customer = await _context.Customers
//                        .Include(a => a.Account)
//                            .ThenInclude(t => t.Transactions)
//                        .AsNoTracking()
//                        .FirstOrDefaultAsync(m => m.ID == id);

//            int transactionID = _context.Transactions.Count();
//            // Get Starting Balance
//            decimal startingBalance = Customer.Account.Balance;

//            if (startingBalance < WithdrawAmount)
//            {
//                // TODO: Use Alert or attributes to display message
//                // For now just reload the page if withdrawal amount is too much.
//                AccountBalance = Customer.Account.Balance;
//                return Page();
//            }
//            // Add transaction with customer account as FK
//            addTransaction(startingBalance, WithdrawAmount, Customer.ID, transactionID);
//            // Change current balance to reflect transaction
//            Customer.Account.Balance -= WithdrawAmount;

//            _context.Update(Customer);

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!_context.Customers.Any(e => e.ID == Customer.ID))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            AccountBalance = Customer.Account.Balance;

//            return Page();
//        }

//    }
//}
