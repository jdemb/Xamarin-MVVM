using System;

namespace PatientsStory.Helpers
{
    public class CountAgeHelper
    {
        public static int CountAge(string pesel)
        {
            var yearInPesel = Int32.Parse(pesel.Substring(0, 2));
            var stringYear = "";
            if (yearInPesel <= 18)
            {
                stringYear = "20" + pesel.Substring(0, 2);
            }
            else
            {
                stringYear = "19" + pesel.Substring(0, 2);
            }

            var year = Int32.Parse(stringYear);
            var month = Int32.Parse(pesel.Substring(2, 2));
            var day = Int32.Parse(pesel.Substring(4, 2));

            var birthday = new DateTime(year, month, day);
            var today = DateTime.Today;
            var age = ((DateTime.Now.Year - birthday.Year) * 372 +
                (DateTime.Now.Month - birthday.Month) * 31 +
                (DateTime.Now.Day - birthday.Day)) / 372;

            return age;
        }
    }
}