using Microsoft.AspNetCore.Mvc;

namespace Code_Academy___Conference_Management_System.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
