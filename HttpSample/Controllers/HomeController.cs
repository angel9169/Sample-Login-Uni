using Microsoft.AspNetCore.Mvc;
using SampleLogin.ViewModels.Home;

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
        public IActionResult Login(LoginVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            bool isAuthenticated = false;
            if (model.Username == "angel" && model.Password == "123")
                isAuthenticated = true;
            else if (model.Username == "dani" && model.Password == "123")
                isAuthenticated = true;
            else if (model.Username == "george" && model.Password == "123")
                isAuthenticated = true;

            if (!isAuthenticated)
            {
                ModelState.AddModelError("AuthenticationFailed", "Incorrect username and password!");
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
