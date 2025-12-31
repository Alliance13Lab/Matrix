using Matrix.Application.Interfaces;
using Matrix.Application.Services;
using Matrix.Domain.Entities;
using Matrix.Dtos;

namespace Matrix.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class NavigationController(INavigationService _navigationService) : ControllerBase
{
    [HttpGet("{id?}")]
    public async Task<IActionResult> GetNavigation(int id=0)
    {
        var x = await _navigationService.GetAllNavigationAsync(id);
        return Ok(x);
    }

    [HttpPost("INUPNavigation")]
    public async Task<IActionResult> INUPNavigation(Navigation nav)
    {
        int id = 0;
        try
        {
            await _navigationService.INUPNavigation(id, nav);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
