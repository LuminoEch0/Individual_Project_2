using Individual_Project_2.Helpers;
using Individual_Project_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Individual_Project_2.Services.Dashboard;

namespace Individual_Project_2.Pages.Dashboard.MainDashboard
{
    public class deleteModel : PageModel
    {
        private readonly BankAccountService _accountService;

        public deleteModel(BankAccountService accountService)
        {
            _accountService = accountService;
        }
        public BankAccount? AccountDetails { get; set; }
        public IActionResult OnGet(Guid id)
        {
            var account = _accountService.GetAccountById(id);
            if (account == null)

            {
                return NotFound();
            }
            AccountDetails = account;
            return Page();
        }
        public IActionResult OnPost(Guid id)
        {
            var account = _accountService.GetAccountById(id);
            if (account == null)
            {
                return NotFound();
            }
            AccountDetails = account;
            _accountService.DeleteAccount(id);
            return RedirectToPage("/Dashboard/MainDashboard/Dashboard");
        }
    }
}

