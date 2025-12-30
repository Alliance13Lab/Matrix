using Matrix.Application.Interfaces;
using Matrix.Domain.Entities;
using Matrix.Dtos;

namespace Matrix.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CityController(ICityService _cityService) : ControllerBase
{
    [HttpGet("{stateid}")]
    public async Task<IActionResult> GetCitys(int stateid)
    {
        var x = await _cityService.GetAllCitysAsync(stateid);
        return Ok(x);
    }
}
