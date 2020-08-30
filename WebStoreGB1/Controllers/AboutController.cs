using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebStoreGB1.ViewModels;

namespace WebStoreGB1.Controllers
{
    public class AboutController : Controller
    {
        private readonly IConfiguration _configuration;

        public AboutController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly About Company = new About();

        public IActionResult Index()
        {
            Company.Name = _configuration["CompanyName"];
            Company.Year = int.Parse(_configuration["CompanyYear"]);
            return View(Company);
        }
    }
}