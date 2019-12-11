using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Trailers.MVC.Models;

namespace Trailers.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Companies()
        {
            string ConnectionString = "Server=NODA;Database=AwesomeProject;User Id=AwesomeUser;Password=123qwe;";
            SqlConnection connection = new SqlConnection(ConnectionString);

            string commandText = "SELECT [ID] ,[Name] ,[Contact] ,[Location] FROM [Companies]";
            SqlCommand command = new SqlCommand(commandText, connection as SqlConnection);

            List<Company> companies = new List<Company>();

            using (var adapter = new SqlDataAdapter(command))
            {
                var resultTable = new DataTable();
                adapter.Fill(resultTable);
                
                foreach (var row in resultTable.AsEnumerable())
                {
                    Company company = new Company()
                    {
                        Name = row["Name"].ToString(),
                        Contact = row["Contact"].ToString(),
                        Country = row["Location"].ToString()
                    };
                    companies.Add(company);
                }
            }

            return View(companies);
        }

        private void ViewExample(List<Company> Model)
        {
            foreach (var company in Model)
            {
                var valami = company;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
