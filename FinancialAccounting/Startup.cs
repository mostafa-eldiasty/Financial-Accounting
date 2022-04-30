using Microsoft.Owin;
using Owin;
using BusinessLogic;

[assembly: OwinStartupAttribute(typeof(FinancialAccounting.Startup))]
namespace FinancialAccounting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            BusinessLogic.Startup startup = new BusinessLogic.Startup();
            startup.ConfigureAuth(app);
        }
    }
}
