using System;
using System.ComponentModel.DataAnnotations;

namespace Individual_Project_2.Models
{
    // Represents the high-level shared expense event
    public class Debt
    {
        // PK
        [Key]
        public Guid DebtID { get; set; }

        // FK to BankAccount
        public Guid AccountID { get; set; }

        [Required, MaxLength(100)]
        public string Description { get; set; }

        public decimal TotalOriginalBillAmount { get; set; }

        public DateTime DatePaid { get; set; } = DateTime.UtcNow;

        // Calculated property (Read-only)
        public bool IsFullySettled { get; private set; }

        // Optional: Navigation property if using an ORM, but useful for clarity
        // public List<DebtorRecord> DebtorRecords { get; set; } = new List<DebtorRecord>();
    }
}
