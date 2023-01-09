using PasswordValidatorApp.Domain.StringsParser;
using PasswordValidatorApp.Exceptions;
using PasswordValidatorApp.Utils;
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
        private readonly StringParser stringParser = new StringParser(Constants.VALIDATION_PATTERN, Constants.SPLIT_PATTERN);

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

        [TestMethod]
        public void GetValidationData()
        {
            var sourseString = "a 1-5: abcd";

            var result = stringParser.GetValidationData(sourseString);

            Assert.IsTrue(result.SearchCharacter == 'a', "SearchCharacter must be equal to the first symbol ot the source string");
            Assert.IsTrue(result.MinimumNumberOfOccurrences == 1);
            Assert.IsTrue(result.MaximumNumberOfOccurrences == 5);
            Assert.IsTrue(result.PasswordString == "abcd");
        }

        [TestMethod]
        [ExpectedException(typeof(ParsingException),
            "Source string must not be empty.")]
        public void GetValidationData_ThrowsAnException_ForEmptyString()
        {
            var sourseString = "";
            stringParser.GetValidationData(sourseString);
        }

        [TestMethod]
        [ExpectedException(typeof(ParsingException),
            "Both digits should be provided.")]
        public void GetValidationData_ThrowsAnException_ForMissingDigits()
        {
            var sourseString = "a -5: abcd";
            stringParser.GetValidationData(sourseString);
        }
    }
}
