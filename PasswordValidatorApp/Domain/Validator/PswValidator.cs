using PasswordValidatorApp.Data.Entities;

namespace PasswordValidatorApp.Domain.Validator
{
    public class PswValidator : IPswValidator
    {
        public bool CheckIfPasswordValid(ValidationData validationData)
        {
            var countChars = validationData.PasswordString.Count(t => t == validationData.SearchCharacter);

            return countChars >= validationData.MinimumNumberOfOccurrences
                && countChars <= validationData.MaximumNumberOfOccurrences;
        }
    }
}
