using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System;
using System.Text;
using System.Web.Http;
using System.Security.Claims;

public static class WebApiConfig
{
    public static void Register(HttpConfiguration config)
    {
        var key = Encoding.ASCII.GetBytes(ConfigurationManager.AppSettings["JwtSecretKey"]);
        config.MessageHandlers.Add(new JwtAuthenticationHandler(new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            RoleClaimType = ClaimTypes.Role // Ensure the role claim type is correctly set
        }));

        // Web API configuration and services
        config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));

        // Web API routes
        config.MapHttpAttributeRoutes();

        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );

    }
}
