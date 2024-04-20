using Microsoft.AspNetCore.Mvc;

namespace LoginApp.Controllers
{
    public class SignupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
