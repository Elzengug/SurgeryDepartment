using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SurgeryDepartment.Startup))]
namespace SurgeryDepartment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
