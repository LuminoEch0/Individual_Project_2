using Individual_Project_2.Helpers.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Individual_Project_2.Models.Transaction
{
    public class Transaction
    {
        public Guid TransactionID { get; set; } // pk

        public Guid CategoryID { get; set; } // fk - category

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        [StringLength(256)]
        public string? Description { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public TransactionType Type { get; set; } // enum 0:expense, 1:income

    }
}
