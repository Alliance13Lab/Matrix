using Matrix.Application.Interfaces;
using Matrix.Domain.Entities;
using Matrix.Dtos;

namespace Matrix.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class StateController(IStateService _stateService) : ControllerBase
{
    [HttpGet("{countryid}")]
    public async Task<IActionResult> GetStates(int countryid)
    {
        var states = await _stateService.GetAllStatesAsync(countryid);
        return Ok(states);
    }
}
