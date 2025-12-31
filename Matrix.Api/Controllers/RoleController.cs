using Matrix.Application.Interfaces;
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
}
