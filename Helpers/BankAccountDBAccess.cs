using Individual_Project_2.Models;
using Individual_Project_2.Models.Account;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;

namespace Individual_Project_2.Helpers
{
    public class BankAccountDBAccess
    {
        private readonly string? connectionString;

        public BankAccountDBAccess(IConfiguration config) 
        {
            connectionString = config.GetConnectionString("DefaultConnection");
        }
        public List<BankAcc> GetBankAccounts()
        {
            List<BankAcc> bankAccounts = new List<BankAcc>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT [AccountID],[UserID],[AccountName],[CurrentBalance] FROM BankAccount";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                     using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int accountIdOrd = reader.GetOrdinal("AccountID");
                        int userIdOrd = reader.GetOrdinal("UserID");
                        int accountNameOrd = reader.GetOrdinal("AccountName");
                        int balanceOrd = reader.GetOrdinal("CurrentBalance");

                        while (reader.Read())
                        {
                            var bankAcc = new BankAcc();
                            bankAcc.AccountID = reader.GetGuid(accountIdOrd);
                            //bankAcc.AccountID = (Guid)reader["AccountID"];
                            //bankAcc.AccountID = reader.GetGuid(0);
                            bankAcc.UserID = reader.GetGuid(userIdOrd);
                            bankAcc.AccountName = reader.GetString(accountNameOrd);

                            decimal balance = reader.GetDecimal(balanceOrd);
                            bankAcc.UpdateBalance(balance);
    
                            bankAccounts.Add(bankAcc);
                        }
                    }

                }
            }
            //teacher demo data
            //#region MyRegion

            //BankAcc bankAcc1 = new BankAcc
            //{
            //    AccountID = Guid.NewGuid(),
            //    UserID = Guid.NewGuid(),
            //    AccountName = "Checking Account",
            //};
            //bankAcc1.UpdateBalance(1500.00m);
            //BankAcc bankAcc2 = new BankAcc
            //{
            //    AccountID = Guid.NewGuid(),
            //    UserID = Guid.NewGuid(),
            //    AccountName = "Savings Account",

            //};
            //bankAcc2.UpdateBalance(3000.00m);
            //bankAccounts.Add(bankAcc1);
            //bankAccounts.Add(bankAcc2);
            //#endregion

            return bankAccounts;
        }
        public BankAcc? GetBankAccountById(Guid id)
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = "SELECT * FROM BankAccount WHERE AccountID = @id";
            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new BankAcc(
                    reader.GetGuid(reader.GetOrdinal("AccountID")),
                    reader.GetGuid(reader.GetOrdinal("UserID")),
                    reader.GetString(reader.GetOrdinal("AccountName")),
                    (decimal)reader["CurrentBalance"]);
            }
            return null;
        }

        public void UpdateBankAccount(BankAcc account)
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = "UPDATE BankAccount SET AccountName = @name, CurrentBalance = @balance WHERE AccountID = @id";
            var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", account.AccountID);
            cmd.Parameters.AddWithValue("@balance", account.CurrentBalance);
            cmd.Parameters.AddWithValue("@name", account.AccountName);

            cmd.ExecuteNonQuery();
        }
    }
}
