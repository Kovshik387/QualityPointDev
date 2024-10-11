using Microsoft.AspNetCore.Mvc;
using QualityPointDev.Services.Address.Infrastructure;
using QualityPointDev.Services.Settings.SettingsConfigure;

namespace QualityPointDev.WebApi.Controllers;

[ApiController]
[Route("api/address")]
public class AddressController : ControllerBase
{
    private readonly ILogger<AddressController> _logger;
    private readonly IAddressService _addressService;

    public AddressController(ILogger<AddressController> logger, IAddressService addressService)
    {
        _logger = logger;
        _addressService = addressService;
    }

    [HttpPost]
    [Route("details")]
    public async Task<IActionResult> GetAddressAsyncDetails([FromBody] string body)
    {
        return Ok(await _addressService.GetAddressDetailsAsync(body));
    }

    [HttpPost]
    [Route("mini")]
    public async Task<IActionResult> GetAddressAsync([FromBody] string body)
    {
        return Ok(await _addressService.GetAddressAsync(body));
    }
}