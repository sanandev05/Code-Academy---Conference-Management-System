using Code_Academy___Conference_Management_System.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Code_Academy___Conference_Management_System.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventTypeService _eventTypeService;
       // private readonly IEventTypeService _eventTypeService;
        public IActionResult Index()
        {
            return View();
        }
    }
}
