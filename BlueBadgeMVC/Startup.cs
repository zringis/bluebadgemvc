using System;
using BlueBadge.Data;
using BlueBadge.Services;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlueBadgeMVC.Startup))]
namespace BlueBadgeMVC
{
    public partial class Startup
    {


        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
        }

    }
}
