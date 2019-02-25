using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Ferma.BLL.Services;
using Microsoft.AspNet.Identity;
using Ferma.BLL.Interfaces;

[assembly: OwinStartup(typeof(Ferma.App_Start.Startup))]

namespace Ferma.App_Start
{
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserServiceAuth>(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IUserServiceAuth CreateUserService()
        {
            return serviceCreator.CreateUserService();
        }
    }
}
