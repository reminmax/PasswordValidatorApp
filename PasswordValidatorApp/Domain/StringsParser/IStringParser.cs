using PasswordValidatorApp.Data.Entities;

namespace PasswordValidatorApp.Domain.StringsParser
{
    public interface IStringParser
    {
        bool IsStringMatchesPattern(string input);

        ValidationData GetValidationData(string input);
    }
}
