using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Individual_Project_2.Models.Dashboard.MainDashboard
{
    public class BankAccount
    {
        public Guid AccountID { get; set; } //pk

        public Guid UserID { get; set; } //fk - user

        [Required]
        [StringLength(100)]
        public required string AccountName { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal CurrentBalance { get; private set; } = 0.00m;
        public void UpdateBalance(decimal amount)
        {
            CurrentBalance += amount;
        }
    }
}
