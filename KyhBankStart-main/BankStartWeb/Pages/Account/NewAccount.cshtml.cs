//using BankStartWeb.Data;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;

//namespace BankStartWeb.Pages
//{
//    public class NewAccountModel : PageModel
//    {

//        private readonly BankStartWeb.Data.ApplicationDbContext _context;

//        public NewAccountModel(BankStartWeb.Data.ApplicationDbContext context)
//        {
//            _context = context;
//        }

        
//        public IActionResult OnGet()
//        {
//            return Page();
//        }

//        public Customer Customer { get; set; }
//        public Account Account { get; set; }

//        public async Task<IActionResult> OnPostAsync()
//        {
//            if(!ModelState.IsValid)
//            {
//                return Page();
//            }

//            Account.AccountType = AccountType.CHECKING;
//            Account.Balance = 0;
//            Account.InitialTransactionDate = DateTime.Now;
//            Account.Customer = Customer;

//            Customer.Account = Account;

//            _context.Customers.Add(Customer);
//            await _context.SaveChangesAsync();

//            return RedirectToPage("./Index");
//        }
//    }
//}
