using API.DTOs;
using API.Models;
using AutoMapper;

namespace API.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Customer, CustomerToReturnDto>()
            .ForMember(c => c.Id, o => o.MapFrom(f => f.ID))
            .ForMember(c => c.FirstName, o => o.MapFrom(f => f.FirstName))
            .ForMember(c => c.LastName, o => o.MapFrom(f => f.LastName))
            .ForMember(c => c.Email, o => o.MapFrom(f => f.Email))
            .ForMember(c => c.PhoneNumber, o => o.MapFrom(f => f.PhoneNumber));
    }
}
