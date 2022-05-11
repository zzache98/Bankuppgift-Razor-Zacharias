using BankStartWeb.Data;
using BankStartWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BankStartWeb.Pages.Account
{
    public class TransferModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IManageAccount _manageAccount;

        [BindProperty]
        [Required]
        [Range(1, 1000000)]
        public decimal Amount { get; set; }

        [BindProperty(SupportsGet = true)]
        public int AccountId { get; set; }

        
        [BindProperty]
        [Required]
        public int ReceiverId { get; set; }

        public TransferModel(ApplicationDbContext context, IManageAccount manageAccount)
        {
            _context = context;
            _manageAccount = manageAccount;
        }






        public void OnGet(int accountId)
        {
        }

        public IActionResult OnPost(int accountId)
        {
            var receiverAccountFound = _context.Accounts.Find(ReceiverId)!=null;
            if(!receiverAccountFound)
            {
                ModelState.AddModelError(nameof(ReceiverId), "Please transfer to a valid account!");
            }
            if (ModelState.IsValid)
            {

                var response = _manageAccount.Transfer(accountId, receiverId: ReceiverId, amount: Amount);

                if (response == IManageAccount.ErrorCode.Ok)
                    return RedirectToPage("CustomerTransactionDetails", new { Id = accountId });


                if (response == IManageAccount.ErrorCode.AccountNotFound)
                {
                    ModelState.AddModelError(nameof(ReceiverId), "Account Not Found");
                }

            }

            return Page();
        }
    }
}
