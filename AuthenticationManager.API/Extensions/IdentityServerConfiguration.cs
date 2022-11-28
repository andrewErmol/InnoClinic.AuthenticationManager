using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4;

namespace AuthenticationManager.API.Extensions
{
    public static class IdentityServerConfiguration
    {


        private static string ApiScope => "APIScope";
        private static string ScopeRoles => "roles";




        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                //new ApiScope("Event.Api", "Event.Api"),
                

                new(ApiScope)


                //new ApiScope("SOMETHING", "SOMETHING") то что хотим защитить

            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                //new IdentityResources.OpenId(),
                //new IdentityResources.Profile()




            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new() { Name = ScopeRoles, UserClaims = { JwtClaimTypes.Role } }


            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {





                new(ApiScope, new[] { JwtClaimTypes.Name, JwtClaimTypes.Role })
            {
                Scopes =
                {
                    ApiScope,
                    ScopeRoles,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.OfflineAccess,
                    IdentityServerConstants.StandardScopes.Profile
                }
            }









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
                /*new Client
                {
                    ClientId = "client",

            // no interactive user, use the clientid/secret for authentication
            AllowedGrantTypes = GrantTypes.ClientCredentials,

            // secret for authentication
            ClientSecrets =
            {
                new Secret("secret".Sha256())
            },

            // scopes that client has access to
            AllowedScopes = { "Event.Api" }
                }*/






            new()
            {
                ClientId = "APIClient",
                RequireClientSecret = false,

                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OfflineAccess,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.OpenId,
                    ApiScope
                },

                AllowOfflineAccess = true
            },

            new()
            {
                ClientId = "AngularClient",
                RequireClientSecret = false,

                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OfflineAccess,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.OpenId,
                    ApiScope
                },

                AllowOfflineAccess = true
            }







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
