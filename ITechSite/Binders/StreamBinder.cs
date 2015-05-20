using System.Web.Mvc;

namespace ITechSite.Binders
{
    public class StreamBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var rawFile = controllerContext.HttpContext.Request.Files[bindingContext.ModelName];
            if (rawFile == null)
                return null;
            else
                return rawFile.InputStream;
        }
    }
}