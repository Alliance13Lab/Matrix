using Matrix.Application.Interfaces;
using Matrix.Domain.Entities;
using Matrix.Dtos;

namespace Matrix.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class RightsController(IRightsService _rightsService) : ControllerBase
{
    [HttpGet("{id?}")]
    public async Task<IActionResult> GetRights(int id = 0)
    {
        var x = await _rightsService.GetAllRightsAsync(id);
        return Ok(x);
    }

    [HttpPost("INUPRights")]
    public async Task<IActionResult> INUPRights(Rights m)
    {
        try
        {
            await _rightsService.INUPRights(m);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRights(int id)
    {
        try
        {
            await _rightsService.DeleteRightsAsync(id);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
