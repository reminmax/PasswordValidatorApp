using PasswordValidatorApp.Data.Entities;
using PasswordValidatorApp.Exceptions;
using PasswordValidatorApp.Utils;
using System.Text.RegularExpressions;

namespace PasswordValidatorApp.Domain.StringsParser
{
    public class StringParser : IStringParser
    {
        private readonly string _validationPattern;
        private readonly string _splitPattern;

        public StringParser(string validationPattern, string splitPattern)
        {
            _validationPattern = validationPattern;
            _splitPattern = splitPattern;
        }

        public ValidationData GetValidationData(string input)
        {
            var validationDataArray = Regex.Split(input, _splitPattern)
                .Where(s => s != string.Empty)
                .ToArray();

            if (validationDataArray.Length != 4)
            {
                throw new ParsingException("Incorrect string: {input}");
            }

            return new ValidationData(
                searchCharacter: validationDataArray[0].First(),
                minimumNumberOfOccurrences: validationDataArray[1].TryParseToByte(),
                maximumNumberOfOccurrences: validationDataArray[2].TryParseToByte(),
                passwordString: validationDataArray[3]);
        }

        public bool IsStringMatchesPattern(string input)
        {
            return Regex.IsMatch(input, _validationPattern);
        }
    }
}
