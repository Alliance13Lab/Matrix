using Matrix.Application.Interfaces;
using Matrix.Application.Services;
using Matrix.Domain.Entities;
using Matrix.Dtos;

namespace Matrix.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CountryController(ICountryService _countryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCountry()
    {
        var country = await _countryService.GetAllCountryAsync();
        return Ok(country);
    }

    [HttpGet("paging")]
    public async Task<IActionResult> GetCountry([FromQuery] CountryRequest request)
    {
        var pagedResult = await _countryService.GetCountryAsync(request);
        return Ok(pagedResult);
    }
}
