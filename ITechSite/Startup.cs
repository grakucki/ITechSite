using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITechSite.Startup))]
namespace ITechSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // komentarz na początku z Akacjowej
            // Komentarz z Skłodowskiej
            ConfigureAuth(app);
            
        }
    }
}
