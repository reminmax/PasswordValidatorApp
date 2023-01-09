using PasswordValidatorApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidatorApp.Domain.Validator
{
    public interface IPswValidator
    {
        bool CheckIfPasswordValid(ValidationData validationData);
    }
}
