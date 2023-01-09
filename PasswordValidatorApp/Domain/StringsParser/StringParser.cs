using PasswordValidatorApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PasswordValidatorApp.Domain.StringsParser
{
    public class StringParser : IStringParser
    {
        private readonly string _validationPattern;

        public StringParser(string validationPattern)
        {
            _validationPattern = validationPattern;
        }

        public ValidationData GetValidationData(string input)
        {
            throw new NotImplementedException();
        }

        public bool IsStringMatchesPattern(string input)
        {
            return Regex.IsMatch(input, _validationPattern);
        }
    }
}
