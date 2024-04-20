using LoginApp.Models;
using LoginApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

namespace LoginApp.Controllers
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
            return View("Home");
        }

        public IActionResult Register(Register register)
        {
            bool result = false;
            if (register.Password != null)
            {
                string hash = SecretHasher.Hash(register.Password);
                register.Password = hash;
                result = DB.Register(register);
            }
            if (result)
            {
                return View();
            }
            else
            {
                return View("Error");
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