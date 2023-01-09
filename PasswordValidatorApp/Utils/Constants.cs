namespace PasswordValidatorApp.Utils
{
    public static class Constants
    {
        public const string VALIDATION_PATTERN = @"^[a-zA-z]\s[1-9]{1}\-[1-9]{1}\:\s\w*$";
        public const string SPLIT_PATTERN = @"^([a-zA-Z]{1}) (\d{1})-(\d{1}): (\w*)$";
    }
}
