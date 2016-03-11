using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using RestSharp;

[assembly: OwinStartup(typeof(OData_Tests.Startup))]

namespace OData_Tests
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
