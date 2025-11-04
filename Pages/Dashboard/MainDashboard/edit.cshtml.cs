using Individual_Project_2.Helpers;
using Individual_Project_2.Models;
using Individual_Project_2.Models.Dashboard.MainDashboard;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace Individual_Project_2.Pages.Dashboard.MainDashboard
{
    public class editModel : PageModel
    {        
        public editModel(IConfiguration config)
        {
            _config = new BankAccountDBAccess(config);
        }
        private readonly BankAccountDBAccess _config;

        [BindProperty]
        required
        public BankAcc AccountDetails { get; set; }

        [BindProperty]
        public decimal AmountToAdd { get; set; }

        public IActionResult OnGet(Guid id)
        {
            var account = _config.GetBankAccountById(id);
            if(account == null)
            {
                return NotFound();
            }
            AccountDetails = account;
            return Page();
            
        }
       
        public IActionResult OnPost(Guid id)
        {
            var account = _config.GetBankAccountById(id);
            if (account == null)

            {
                return NotFound();
            }

            account.AccountName = AccountDetails.AccountName;
            Console.WriteLine($"Loaded account: {AccountDetails.AccountName}, {AccountDetails.CurrentBalance}");


            if (AmountToAdd != 0)
            {
                account.UpdateBalance(AmountToAdd);
            }

            _config.UpdateBankAccount(account);

            return RedirectToPage("/Dashboard/MainDashboard/Dashboard");

        }


    }
}
