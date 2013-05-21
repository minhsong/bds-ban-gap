using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhaChoThue.Helpers
{
    public static class SessionHelper
    {
        public static object GetSession(string name)
        {
            if (HttpContext.Current == null) return string.Empty;
            if (HttpContext.Current.Session[name] != null)
                return HttpContext.Current.Session[name];
            return null;
        }

        public static void SetSession(string name, object value)
        {
            HttpContext.Current.Session[name] = value;
        }

        public static void ClearSession(string name)
        {
            HttpContext.Current.Session[name] = null;
        }
    }
}