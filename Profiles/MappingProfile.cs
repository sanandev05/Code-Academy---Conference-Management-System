using AutoMapper;
using Code_Academy___Conference_Management_System.Entities;
using Code_Academy___Conference_Management_System.Models;

namespace Code_Academy___Conference_Management_System.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventVM>().ReverseMap();
            CreateMap<Location, LocationVM>().ReverseMap();
            CreateMap<EventType, EventTypeVM>().ReverseMap();
            CreateMap<Organizer, OrganizerVM>().ReverseMap();
            CreateMap<Invitation, InvitationVM>().ReverseMap();
        }
    }
}
