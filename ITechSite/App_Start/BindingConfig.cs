using ITechSite.Binders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITechSite
{
    public class BindingConfig
    {
        public static void RegisterBindings(ModelBinderDictionary modelBinderDictionary)
        {
            modelBinderDictionary.Add(typeof(Stream), new StreamBinder());
        }
    }
}