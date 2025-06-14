using Code_Academy___Conference_Management_System.Entities;
using Code_Academy___Conference_Management_System.Services.Interfaces;
using Code_Academy___Conference_Management_System.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Code_Academy___Conference_Management_System.Controllers
{
    public class InvitationsController : Controller
    {
        private readonly IInvitationService _invitationsService;
        private readonly SignInManager<UserIdentity> _signInManager;
        private readonly UserManager<UserIdentity> _userManager;


        public InvitationsController(IInvitationService invitationsService, SignInManager<UserIdentity> signInManager, UserManager<UserIdentity> userManager)
        {
            _invitationsService = invitationsService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            //var models = await _invitationsService.GetAllAsync();
            //var user= await _userManager.GetUserAsync(User);
            //var filtered=models.Where(x=>x.PersonId==user.Id).ToList();
            return View();
        }
    }
}
