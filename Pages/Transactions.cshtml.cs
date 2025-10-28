using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace Individual_Project_2.Pages
{
    public class TransactionsModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public TransactionsModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<TestItem> TestItems { get; set; } = new List<TestItem>();

        public void OnGet()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT Id, Name, Description FROM Test";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TestItems.Add(new TestItem
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Description = reader.GetString(2)
                            });
                        }
                    }
                }
            }
        }
    }

    public class TestItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}