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
            services.AddScoped<IInvitationRepository, InvitationRepository>();
            //services.AddScoped<IEventRepository, EventRepository>();
           // services.AddScoped<IPersonRepository, PersonRepository>();
            
        }
    }
}
