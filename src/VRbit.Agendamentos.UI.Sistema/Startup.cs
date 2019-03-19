using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VRbit.Agendamentos.UI.Sistema.Startup))]
namespace VRbit.Agendamentos.UI.Sistema
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
