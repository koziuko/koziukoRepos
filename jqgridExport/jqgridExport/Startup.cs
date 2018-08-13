using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(jqgridExport.Startup))]
namespace jqgridExport
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
