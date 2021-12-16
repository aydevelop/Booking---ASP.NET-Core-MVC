using System;
using System.Security.Claims;

namespace Booking.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal @this)
        {
            var id = @this.FindFirst(ClaimTypes.NameIdentifier);
            return Guid.Parse(id.Value);
        }
    }
}
