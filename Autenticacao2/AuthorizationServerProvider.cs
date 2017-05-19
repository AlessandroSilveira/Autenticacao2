using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

namespace Autenticacao2
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] {"*"});

            try
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                var roles = new List<string>();

                roles.Add("User");

                foreach (var role in roles)
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));

                var principal = new GenericPrincipal(identity, roles.ToArray());
                Thread.CurrentPrincipal = principal;

                context.Validated(identity);
            }
            catch
            {
                context.SetError("invalid_grant", "Falha ao autenticar");
            }
        }
    }
}