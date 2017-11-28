using System.Web.Mvc;

namespace ITechSite.Areas.Settings
{
    public class SettingsAreaRegistration : AreaRegistration 
    {
        public static string Name
        {
            get
            {
                return "Settings";
            }
        }
        public override string AreaName 
        {
            get 
            {
                return "Settings";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Settings_default",
                "Settings/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
              
           );
       }
    }
}