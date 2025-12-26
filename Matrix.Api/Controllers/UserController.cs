using Matrix.Application.Interfaces;
using Matrix.Domain.Entities;
using Matrix.Dtos; 

namespace Matrix.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService _userService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpGet("paging")]
    public async Task<IActionResult> GetUsers([FromQuery] UsersRequest request)
    {
        var pagedResult = await _userService.GetUsersAsync(request);
        return Ok(pagedResult);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(User createUserDto)
    {
        try
        {
            var user = await _userService.CreateUserAsync(createUserDto);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, User updateUserDto)
    {
        try
        {
            await _userService.UpdateUserAsync(id, updateUserDto);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        try
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [AllowAnonymous]
    [HttpGet("test-logging")]
    public IActionResult TestLogging(ILogger<UserController> _logger)
    {
        _logger.LogTrace("This is a trace message");
        _logger.LogDebug("This is a debug message");
        _logger.LogInformation("This is an info message");
        _logger.LogWarning("This is a warning message");
        _logger.LogError("This is an error message");
        _logger.LogCritical("This is a critical message");

        return Ok("Logging test completed");
    }
}
