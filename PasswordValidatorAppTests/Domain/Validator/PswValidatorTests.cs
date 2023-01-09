using PasswordValidatorApp.Data.Entities;
using PasswordValidatorApp.Domain.Validator;

namespace PasswordValidatorAppTests.Domain.Validator
{
    [TestClass]
    public class PswValidatorTests
    {
        private readonly PswValidator pswValidator = new();

        [TestMethod]
        public void CheckIfPasswordValid_ReturnsTrue()
        {
            var validationData = new ValidationData(
                searchCharacter: 't',
                minimumNumberOfOccurrences: 1,
                maximumNumberOfOccurrences: 3,
                passwordString: "abtabt");

            var result = pswValidator.CheckIfPasswordValid(validationData);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckIfPasswordValid_ReturnsFalse()
        {
            var validationData = new ValidationData(
                searchCharacter: 't',
                minimumNumberOfOccurrences: 2,
                maximumNumberOfOccurrences: 3,
                passwordString: "abcdft");

            var result = pswValidator.CheckIfPasswordValid(validationData);

            Assert.IsFalse(result);
        }
    }
}
