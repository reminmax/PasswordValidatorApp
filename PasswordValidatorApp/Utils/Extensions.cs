using PasswordValidatorApp.Exceptions;

namespace PasswordValidatorApp.Utils
{
    public static class Extensions
    {
        public static byte TryParseToByte(this string str)
        {
            if (byte.TryParse(str, out byte result))
                return result;
            else
                throw new ParsingException("");
        }
    }
}
