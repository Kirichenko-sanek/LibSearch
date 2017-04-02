using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(LibSearch.Startup))]

namespace LibSearch
{
    public class Startup
    {
    }
}