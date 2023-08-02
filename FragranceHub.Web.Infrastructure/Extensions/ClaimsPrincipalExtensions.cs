
using System.Runtime.CompilerServices;
using System.Security.Claims;
using static FragranceHub.Common.GeneralAppConstants;

namespace FragranceHub.Web.Infrastructure.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool IsAdmin(this ClaimsPrincipal user)
        {

            return user.IsInRole(AdminRoleName);
        }
    }
}
