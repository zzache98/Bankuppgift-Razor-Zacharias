using BankStartWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BankStartWeb.Pages.Account
{

        public class WithdrawModel : PageModel
        {
            private readonly IManageAccount _manageAccount;
            private readonly IUpdateAccount _updateAccount;

            [BindProperty]
            [Required]
            [Range(1, 100000, ErrorMessage = "You can only withdraw an amount within the allowed range of 1-100,000!")]
            public decimal Amount { get; set; }
            
            [BindProperty(SupportsGet = true)]
            public int AccountId { get; private set; }

            public WithdrawModel(IManageAccount manageAccount, IUpdateAccount updateAccount)
            {
                _manageAccount = manageAccount;
                _updateAccount = updateAccount;
                
            }

            public void OnGet(int accountId)
            {
                AccountId = accountId;
            }


            public IActionResult OnPost(int accountId)
            {

                if (ModelState.IsValid)
                {
                    var status = _manageAccount.WithDraw(accountId, Amount);
                    if (status == IManageAccount.ErrorCode.Ok)
                    {
                        return RedirectToPage("CustomerTransactionDetails", new { Id = accountId});
                    }
                    ModelState.AddModelError("Amount", "Invalid Amount");
            }

                return Page();

            }
        }
    
}

