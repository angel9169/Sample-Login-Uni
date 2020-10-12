using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HttpSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            bool isValid = true;

            ViewData["UsernameValue"] = Username;
            ViewData["PasswordValue"] = Password;

            if (string.IsNullOrEmpty(Username))
            {
                ViewData["Username"] = "This field is required!";
                isValid = false;
            }

            if (string.IsNullOrEmpty(Password))
            {
                ViewData["Password"] = "This field is required!";
                isValid = false;
            }

            if (!isValid)
                return View();

            if (Username== "angel" && Password=="123")
                return RedirectToAction("Index", "Home");
            else
            {
                ViewData["AuthenticationError"] = "Invalid username or password!";
                return View();
            }
        }

        [HttpGet]
        public IActionResult CheckboxesTest()
        {
            return View();
        }

        [HttpPost]
        public string CheckboxesTest(bool isAdmin,int[] groups)
        {
            string result = "";
            ViewData["isAdmin"] = isAdmin;
            result += $"isAdmin: {isAdmin} \n";
            for (int i = 0; i < groups.Length; i++)
            {
                result += $"Group: {groups[i]} \n";
            }

            return result;
        }
    }
}
