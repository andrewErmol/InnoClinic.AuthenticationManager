using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4;

namespace AuthenticationManager.API.Extensions
{
    public static class IdentityServerConfiguration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                //new ApiScope("SOMETHING", "SOMETHING") то что хотим защитить

            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                /*
                new ApiResource("SOMETHING", "SOMETHING", new[]
                    { JwtClaimTypes.Name })
                {
                    Scopes = {"SOMETHING"}
                }*/
            };
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                /*
                new Client
                {
                    ClientId = "SOMETHING",
                    ClientName = "SOMETHING",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris =
                    {
                        "http://.../signin-oidc"
                    },
                    AllowedCorsOrigins =
                    {
                        "http://..."
                    },
                    PostLogoutRedirectUris =
                    {
                        "http:/.../signout-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "SOMETHING"
                    },
                    AllowAccessTokensViaBrowser = true,
                }*/
            };
    }
}
