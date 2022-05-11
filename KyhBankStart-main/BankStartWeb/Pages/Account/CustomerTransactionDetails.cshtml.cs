using AutoMapper;
using BankStartWeb.Data;
using BankStartWeb.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace BankStartWeb.Pages.Account
{
    public class CustomerTransactionDetailsModel : PageModel
    {
        public int AccountId { get; set; }

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CustomerTransactionDetailsModel(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        

        public class TransactionViewModel
        {
            public int Id { get; set; }
            public string Type { get; set; }
            public string Operation { get; set; }
            public DateTime Date { get; set; }
            public decimal Amount { get; set; }
            public decimal NewBalance { get; set; }
        }

        public AccountDetailViewModel Accounts { get; set; } 

        public class AccountDetailViewModel
        {
            public int Id { get; set; }
            public string AccountType { get; set; }
            public DateTime Created { get; set; }
            public decimal Balance { get; set; }
            public List<TransactionViewModel> Transactions { get; set; } = new List<TransactionViewModel>();
        }

        public IActionResult OnGetFetchMoreTransactions(int customerId, int pageNum)
        {
            var query = _context.Accounts.Where(e => e.Id == customerId)
                .SelectMany(e => e.Transactions)
                .OrderByDescending(e => e.Date).AsQueryable();

            var r = query.GetPaged(pageNum, 5);
            var map = _mapper.Map<List<TransactionViewModel>>(r.Results);

            var lastPage = pageNum == r.PageCount;

            return new JsonResult(new { items = map, lastPage = lastPage });
        }

        public IActionResult OnGet(int Id)
        {
            AccountId = Id;
            Accounts = _mapper.Map<AccountDetailViewModel>(_context.Accounts.Include(x => x.Transactions.OrderByDescending(t => t.Date).Take(5)).FirstOrDefault(x => x.Id == Id));
            if (Accounts == null) return Redirect("./CustomerInfo/CustomerDetails");
            return Page();
        }
    }
}
