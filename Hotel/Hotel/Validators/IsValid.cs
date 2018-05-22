using System.Text.RegularExpressions;

namespace Hotel.Validators
{
    public class IsValid
    {
        public static bool Valid(string value, string pattern)
        {
            if (value == null)
            {
                return false;
            }
            else if (Regex.IsMatch(value, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}