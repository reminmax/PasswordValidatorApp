using PasswordValidatorApp.Exceptions;
using PasswordValidatorApp.Utils;

namespace PasswordValidatorAppTests.Utils
{
    [TestClass]
    public class ExtensionsTests
    {
        [TestMethod]
        public void TryParseToByte_ReturnsByteValueForDigit()
        {
            var input = "3";

            var result = input.TryParseToByte();

            Assert.IsInstanceOfType(result, typeof(byte), "Result must be type of byte");
            Assert.AreEqual(result, (byte)3);
        }

        [TestMethod]
        [ExpectedException(typeof(ParsingException),
            "Source string must be digit.")]
        public void TryParseToByte_ReturnsNullForNonDigit()
        {
            var input = "b";

            input.TryParseToByte();
        }
    }
}
