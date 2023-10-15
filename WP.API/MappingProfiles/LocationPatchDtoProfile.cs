using AutoMapper;
using WP.Common.Models;
using WP.DAL.Entities;

namespace WP.API.MappingProfiles
{
    public class LocationPatchDtoProfile : Profile
    {
        public LocationPatchDtoProfile()
        {
            CreateMap<BusinessLocation, LocationPatchDto>();
        }
    }
}
