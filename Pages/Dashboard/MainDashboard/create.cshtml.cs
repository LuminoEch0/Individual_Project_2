using Individual_Project_2.Helpers;
using Individual_Project_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Individual_Project_2.Pages.Dashboard.MainDashboard
{
    public class createModel : PageModel
    {
        //public createModel(IConfiguration config)
        //{
        //    _config = new BankAccountDBAccess(config);
        //}
        //private readonly BankAccountDBAccess _config;

        [BindProperty]
        public string AccountName { get; set; } = string.Empty;

        [BindProperty]
        public decimal InitialBalance { get; set; } = 0;

        //public IActionResult OnGet()
        //{
        //    return Page();
        //}
        //public IActionResult OnPost()
        //{
        //    if (string.IsNullOrWhiteSpace(AccountName))
        //    {
        //        ModelState.AddModelError("AccountName", "Account Name is required.");
        //        return Page();
        //    }
        //    var newAccount = new BankAcc(
        //        Guid.NewGuid(),
        //        Guid.NewGuid(), // In a real application, retrieve the actual user ID
        //        AccountName,
        //        InitialBalance
        //        );
        //    return RedirectToPage("/Dashboard/MainDashboard/Dashboard");
        //}
    }
}
