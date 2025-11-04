using Individual_Project_2.Data;
using Individual_Project_2.Models.Dashboard.MainDashboard;
using Microsoft.Data.SqlClient;

namespace Individual_Project_2.Services.Dashboard.MainDashboard
{
    public class BankAccountService
    {
        private readonly ConnectionManager _dbManager;

        // SQL Statement to select all accounts for a specific user ID.
        private const string SQL_GET_ACCOUNTS_BY_USER_ID =
            "SELECT AccountID, UserID, AccountName, CurrentBalance " +
            "FROM BankAccount WHERE UserID = @UserId";

        public BankAccountService(ConnectionManager dbManager)
        {
            _dbManager = dbManager;
        }

        /// <summary>
        /// Retrieves all bank accounts owned by the specified user.
        /// </summary>
        public async Task<List<BankAccount>> GetAccountsByUserId(Guid userId)
        {
            var accounts = new List<BankAccount>();

            // The 'using' statement ensures the connection is closed and disposed after use.
            using (var conn = _dbManager.GetOpenConnection())
            {
                using (var cmd = new SqlCommand(SQL_GET_ACCOUNTS_BY_USER_ID, (SqlConnection)conn))
                {
                    // Parameterized query prevents SQL injection
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        // Manually map the data from the database reader to the C# Model
                        //while (await reader.ReadAsync())
                        //{
                        //    accounts.Add(new BankAccount
                        //    {
                        //        AccountID = reader.GetGuid(0),
                        //        UserID = reader.GetGuid(1),
                        //        AccountName = reader.GetString(2),
                        //        // Important: Use GetDecimal for money types
                        //        CurrentBalance = reader.GetDecimal(3)
                        //    });
                        //}
                    }
                }
            }
            return accounts;
        }
    }
}
