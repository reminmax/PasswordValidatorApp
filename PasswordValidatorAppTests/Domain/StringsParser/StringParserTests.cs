using PasswordValidatorApp.Domain.StringsParser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidatorAppTests.Domain.StringsParser
{
    [TestClass]
    public class StringParserTests
    {
        private readonly StringParser stringParser = new StringParser();

        [TestMethod]
        public void IsStringMatchesPattern_ReturnsTrue_ForValidString()
        {
            var sourseString = "a 1-5: abcdj";

            var result = stringParser.IsStringMatchesPattern(sourseString);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsStringMatchesPattern_ReturnsFalse_ForInvalidString_DigitInsteadSearchChar()
        {
            var sourseString = "1 1-5: abcdj";

            var result = stringParser.IsStringMatchesPattern(sourseString);

            Assert.IsFalse(result, "Invalid string. Digit instead search char found.");
        }

        [TestMethod]
        public void IsStringMatchesPattern_ReturnsFalse_ForInvalidString_NoDashBetweenDigits()
        {
            var sourseString = "a 15: abcdj";

            var result = stringParser.IsStringMatchesPattern(sourseString);

            Assert.IsFalse(result, "Invalid string. Dash between digits is missing.");
        }

        [TestMethod]
        public void IsStringMatchesPattern_ReturnsFalse_ForInvalidString_NoSpaceAfterSearchChar()
        {
            var sourseString = "a1-5: abcdj";

            var result = stringParser.IsStringMatchesPattern(sourseString);

            Assert.IsFalse(result, "Invalid string. Space after the seacrh char is missing.");
        }

        [TestMethod]
        public void IsStringMatchesPattern_ReturnsFalse_ForInvalidString_ColonIsMissing()
        {
            var sourseString = "a 1-5 abcdj";

            var result = stringParser.IsStringMatchesPattern(sourseString);

            Assert.IsFalse(result, "Invalid string. Colon after <1-5> is missing.");
        }

        [TestMethod]
        public void IsStringMatchesPattern_ReturnsFalse_ForInvalidString_SpaceBeforePasswordIsMissing()
        {
            var sourseString = "a 1-5:abcdj";

            var result = stringParser.IsStringMatchesPattern(sourseString);

            Assert.IsFalse(result, "Invalid string. Space before the password is missing.");
        }

        [TestMethod]
        public void IsStringMatchesPattern_ReturnsFalse_ForInvalidString_PasswordValueIsMissing()
        {
            var sourseString = "a 1-5:";

            var result = stringParser.IsStringMatchesPattern(sourseString);

            Assert.IsFalse(result, "Invalid string. The password value is missing.");
        }

        [TestMethod]
        public void IsStringMatchesPattern_ReturnsFalse_ForInvalidString_FirstDigitIsMissing()
        {
            var sourseString = "a -5: abcdj";

            var result = stringParser.IsStringMatchesPattern(sourseString);

            Assert.IsFalse(result, "Invalid string. Minimum occurences number is missing.");
        }

        [TestMethod]
        public void IsStringMatchesPattern_ReturnsFalse_ForInvalidString_SecondDigitIsMissing()
        {
            var sourseString = "a 1-: abcdj";

            var result = stringParser.IsStringMatchesPattern(sourseString);

            Assert.IsFalse(result, "Invalid string. Maximum occurences number is missing.");
        }

        [TestMethod]
        public void IsStringMatchesPattern_ReturnsFalse_ForInvalidString_EmptySourceValue()
        {
            var sourseString = "";

            var result = stringParser.IsStringMatchesPattern(sourseString);

            Assert.IsFalse(result, "Invalid string. Value can't be empty.");
        }

    }
}
