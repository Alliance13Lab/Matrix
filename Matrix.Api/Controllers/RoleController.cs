using Matrix.Application.Interfaces;
using Matrix.Application.Services;
using Matrix.Domain.Entities;
using Matrix.Dtos;

namespace Matrix.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class RoleController(IRoleService _roleService) : ControllerBase
{
    [HttpGet("{id?}")]
    public async Task<IActionResult> GetRole(int id = 0)
    {
        var x = await _roleService.GetAllRoleAsync(id);
        return Ok(x);
    }
    [HttpPost("INUPRole")]
    public async Task<IActionResult> INUPRole(Role m)
    {
        try
        {
            await _roleService.INUPRole(m);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRole(int id)
    {
        try
        {
            await _roleService.DeleteRoleAsync(id);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
