using Code_Academy___Conference_Management_System.Entities;
using Code_Academy___Conference_Management_System.Models;
using Code_Academy___Conference_Management_System.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Code_Academy___Conference_Management_System.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;
        private readonly ILocationService _locationService;
        private readonly IOrganizerService _organizerService;
        private readonly IEventTypeService _eventTypeService;

        public EventsController(IEventService eventService, ILocationService locationService, IOrganizerService organizerService, IEventTypeService eventTypeService)
        {
            _eventService = eventService;
            _locationService = locationService;
            _organizerService = organizerService;
            _eventTypeService = eventTypeService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new CreateNewEventVM
            {
                EventVMs = (await _eventService.GetAllAsync()).ToList(),
                EventTypes = (await _eventTypeService.GetAllAsync()).ToList(),
                Locations = (await _locationService.GetAllAsync()).ToList(),
                Organizers = (await _organizerService.GetAllAsync()).ToList()
            };

            return View(model);
        }


        // POST: /Events (Create or Update)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNewEventVM model)
        {
            if (!ModelState.IsValid)
            {
                model.EventVMs = (await _eventService.GetAllAsync()).ToList();
                model.EventTypes = (await _eventTypeService.GetAllAsync()).ToList();
                model.Locations = (await _locationService.GetAllAsync()).ToList();
                model.Organizers = (await _organizerService.GetAllAsync()).ToList();
                return View(model);
            }

            if (model.EventVM.ID == 0)
            {
                await _eventService.AddAsync(model.EventVM);
            }
            else
            {
                await _eventService.UpdateAsync(model.EventVM);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _eventService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
