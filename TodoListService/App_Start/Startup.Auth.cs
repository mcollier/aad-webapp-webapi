using System.Configuration;
using System.IdentityModel.Tokens;
using Microsoft.Owin.Security.ActiveDirectory;
using Owin;

namespace TodoListService
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
                new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                {
                    //Audience = ConfigurationManager.AppSettings["ida:Audience"],
                    TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidAudience = ConfigurationManager.AppSettings["ida:Audience"],
                        RoleClaimType = "roles",
                        ValidateIssuer = false
                    },
                    Tenant = ConfigurationManager.AppSettings["ida:Tenant"],
                    AuthenticationType = "OAuth2Bearer"
                });
        }
    }
}
