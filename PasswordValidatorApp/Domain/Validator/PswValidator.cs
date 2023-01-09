using PasswordValidatorApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
