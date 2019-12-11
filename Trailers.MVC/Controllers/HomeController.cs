using System;
using System.Collections.Generic;
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
            List<Company> companies = new List<Company>()
            {
                new Company()
                {
                    Name = "Alfreds Futterkiste",
                    Contact = "Maria Anders",
                    Country = "Germany"
                },
                new Company()
                {
                    Name = "Ernst Handel",
                    Contact = "Roland Mendel",
                    Country = "Austria"
                },
                new Company()
                {
                    Name = "Island Trading",
                    Contact = "Helen Bennett",
                    Country = "UK"
                },
                new Company()
                {
                    Name = "Laughing Bacchus Winecellars",
                    Contact = "Yoshi Tannamuri",
                    Country = "Canada"
                },
                new Company()
                {
                    Name = "Newly Added auto",
                    Contact = "Yoshi Tannamuri",
                    Country = "Canada"
                }
            };
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
