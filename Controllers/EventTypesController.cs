using Code_Academy___Conference_Management_System.Models;
using Code_Academy___Conference_Management_System.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Code_Academy___Conference_Management_System.Controllers
{
    public class EventTypesController : Controller
    {
        private readonly IEventTypeService _eventTypeService;

        public EventTypesController(IEventTypeService eventTypeService)
        {
            _eventTypeService = eventTypeService;
        }

        public async Task<IActionResult> Index()
        {
            var eventTypes = await _eventTypeService.GetAllAsync();
            CreateNewEventTypeVM model = new CreateNewEventTypeVM
            {
                EventTypeList = eventTypes.ToList()
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNewEventTypeVM model)
        {
            if (ModelState.IsValid)
            {
                await _eventTypeService.AddAsync(model.EventType);

                return RedirectToAction("Index");
            }

            model.EventTypeList = (await _eventTypeService.GetAllAsync()).ToList();

            return View("Index", model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateNewEventTypeVM model)
        {
            if (ModelState.IsValid)
            {
                var existing = await _eventTypeService.GetByIdAsync(model.EventType.ID);
                if (existing == null)
                {
                    return NotFound();
                }

                existing.Name = model.EventType.Name;

                await _eventTypeService.UpdateAsync(existing);
                return RedirectToAction("Index");
            }

            
            model.EventTypeList = (await _eventTypeService.GetAllAsync()).ToList();
            return View("Index", model); 
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Id)
        {
            await _eventTypeService.DeleteAsync(Id);
            return RedirectToAction("Index");
        }

    }
}
