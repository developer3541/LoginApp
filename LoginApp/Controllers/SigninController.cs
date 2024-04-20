using LoginApp.Models;
using LoginApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LoginApp.Controllers
{
    public class SigninController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogIn(Signin signin)
        {
            DataTable dt = new DataTable();
            bool res = false;
            DataRow dr;
            string phash = SecretHasher.Hash(signin.Password);
            //signin.Password = phash;
            dt = DB.LogIn(signin);
            dr = dt.Rows[0];
            string hash = dr["PasswordHash"].ToString();
            res = SecretHasher.Verify(signin.Password, hash);

            if (res)
            {
                Welcome welcome = new Welcome();
                welcome.Username = dr["Username"].ToString();
                welcome.Email = dr["Email"].ToString();
                welcome.FirstName = dr["FirstName"].ToString();
                welcome.LastName = dr["LastName"].ToString();
                return View("Home", welcome);
            }
            return View("Fail");
        }

    }
}
