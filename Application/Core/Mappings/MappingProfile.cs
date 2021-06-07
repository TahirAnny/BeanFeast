using AutoMapper;
using Domain;

namespace Application.Core.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Activity, Activity>();
        }
    }
}