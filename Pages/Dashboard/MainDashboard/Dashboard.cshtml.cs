using Individual_Project_2.Helpers;
using Individual_Project_2.Models;
using Individual_Project_2.Services.Dashboard;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Individual_Project_2.Pages.Dashboard.MainDashboard
{
    public class DashboardModel : PageModel
    {
        private readonly BankAccountService _accountService;
        public DashboardModel(BankAccountService accountService)
        {
            _accountService = accountService;
        }
        public List<BankAccountModel> BankAccounts { get; set; } = new List<BankAccountModel>();

        public void OnGet()
        {
            BankAccounts = _accountService.GetAllBankAccounts();
        }
    }
}
