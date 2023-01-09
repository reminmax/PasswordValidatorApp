using PasswordValidatorApp.Data.Entities;

namespace PasswordValidatorApp.Domain.Validator
{
    public interface IPswValidator
    {
        bool CheckIfPasswordValid(ValidationData validationData);
    }
}
