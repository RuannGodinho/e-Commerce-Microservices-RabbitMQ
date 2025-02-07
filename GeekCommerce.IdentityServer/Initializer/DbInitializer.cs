using GeekCommerce.IdentityServer.Model;
using GeekCommerce.IdentityServer.Model.Context;
using Microsoft.AspNetCore.Identity;
using GeekCommerce.IdentityServer.Configuration;
using System.Security.Claims;
using IdentityModel;

namespace GeekCommerce.IdentityServer.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly MySqlContext _context;
        private readonly UserManager<ApplicationUser> _user;
        private readonly RoleManager<IdentityRole> _role;

        public DbInitializer(MySqlContext context, UserManager<ApplicationUser> user, RoleManager<IdentityRole> role)
        {
            _context = context;
            _user = user;
            _role = role;
        }

        public void Initialize()
        {
            if (_role.FindByNameAsync(IdentityConfiguration.Admin).Result != null)
                return;
            _role.CreateAsync(new IdentityRole(IdentityConfiguration.Admin)).GetAwaiter().GetResult();

            _role.CreateAsync(new IdentityRole(IdentityConfiguration.Client)).GetAwaiter().GetResult();

            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "ruann-admin",
                Email = "ruan-admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (15) 99688-9857",
                FirstName = "Ruann",
                LastName = "Godinho"
            };

            _user.CreateAsync(admin, "Ruann123@").GetAwaiter().GetResult();
            _user.AddToRoleAsync(admin, IdentityConfiguration.Admin).GetAwaiter().GetResult();

            var adminClaims = _user.AddClaimsAsync(admin, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
                new Claim(JwtClaimTypes.GivenName, admin.FirstName),
                new Claim(JwtClaimTypes.FamilyName, admin.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin),
            }).Result;
            
            ApplicationUser client = new ApplicationUser()
            {
                UserName = "ruann-client",
                Email = "ruan-client@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (15) 99688-9857",
                FirstName = "Ruann",
                LastName = "Godinho"
            };

            _user.CreateAsync(client, "Ruann123@").GetAwaiter().GetResult();
            _user.AddToRoleAsync(client, IdentityConfiguration.Client).GetAwaiter().GetResult();

            var clientClaims = _user.AddClaimsAsync(client, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{client.FirstName} {client.LastName}"),
                new Claim(JwtClaimTypes.GivenName, client.FirstName),
                new Claim(JwtClaimTypes.FamilyName, client.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client),
            }).Result;
        }
    }
}

