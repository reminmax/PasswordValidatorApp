using PasswordValidatorApp.Data.Entities;
using PasswordValidatorApp.Data.Repository;
using PasswordValidatorApp.Domain.StringsParser;
using PasswordValidatorApp.Domain.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidatorApp.Domain
{
    public class MainProcessor
    {
        private readonly IStringParser _stringParser;
        private readonly IPswValidator _validator;
        private readonly IRepository _repository;

        public MainProcessor(
            IRepository repository,
            IStringParser stringParser,
            IPswValidator validator)
        {
            _stringParser = stringParser;
            _validator = validator;
            _repository = repository;
        }

        public async Task<ValidationResult> GetValidationResult()
        {
            var result = new ValidationResult();

            var stringCollection = await _repository.GetDataForValidation();
            if (!stringCollection.Any())
            {
                result.AddError("Specified file is empty. There is nothing to validate.");
                return result;
            }

            foreach (var line in stringCollection)
            {
                if (!_stringParser.IsStringMatchesPattern(line))
                {
                    result.AddError($"The string <{line}> is invalid and will not be validated.");
                    continue;
                }

                var validationData = _stringParser.GetValidationData(line);

                if (_validator.CheckIfPasswordValid(validationData))
                {
                    result.AddValidPassword(validationData.PasswordString);
                }
            }

            return result;
        }
    }
}
