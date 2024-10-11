using QualityPointDev.Services.Address.Data.Dto;
using QualityPointDev.Services.Address.Data.Responses;

namespace QualityPointDev.Services.Address.Infrastructure;

public interface IAddressService
{
    public Task<AddressResponse<List<AddressDto>>> GetAddressAsync(string query);
    public  Task<AddressResponse<List<Data.Address>>> GetAddressDetailsAsync(string query);
}