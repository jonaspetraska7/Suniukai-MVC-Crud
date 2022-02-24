using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Suniukai_MVC_Paskaita.Areas.Identity.Data
{
    public class AdditionalUserClaimsPrincipalFactory
            : UserClaimsPrincipalFactory<Vartotojas, IdentityRole>
    {
        public AdditionalUserClaimsPrincipalFactory(
            UserManager<Vartotojas> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        { }

        public async override Task<ClaimsPrincipal> CreateAsync(Vartotojas user)
        {
            var principal = await base.CreateAsync(user);
            var identity = (ClaimsIdentity)principal.Identity;

            var claims = new List<Claim>();
            if (user.IsAdmin)
            {
                claims.Add(new Claim("role", "admin"));
            }
            else
            {
                claims.Add(new Claim("role", "user"));
            }

            identity.AddClaims(claims);
            return principal;
        }
    }
}
