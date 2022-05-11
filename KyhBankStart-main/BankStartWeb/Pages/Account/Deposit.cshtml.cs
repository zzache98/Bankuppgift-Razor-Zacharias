using BankStartWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BankStartWeb.Pages.Account
{
    [BindProperties]
    public class DepositModel : PageModel
    {
        private readonly IManageAccount _manageAccount;

        [Range(1, 50000, ErrorMessage = "You can only deposit an amount between 1 and 50000" )]
        [Required]
        [BindProperty]
        public decimal Amount { get; set; }

        [BindProperty(SupportsGet = true)]
        public int AccountId { get; set; }

        public DepositModel(IManageAccount manageAccount)
        {
            _manageAccount = manageAccount;
        }

        public void OnGet(int accountId)
        {
           AccountId = accountId;
        }


        public IActionResult OnPost(int accountId)
        {

            if (ModelState.IsValid)
            {
                var status = _manageAccount.Deposit(accountId, Amount);
                if (status == IManageAccount.ErrorCode.Ok)
                {
                    return RedirectToPage("CustomerTransactionDetails", new { Id = accountId });
                }
                ModelState.AddModelError("Amount", "Invalid Amount");
            }

            return Page();

        }
    }
}

