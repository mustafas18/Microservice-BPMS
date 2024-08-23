using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Shared.Extensions
{
    public static class StringBetween
    {
        public static  string   GetStringBetweenDelimiters(string input, string delimiter)
        {
            string pattern = $@"{Regex.Escape(delimiter)}(.*?){Regex.Escape(delimiter)}";
            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                return match.Groups[1].Value; // Extracts the value between the delimiters
            }

            return null; // Return null if no match is found
        }
    }
}
