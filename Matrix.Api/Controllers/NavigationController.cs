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
        try
        {
            await _navigationService.INUPNavigation(nav);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNavigation(int id)
    {
        try
        {
            await _navigationService.DeleteNavigationAsync(id);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
