using System.Security.Claims;

namespace HandsOnWithBlazor.Infrastructure.Security
{
    public interface IUserAccessor
    {
        ClaimsPrincipal User { get; }
    }
}
