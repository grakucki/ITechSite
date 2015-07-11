using System.Web.Mvc;

namespace ITechSite.Areas.Testy
{
    public class TestyAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Testy";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Testy_default",
                "Testy/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ITechSite.Areas.Testy.Controllers" }
            );
        }
    }
}