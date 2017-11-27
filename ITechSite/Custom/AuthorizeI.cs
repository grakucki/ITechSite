//using Nati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITechSite.Custom
{
    public class AuthorizeI: ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var n = new ModelL();
            
            //if (!n.IsValid(filterContext))
                //throw new ArgumentException(ModelL.ErrorMessage);

            this.OnActionExecuting(filterContext);
        }

    }
}