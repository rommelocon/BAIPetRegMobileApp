using AutoMapper;
using BAIPetRegMobileApp.Api.Models.PetRegistration;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PetRegistrationModel, PetRegistrationDto>().ReverseMap();
    }
}