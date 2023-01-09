using PasswordValidatorApp.Domain.StringsParser;
using PasswordValidatorApp.Domain.Validator;
using PasswordValidatorApp.Domain;
using PasswordValidatorApp.Exceptions;
using PasswordValidatorApp.Utils;
using PasswordValidatorAppTests.Data.Repository;

namespace PasswordValidatorAppTests.Domain
{
    [TestClass]
    public class MainProcessorTests
    {
        [TestMethod]
        public async Task GetValidationResult_SuccessResult()
        {
            var testStringArray = new string[]
            {
                "a 1-5: abcdj",
                "z 2-4: asfalseiruqwo",
                "b 3-6: bhhkkbbjjjb"
            };

            var mainProcessor = new MainProcessor(
                new MockFileRepository(testStringArray),
                new StringParser(Constants.VALIDATION_PATTERN, Constants.SPLIT_PATTERN),
                new PswValidator());

            var result = await mainProcessor.GetValidationResult();

            Assert.IsTrue(result.Errors.Count == 0, "Errors list must be empty.");
            Assert.IsTrue(result.ValidPasswords.Count == 2, "Result must contains two valid passwords.");
            Assert.IsTrue(result.ValidPasswords.ElementAt(0) == "abcdj");
            Assert.IsTrue(result.ValidPasswords.ElementAt(1) == "bhhkkbbjjjb");
        }

        [TestMethod]
        public async Task GetValidationResult_NoValidPasswords()
        {
            var testStringArray = new string[]
            {
                "a 1-5: bcbcbc",
                "z 2-4: asfalseiruqwo",
                "b 3-6: abcdfgh"
            };

            var mainProcessor = new MainProcessor(
                new MockFileRepository(testStringArray),
                new StringParser(Constants.VALIDATION_PATTERN, Constants.SPLIT_PATTERN),
                new PswValidator());

            var result = await mainProcessor.GetValidationResult();

            Assert.IsTrue(result.Errors.Count == 0, "Errors list must be empty.");
            Assert.IsTrue(result.ValidPasswords.Count == 0, "Result must contains no valid passwords.");
        }

        [TestMethod]
        [ExpectedException(typeof(ParsingException))]
        public async Task GetValidationResult_WithInvalidStrings()
        {
            var testStringArray = new string[]
            {
                "a 1-5: abcd",
                "z -4: asfalseiruqwo",
                "z 2-: asfalseiruqwo",
                " 3-6: abcdfgh",
                "b -: abcdfgh",
                "b 3-6 abcdfgh",
                "b 3-6: ",
                " ",
                "",
            };

            var mainProcessor = new MainProcessor(
                new MockFileRepository(testStringArray),
                new StringParser(Constants.VALIDATION_PATTERN, Constants.SPLIT_PATTERN),
                new PswValidator());

            await mainProcessor.GetValidationResult();
        }

        [TestMethod]
        public async Task GetValidationResult_WithEmptyInput()
        {
            var testStringArray = new string[] { };

            var mainProcessor = new MainProcessor(
                new MockFileRepository(testStringArray),
                new StringParser(Constants.VALIDATION_PATTERN, Constants.SPLIT_PATTERN),
                new PswValidator());

            var result = await mainProcessor.GetValidationResult();

            Assert.IsTrue(result.Errors.Count == 1, "Errors list must be empty.");
            Assert.IsTrue(result.Errors.ElementAt(0) == "Specified file is empty. There is nothing to validate.");
            Assert.IsTrue(result.ValidPasswords.Count == 0, "Result must contains no valid passwords.");
        }

    }
}
