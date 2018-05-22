namespace Hotel.Validators
{
    public static class RegexPatterns
    {
        public const string descriptionPattern = "^.{1,100}$";
        public const string typePattern = @"\b(GOLD|SILVER|BRONZE)\b";
        public const string namePattern = "^[A-ZĆŁŚŹŻ][a-ząćęłńóśźżA-ZĄĆĘŁŃÓŚŹŻ-]{2,29}$";
        public const string amountOfBedspattern = "^([1-5]{1})$";
        public const string genderPattern = "^(M|K){1}$";
        public const string peselPattern = "^([0-9]{2})(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])([0-9]{5})$";
        public const string pricePattern = "^([0-9]{1,5})([.]{0,1})([0-9]{0,2})$";
        public const string datePattern = @"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$";
    }
}