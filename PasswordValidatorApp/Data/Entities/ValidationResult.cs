using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidatorApp.Data.Entities
{
    public class ValidationResult
    {
        private List<string> _errors;
        private List<string> _validPasswords;

        internal ValidationResult()
        {
            _errors = new List<string>(0);
            _validPasswords = new List<string>(0);
        }

        public bool HasError => _errors.Count > 0;

        public IReadOnlyCollection<string> Errors => _errors;
        public IReadOnlyCollection<string> ValidPasswords => _validPasswords;

        internal void AddError(string errorMessage)
        {
            _errors.Add(errorMessage);
        }

        internal void AddValidPassword(string password)
        {
            _validPasswords.Add(password);
        }
    }
}
