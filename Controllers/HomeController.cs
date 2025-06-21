using Code_Academy___Conference_Management_System.Models;
using Code_Academy___Conference_Management_System.Models.ViewModels;
using Code_Academy___Conference_Management_System.Services.Interfaces;
using Code_Academy___Conference_Management_System.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Code_Academy___Conference_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IInvitationService _invitationService;
        private readonly UserManager<UserIdentity> _userManager;
        private readonly SignInManager<UserIdentity> _signInManager;

        public HomeController(
            IEventService eventService,
            IInvitationService invitationService,
            UserManager<UserIdentity> userManager,
            SignInManager<UserIdentity> signInManager)
        {
            _eventService = eventService;
            _invitationService = invitationService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

       
        public async Task<IActionResult> Index()
        {
            var allEvents = await _eventService.GetAllAsync();
            var allUsers = _userManager.Users;

            var dashboardViewModel = new DashboardVM
            {
                UpcomingEventsCount = allEvents.Count(e => e.StartDate > DateTime.Now),
                TotalUsersCount = allUsers.Count(),
                UpcomingEvents = allEvents.Where(e => e.StartDate > DateTime.Now)
                                          .OrderBy(e => e.StartDate)
                                          
            };

            if (_signInManager.IsSignedIn(User))
            {
                var userId = _userManager.GetUserId(User);
                var allInvitations = await _invitationService.GetAllAsync();

                dashboardViewModel.PendingInvitationsCount = allInvitations
                    .Count(i => i.UserId == userId && i.InvitationStatus == InvitationVM.Status.Pending);
            }

            return View(dashboardViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
