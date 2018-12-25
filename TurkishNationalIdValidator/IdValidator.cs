using System;
using System.Linq;

namespace TurkishNationalIdValidator
{
    public class IdValidator
    {
        public bool Validate(string nationalId)
        {
            if (string.IsNullOrEmpty(nationalId))
            {
                throw new ArgumentNullException();
            }

            if (!Int64.TryParse(nationalId, out long _))
            {
                throw new ArgumentException();
            }

            if (nationalId.Length < 11)
            {
                throw new ArgumentException("The Turkish national Id must be 11 digits.");
            }

            int sumOfFirstTenDigits = (int)nationalId.Take(10).Select(Char.GetNumericValue).Aggregate((a, b) => a + b);

            int eleventhDigit = (int)Char.GetNumericValue(nationalId, 10);

            if (sumOfFirstTenDigits % 10 != eleventhDigit)
            {
                return false;
            }

            var i = (int)Char.GetNumericValue(nationalId, 0)
                    + (int)Char.GetNumericValue(nationalId, 2)
                    + (int)Char.GetNumericValue(nationalId, 4)
                    + (int)Char.GetNumericValue(nationalId, 6)
                    + (int)Char.GetNumericValue(nationalId, 8);

            var j = (int)Char.GetNumericValue(nationalId, 1)
                    + (int)Char.GetNumericValue(nationalId, 3)
                    + (int)Char.GetNumericValue(nationalId, 5)
                    + (int)Char.GetNumericValue(nationalId, 7);


            int tenthDigit = (int)Char.GetNumericValue(nationalId, 9);

            if ((i * 7 - j) % 10 != tenthDigit)
            {
                return false;
            }

            return true;
        }

    }
}
