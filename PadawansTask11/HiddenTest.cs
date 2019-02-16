using System;
using NUnit.Framework;

namespace PadawansTask11.Tests
{
    [TestFixture]
    [Category("TryToHackHiddenTests")]
    public class HiddenTest
    {
        [TestCase(new[] { 0.0001, 1.0002, -0.0003, 1, 0.0003, 1, -0.0003 }, 0.001, ExpectedResult = 3)]
        [TestCase(new[] { 0.0001, 1.0002, -0.0003, 1, 0.0003, 1, -0.00031 }, 0.000001, ExpectedResult = null)]
        [TestCase(new[] { 1.0001, 1.0002, -3.0003, 1, 0.0003, 8.9, -0.0003, 0.901 }, 0.001, ExpectedResult = null)]
        [TestCase(new[] { 2.451, -12, 67, 78.901, -45, -1.456, -33.01, 123.56, 0.123, 0.679000000000002 }, 0.00000001, ExpectedResult = 5)]
        [TestCase(new[] { 2.451, -12, 67, 78.901, -45, -1.456, -33.01, 123.56, 0.123, 0.679000000000002 }, double.Epsilon, ExpectedResult = null)]
        [TestCase(new[] { double.MaxValue, 1, double.MaxValue }, double.Epsilon, ExpectedResult = 1)]
        [TestCase(new[] { double.MinValue, 1, double.MinValue }, double.Epsilon, ExpectedResult = 1)]
        [TestCase(new[] { double.MaxValue, 1, double.MinValue }, double.Epsilon, ExpectedResult = null)]
        [TestCase(new[] { double.MaxValue, double.MinValue, 1, double.MaxValue, double.MinValue }, double.Epsilon, ExpectedResult = 2)]
        public int? FindIndexTests(double[] array, double accuracy)
            => ArrayExtensions.FindIndex(array, accuracy);

        [Test]
        [Property("Mark", 1)]
        public void FindIndexTest_ArrayIsNull_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => ArrayExtensions.FindIndex(null, 0.0001),
                "The array cannot be null.");

        [Test]
        [Property("Mark", 1)]
        public void FindIndexTest_ArrayIsEmpty_ThrowArgumentException()
            => Assert.Throws<ArgumentException>(() => ArrayExtensions.FindIndex(new double[] { }, 0.0001),
                "The array cannot be empty.");

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [Property("Mark", 1)]
        public void FindIndexTest_ArrayIsEmpty_ThrowArgumentOutOfRangeException(double accuracy)
            => Assert.Throws<ArgumentOutOfRangeException>(() => ArrayExtensions.FindIndex(new double[] { 1 }, accuracy),
                "The accuracy cannot be less than zero or more than one.");
    }
}
