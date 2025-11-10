using Individual_Project_2.Helpers;
using Individual_Project_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Individual_Project_2.Pages.Dashboard.Category
{
    public class CategoryModel : PageModel
    {
        //public CategoryModel(IConfiguration config)
        //{
        //    _config = new BankAccountDBAccess(config);
        //}
        //private readonly BankAccountDBAccess _config;
        public BankAcc? AccountDetails { get; set; }
        //public IActionResult OnGet(Guid id)
        //{
        //    var account = _config.GetBankAccountById(id);
        //    if (account == null)

        //    {
        //        return NotFound();
        //    }
        //    AccountDetails = account;
        //    return Page();
        //}
    }
}
