namespace Code_Academy___Conference_Management_System.Models.ViewModels
{

    public class DashboardVM
    {
        public int UpcomingEventsCount { get; set; }
        public int PendingInvitationsCount { get; set; }
        public int TotalUsersCount { get; set; }
        public IEnumerable<EventVM> UpcomingEvents { get; set; }
    }
}
