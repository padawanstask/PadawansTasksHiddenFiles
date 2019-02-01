using System;
using NUnit.Framework;

namespace PadawansTask6.Tests
{
    [TestFixture]
    public class HiddenTest
    {
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(124121133, ExpectedResult = 124121313)]
        public int? NextBiggerThan_WithNumberForWhichBiggerNumberExists(int number) 
            => NumberFinder.NextBiggerThan(number);

        [TestCase(10, ExpectedResult = null)]
        [TestCase(int.MaxValue, ExpectedResult = null)]
        [TestCase(2, ExpectedResult = null)]
        [TestCase(2000, ExpectedResult = null)]
        [TestCase(111111111, ExpectedResult = null)]
        public int? NextBiggerThan_WithNumberForWhichBiggerNumberDoesNotExist(int number) 
            => NumberFinder.NextBiggerThan(number);

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(int.MinValue)]
        public void NextBiggerThan_WithNegativeNumber_ThrowArgumentException(int number)
            => Assert.Throws<ArgumentException>(() => NumberFinder.NextBiggerThan(number),
                message:$"Value of {nameof(number)} cannot be less zero.");

    }
}
