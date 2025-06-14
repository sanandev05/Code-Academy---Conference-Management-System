using Code_Academy___Conference_Management_System.Repositories;
using Code_Academy___Conference_Management_System.Repositories.Interfaces;

namespace Code_Academy___Conference_Management_System.Extentions
{
    public static class CustomRepositoryRegistration
    {
        public static void AddCustomRepositories(this IServiceCollection services)
        {
            services.AddScoped<IInvitationRepository, InvitationRepository>();
            services.AddScoped<IEventTypeRepository, EventTypeRepository>();

        }
    }
}
