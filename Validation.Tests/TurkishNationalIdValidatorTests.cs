using System;
using NUnit.Framework;

namespace Validation.Tests
{
    [TestFixture]
    public class TurkishNationalIdValidatorTests
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Validate_WhenNationalIdIsNullOrEmpty_ThrowException(string nationalId)
        {
            var validator = new TurkishNationalIdValidator();

            Assert.That(() => validator.Validate(nationalId), Throws.ArgumentNullException);
        }

        [Test]
        public void Validate_WhenNationalIdLengthLessThanEleven_ThrowException()
        {
            var validator = new TurkishNationalIdValidator();

            Assert.That(() => validator.Validate("1000000000"), Throws.ArgumentException);
        }

        [Test]
        public void Validate_WhenNationalIdIsNotNumeric_ThrowException()
        {
            var validator = new TurkishNationalIdValidator();

            Assert.That(() => validator.Validate("aaaaaaaaaaa"), Throws.ArgumentException);
        }

        [Test]
        [TestCase("11111111111", Description = "The last digit of the sum of first ten-digits must be the eleventh digit of the national identity.")]
        [TestCase("11111111210", Description = "")]
        public void Validate_WhenNationalIdWrongFormat_ReturnFalse(string nationalId)
        {
            var validator = new TurkishNationalIdValidator();

            var result = validator.Validate(nationalId);

            Assert.That(result, Is.False);
        }
        
        [Test]
        public void Validate_WhenNationalIdTrueFormat_ReturnTrue()
        {
            var validator = new TurkishNationalIdValidator();

            var result = validator.Validate("65350205994");

            Assert.That(result, Is.True);
        }
    }
}
