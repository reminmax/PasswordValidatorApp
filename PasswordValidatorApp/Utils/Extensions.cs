using PasswordValidatorApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
