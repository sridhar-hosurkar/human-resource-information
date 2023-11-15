using AutoMapper;
using Domain = DomainModels;
using Service = ServiceModels;

namespace Services;

public class HumanResourceProfile : Profile
{
    public HumanResourceProfile(){
        CreateMap<Domain.User, Service.User>().ReverseMap();
        CreateMap<Domain.Address, Service.Address>().ReverseMap();
    }
}
