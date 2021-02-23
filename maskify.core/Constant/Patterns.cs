namespace maskify.core.Constant
{
    public static class Patterns
    {
        public static string DefaultPattern = @"(?<=.{1}).";
        public static string EmailPattern = @"(?<=.)[^@](?=[^@]*?@)|(?:(?<=@.)|(?!^)\\G(?=[^@]*$)).(?=.*\\.)";
        public static string PhoneNumberPattern = @"(?<=\d{4})\d(?=\d{2})";
    }
}
