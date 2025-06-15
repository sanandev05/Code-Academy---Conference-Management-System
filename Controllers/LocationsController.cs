using AutoMapper;
using Code_Academy___Conference_Management_System.Models;
using Code_Academy___Conference_Management_System.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Code_Academy___Conference_Management_System.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;

        public LocationsController(ILocationService locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var locations = await _locationService.GetAllAsync();
            var model = new CreateNewLocationVM
            {
                Locations = locations.ToList()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNewLocationVM model)
        {
            if (ModelState.IsValid)
            {
                await _locationService.AddAsync(model.LocationVM);
                return RedirectToAction("Index");
            }
            model.Locations = (await _locationService.GetAllAsync()).ToList();
            return View("Index", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateNewLocationVM model)
        {
            if (ModelState.IsValid)
            {
                await _locationService.UpdateAsync(model.LocationVM);
                return RedirectToAction("Index");
            }
            model.Locations = (await _locationService.GetAllAsync()).ToList();
            return View("Index", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _locationService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
