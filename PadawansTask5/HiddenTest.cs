using System;
using NUnit.Framework;

namespace PadawansTask5.Tests
{
    [TestFixture]
    [Category("TryToHackHiddenTests")]
    public class HiddenTest
    {
        [TestCase(arg: new[] { 1, 1, 0, 0, 0, 0, 1, 1 }, ExpectedResult = "Yes")]
        [TestCase(arg: new[] { 1, 1, 0, 0, 1, 0, 0, 1, 1 }, ExpectedResult = "Yes")]
        [TestCase(arg: new[] { 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 1 }, ExpectedResult = "Yes")]
        [TestCase(arg: new[] { 1, 1, 0, 0, 0, 0, 1, 1, 0 }, ExpectedResult = "No")]
        [TestCase(arg: new[] { 1, 0, 1, 1, 0, 0, 0, 0, 0 }, ExpectedResult = "No")]
        [TestCase(arg: new[] { 1, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 1 }, ExpectedResult = "No")]
        public string CheckIfSymmetricTests(int[] source) => ArrayHelper.CheckIfSymmetric(source);

        [Test]
        public void CheckIfSymmetric_Source_IsNull_Throw_ArgumentNullException()
        {
            int[] source = null;
            Assert.Throws<ArgumentNullException>(() => ArrayHelper.CheckIfSymmetric(source), $"{nameof(source)} cannot be null.");
        }

        [Test]
        public void CheckIfSymmetric_Source_IsEmptyArray_Throw_ArgumentException()
        {
            int[] source = { };
            Assert.Throws<ArgumentException>(() => ArrayHelper.CheckIfSymmetric(source), $"{nameof(source)} cannot be empty.");
        }
    }
}
