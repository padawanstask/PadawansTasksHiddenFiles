using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace PadawansTask7.Tests
{
    [TestFixture]
    public class HiddenTest
    {
        private static IEnumerable<TestCaseData> DataCases
        {
            get
            {
                yield return new TestCaseData(arg1: new string[] { "Beg", "Life", "I", "To" }, arg2: new string[] { "I", "To", "Beg", "Life" });
                yield return new TestCaseData(arg1: new string[] { "", "Moderately", "Brains", "Pizza" }, arg2: new string[] { "", "Pizza", "Brains", "Moderately" });
                yield return new TestCaseData(arg1: new string[] { "Longer", "Longest", "Short" }, arg2: new string[] { "Short", "Longer", "Longest" });
                yield return new TestCaseData(arg1: new string[] { "Telescopes", "Glasses", "Eyes", "Monocles" }, arg2: new string[] { "Eyes", "Glasses", "Monocles", "Telescopes" });
            }
        }

        [TestCaseSource(nameof(DataCases))]
        public void OrderStringsByLengthTests(string[] actual, string[] expected)
        {
            StringExtension.OrderStringsByLength(actual);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Property("Mark", 2)]
        public void OrderStringsByLength_ArrayIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => StringExtension.OrderStringsByLength(null),
                message: "Array cannot be null.");
        }

        [Test]
        [Property("Mark", 2)]
        public void OrderStringsByLength_ArrayElememtIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => StringExtension.OrderStringsByLength(new[] { "Ray", "John", null }),
                message: "Array elements cannot be null.");
        }

    }
}
