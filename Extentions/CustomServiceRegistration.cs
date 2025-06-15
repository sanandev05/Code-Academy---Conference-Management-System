using Code_Academy___Conference_Management_System.Repositories.Interfaces;
using Code_Academy___Conference_Management_System.Repositories;
using Code_Academy___Conference_Management_System.Services;
using Code_Academy___Conference_Management_System.Services.Interfaces;

namespace Code_Academy___Conference_Management_System.Extentions
{
    public static class CustomServiceRegistration
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IInvitationService, InvitationService>();
            services.AddScoped<IEventTypeService, EventTypeService>();
            services.AddScoped<IOrganizerService, Organizer_Service>();
            services.AddScoped<ILocationService, LocationService>();
           

        }
    }
}
