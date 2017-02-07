using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Trabajo_final_csharp.Startup))]
namespace Trabajo_final_csharp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
