using AutoMapper;
using Code_Academy___Conference_Management_System.Models;
using Code_Academy___Conference_Management_System.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Code_Academy___Conference_Management_System.Controllers
{
    public class OrganizersController : Controller
    {
        private readonly IOrganizerService _organizerService;
        private readonly IMapper _mapper;

        public OrganizersController(IOrganizerService organizerService, IMapper mapper)
        {
            _organizerService = organizerService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var getAll = await _organizerService.GetAllAsync();
            var model = new CreateNewOrganizerVM()
            {
                Organizers = getAll.ToList(),
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNewOrganizerVM model)
        {
            if (ModelState.IsValid)
            {
                await _organizerService.AddAsync(model.OrganizerVM);
                return RedirectToAction("Index");
            }
            model.Organizers = (await _organizerService.GetAllAsync()).ToList();
            return View("Index", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateNewOrganizerVM model)
        {
            if (ModelState.IsValid)
            {
                await _organizerService.UpdateAsync(model.OrganizerVM);
                return RedirectToAction("Index");
            }
            model.Organizers = (await _organizerService.GetAllAsync()).ToList();
            return View("Index", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _organizerService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
