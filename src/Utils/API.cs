using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Writer
{
    public static class API
    {
        public static int GetBuildVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.Build;
        }
    }
}
