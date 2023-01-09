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
            throw new NotImplementedException();
        }
    }
}
