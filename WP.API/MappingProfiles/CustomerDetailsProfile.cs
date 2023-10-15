using AutoMapper;
using WP.Common.Models;
using WP.DAL.Entities;

namespace WP.API.MappingProfiles
{
    public class CustomerDetailsProfile : Profile
    {
        public CustomerDetailsProfile()
        {
            CreateMap<Customer, CustomerDetailsDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.Employees));

            CreateMap<Employee, EmployeeDto>();

        }
    }
}
