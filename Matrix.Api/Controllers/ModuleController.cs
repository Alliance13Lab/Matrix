using Matrix.Application.Interfaces;
using Matrix.Application.Services;
using Matrix.Domain.Entities;
using Matrix.Dtos;

namespace Matrix.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ModuleController(IModuleService _moduleService) : ControllerBase
{
    [HttpGet("{id?}")]
    public async Task<IActionResult> Getmodule(int id=0)
    {
        var x = await _moduleService.GetAllModuleAsync(id);
        return Ok(x);
    }
}
