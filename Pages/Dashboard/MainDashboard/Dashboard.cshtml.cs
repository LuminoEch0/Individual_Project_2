using Individual_Project_2.Helpers;
using Individual_Project_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Individual_Project_2.Pages.Dashboard.MainDashboard
{
    public class DashboardModel : PageModel
    {
        private readonly IConfiguration configuration;
        public DashboardModel(IConfiguration config)
        {
            configuration = config;
        }
        public List<BankAcc> BankAccounts { get; set; } = new List<BankAcc>();

        public void OnGet()
        {
            BankAccountDBAccess dbAccess = new BankAccountDBAccess(configuration);
            BankAccounts = dbAccess.GetBankAccounts();
            //BankAccounts = new BankAccountDBAccess().GetBankAccounts();
        }
    }
}
