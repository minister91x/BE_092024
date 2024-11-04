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

        public static bool CheckXSSInput(string input)
        {
            try
            {
                var listdangerousString = new List<string> { "<applet", "<body", "<embed", "<frame", "<script", "<frameset", "<html", "<iframe", "<img", "<style", "<layer", "<link", "<ilayer", "<meta", "<object", "<h", "<input", "<a", "&lt", "&gt" };
                if (string.IsNullOrEmpty(input)) return false;
                foreach (var dangerous in listdangerousString)
                {
                    if (input.Trim().ToLower().IndexOf(dangerous) >= 0) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
