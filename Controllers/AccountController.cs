using Microsoft.AspNetCore.Mvc;

namespace Code_Academy___Conference_Management_System.Controllers
{
    public class AccountController : Controller
    {
        public Task<IActionResult> SignUp()
        {
            return View();
        }
    }
}
