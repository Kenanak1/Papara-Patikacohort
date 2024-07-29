using AutoMapper;
using Papara_cohort.Models;
using Papara_cohort;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CustomerUpdateDto, CustomerUpdateModel>();
        CreateMap<CustomerUpdateModel, CustomerUpdateDto>();
    }
}
