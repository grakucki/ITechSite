﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITechSite.Startup))]
namespace ITechSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);
        }
    }
}
