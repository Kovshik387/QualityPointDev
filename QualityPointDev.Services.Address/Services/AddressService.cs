using AutoMapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QualityPointDev.Services.Address.Data.Dto;
using QualityPointDev.Services.Address.Data.Responses;
using QualityPointDev.Services.Address.Infrastructure;
using QualityPointDev.Services.Settings.SettingsConfigure;

namespace QualityPointDev.Services.Address.Services;

public class AddressService : IAddressService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly DadataApiSettings _dadataApiSettings;
    private readonly IMapper _autoMapper;
    private readonly ILogger<AddressService> _logger;
    
    public AddressService(DadataApiSettings conf, IHttpClientFactory httpClient, IMapper autoMapper, ILogger<AddressService> logger)
    {
        _dadataApiSettings = conf;  _httpClientFactory = httpClient;
        _autoMapper = autoMapper; _logger = logger;
    }
    
    public async Task<AddressResponse<List<AddressDto>>> GetAddressAsync(string query)
    {
        var data = await SendRequest(query);
        
        if (data == null)
        {
            _logger.LogError("Request does not contain data for standardization");
            return new AddressResponse<List<AddressDto>>()
            {
                Data = null,
                ErrorMessage = "Request does not contain data for standardization"
            };
        }
        
        var response =  JsonConvert.DeserializeObject<List<Data.Address>>(data);

        var result = _autoMapper.Map<List<AddressDto>>(response);
        
        return new AddressResponse<List<AddressDto>>()
        {
            Data = result,
            ErrorMessage = ""
        };
    }
    
    public async Task<AddressResponse<List<Data.Address>>> GetAddressDetailsAsync(string query)
    {
        var data = await SendRequest(query);
        
        if (data == null)
        {
            _logger.LogError("Request does not contain data for standardization");
            return new AddressResponse<List<Data.Address>>()
            {
                Data = null,
                ErrorMessage = "Request does not contain data for standardization"
            };
        }

        var result =  JsonConvert.DeserializeObject<List<Data.Address>>(data);
        
        return new AddressResponse<List<Data.Address>>()
        {
            Data = result,
            ErrorMessage = ""
        };
    }
    
    private async Task<string?> SendRequest(string query)
    {
        using var client = _httpClientFactory.CreateClient();
        
        client.DefaultRequestHeaders.Add("Authorization",_dadataApiSettings.ApiToken);
        client.DefaultRequestHeaders.Add("X-Secret",_dadataApiSettings.ApiSecret);
        
        var content = new StringContent("[ " + @"""" + query + @"""" + " ]", System.Text.Encoding.UTF8, "application/json");
        try
        {
            var response = await client.PostAsync(_dadataApiSettings.Url, content);
            _logger.LogInformation($"Response StatusCode from API: {response.StatusCode}");
            var result = await response.Content.ReadAsStringAsync();
            return result;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }
}