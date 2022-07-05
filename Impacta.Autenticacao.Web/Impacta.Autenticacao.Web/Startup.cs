using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Impacta.Autenticacao.Web.Startup))]
namespace Impacta.Autenticacao.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
