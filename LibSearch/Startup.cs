using System;
using LibSearch.Core.Intefaces.Manager;
using LibSearch.Core.Model;
using LibSearch.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(LibSearch.Startup))]

namespace LibSearch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);

        }

        public void ConfigureOAuth(IAppBuilder app)
        {

            OAuthBearerAuthenticationOptions oAuthBearerOptions = new OAuthBearerAuthenticationOptions();
            OAuthAuthorizationServerOptions oAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new ApplicationOAuthProvider(WebApiApplication._container.Resolve<IUserManager<User>>()),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                AllowInsecureHttp = true
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(oAuthBearerOptions);

        }


    }
}