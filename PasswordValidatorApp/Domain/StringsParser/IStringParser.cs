using PasswordValidatorApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidatorApp.Domain.StringsParser
{
    public interface IStringParser
    {
        bool IsStringMatchesPattern(string input);

        ValidationData GetValidationData(string input);
    }
}
