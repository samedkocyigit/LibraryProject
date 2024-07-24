using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;

public class JwtAuthenticationHandler : DelegatingHandler
{
    private readonly TokenValidationParameters _tokenValidationParameters;

    public JwtAuthenticationHandler(TokenValidationParameters tokenValidationParameters)
    {
        _tokenValidationParameters = tokenValidationParameters;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (request.Headers.Authorization != null && request.Headers.Authorization.Scheme == "Bearer")
        {
            var token = request.Headers.Authorization.Parameter;
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);
                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;
            }
            catch
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
        }
        return await base.SendAsync(request, cancellationToken);
    }
}
