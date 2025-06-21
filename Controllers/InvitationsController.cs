using Code_Academy___Conference_Management_System.Models;
using Code_Academy___Conference_Management_System.Services.Interfaces;
using Code_Academy___Conference_Management_System.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Code_Academy___Conference_Management_System.Controllers
{
    [Authorize]
    public class InvitationsController : Controller
    {
        private readonly IInvitationService _invitationsService;
        private readonly UserManager<UserIdentity> _userManager;

        public InvitationsController(IInvitationService invitationsService, UserManager<UserIdentity> userManager)
        {
            _invitationsService = invitationsService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var allInvitations = await _invitationsService.GetAllAsync();
            var userInvitations = allInvitations.Where(i => i.UserId == userId)
                                                .OrderByDescending(i => i.Event?.StartDate)
                                                .ToList();

            return View(userInvitations);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Respond(int id, string decision)
        {
            var userId = _userManager.GetUserId(User);
            var invitation = await _invitationsService.GetByIdAsync(id);

            if (invitation == null || invitation.UserId != userId)
            {
                return Forbid();
            }

            if (decision.Equals("accept", System.StringComparison.OrdinalIgnoreCase))
            {
                invitation.InvitationStatus = InvitationVM.Status.Accepted;
            }
            else if (decision.Equals("reject", System.StringComparison.OrdinalIgnoreCase))
            {
                invitation.InvitationStatus = InvitationVM.Status.Declined;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            await _invitationsService.UpdateAsync(invitation);

            return RedirectToAction(nameof(Index));
        }
    }
}
