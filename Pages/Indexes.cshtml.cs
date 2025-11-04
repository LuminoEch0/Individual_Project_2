using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Individual_Project_2.Pages
{
    public class IndexModel : PageModel
    {
         public List<Person> People { get; set; } = new List<Person>();

        [BindProperty]
        public Person NewPerson { get; set; } = new Person();

        [BindProperty]
        public int DeleteId { get; set; }


        private readonly IConfiguration _config;
        public IndexModel(IConfiguration config)
        {
            _config = config;
        }

        public void OnGet()
        {
            LoadPeople();
        }


        public IActionResult OnPostAdd()
        {
            string? connString = _config.GetConnectionString("DefaultConnection");
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "INSERT INTO People (Name, Email, City) VALUES (@Name, @Email, @City)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Name", NewPerson.Name);
                cmd.Parameters.AddWithValue("@Email", NewPerson.Email);
                cmd.Parameters.AddWithValue("@City", NewPerson.City);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id)
        {
            string? connString = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "DELETE FROM People WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToPage();
        }

        public IActionResult OnPostUpdate()
        {
            string? connString = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "UPDATE People SET Name=@Name, Email=@Email, City=@City WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Name", NewPerson.Name);
                cmd.Parameters.AddWithValue("@Email", NewPerson.Email);
                cmd.Parameters.AddWithValue("@City", NewPerson.City);
                cmd.Parameters.AddWithValue("@Id", NewPerson.Id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToPage();
        }

        public IActionResult OnPostEdit(int id)
        {
            string? connString = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "SELECT Id, Name, Email, City FROM People WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    NewPerson = new Person
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Email = reader.GetString(2),
                        City = reader.GetString(3)
                    };
                }
            }

            LoadPeople(); // Refresh list
            return Page(); // Stay on same page with form pre-filled
        }


        private void LoadPeople()
        {
            string? connString = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "SELECT Id, Name, Email, City FROM People ORDER BY Id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    People.Add(new Person
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Email = reader.GetString(2),
                        City = reader.GetString(3)
                    });
                }
            }
        }

        public class Person
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Email { get; set; }
            public  string? City { get; set; }
        }
    }
}
