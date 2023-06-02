using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace HomeApps
{
    public static class MyExtensions
    {
        public static string ToTileCase(this string word)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            return textInfo.ToTitleCase(word);
        }
    }
}
