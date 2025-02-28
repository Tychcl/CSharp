using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _14pr2.Classes.Common
{
    public class CheckRegex
    {
        public static bool Match(string pattern, string input)
        {
            Match m = Regex.Match(input, pattern);
            return m.Success;
        }
    }
}
