using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VuongMinhQuoc.Utils
{
    public static class StringHelper
    {
        public static string StripHTML(string inputString)
        {
            return System.Text.RegularExpressions.Regex.Replace
              (inputString, "<.*?>", string.Empty);
        }
    }
}