using System;
using System.Security.Claims;

namespace Booking.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetUserGuId(this ClaimsPrincipal @this)
        {
            var id = @this.FindFirst(ClaimTypes.NameIdentifier);
            return Guid.Parse(id.Value);
        }

        public static string GetUserId(this ClaimsPrincipal @this)
        {
            var id = @this.FindFirst(ClaimTypes.NameIdentifier);
            return id.Value;
        }
    }
}
