using System;
using System.Collections.Generic;
using System.Text;

namespace Xpeppers.Chirper
{
    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string text)
        {
            return Char.ToUpper(text[0]) + text.Substring(1).ToLower();
        }
    }
}
