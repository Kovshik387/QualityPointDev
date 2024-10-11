using AutoMapper;
using QualityPointDev.Services.Address.Data.Dto;

namespace QualityPointDev.Services.Address.Data.Mapper;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<Address,AddressDto>().ReverseMap();
        CreateMap<Dto.Metro,Metro>().ReverseMap();
    }
}