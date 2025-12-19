using Matrix.Application.Interfaces;

namespace Matrix.Application.Services;

public class IdentityService(IHttpContextAccessor context) : IIdentityService
{
    private readonly IHttpContextAccessor _context = context ?? throw new ArgumentNullException(nameof(context));

    public int GetUserId()
    {
        if (_context.HttpContext?.User.FindFirst("sub") == null) return 0;
        return Convert.ToInt32(_context.HttpContext?.User?.FindFirst("sub")?.Value);
    }

    public int GetCompanyId()
    {
        StringValues stringValue = default;
        _context.HttpContext?.Request.Headers.TryGetValue("companyId", out stringValue);
        return Convert.ToInt32(stringValue.ToString());
    }

    public int GetRoleId()
    {
        return Convert.ToInt32(_context.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value);
    }
}