using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(Lab.MVC.Startup))]

namespace Lab.MVC
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            // vamos definir como será realizado o login e armazenado o cookie de autenticaçãos
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                                        LoginPath = new PathString(@"/Usuarios/Login"),
                                        LogoutPath = new PathString(@"/Usuarios/Logout")
            });
        }
    }
}
