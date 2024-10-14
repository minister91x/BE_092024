using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.Common
{
    public static class Validation
    {

        public static bool CheckString(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            int number;
            if (int.TryParse(input, out number)) return false;

            if (input.Length > 100) return false;
            return true;
        }

        public static bool CheckNumber(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            int number;
            if (!int.TryParse(input, out number)) return false;

            return true;
        }
    }
}
