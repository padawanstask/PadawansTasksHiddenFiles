using System;
using NUnit.Framework;
using System.Linq;
using static PadawansTask12.StringExtension;
using System.Collections.Generic;

namespace PadawansTask12.Tests
{
    [TestFixture]
    [Category("TryToHackHiddenTests")]
    public class HiddenTest
    {
        private const int CountASCIIChars = 128;

        private static IEnumerable<TestCaseData> DataCases
        {
            get
            {
                yield return new TestCaseData("abcde   fghijklmnopqrstuvwxyz abcdefghijklm  nopqrstuvwxyz abcdefghijklmnopqrstuvwxyz").Returns(false);
                yield return new TestCaseData("abcdefghijklmnopqrstuvwxyz").Returns(true);
                yield return new TestCaseData("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ").Returns(true);
                yield return new TestCaseData("1234567890").Returns(true);
                yield return new TestCaseData("sdfghjkl;.,mnbvcxzwert6ytrewqazxcvbhjio098765432qwaszxcvbjk, xsdrtyui").Returns(false);
                yield return new TestCaseData(@"1234567890abcdefghijklmnopqrstuvwxyz!@#$%^&*()_+=-|\~`?><,./").Returns(true);

            }
        }

        //[TestCase("abcde   fghijklmnopqrstuvwxyz abcdefghijklm  nopqrstuvwxyz abcdefghijklmnopqrstuvwxyz", false)]
        //[TestCase("abcdefghijklmnopqrstuvwxyz", true)]
        //[TestCase("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", true)]
        //[TestCase("1234567890", true)]
        //[TestCase("sdfghjkl;.,mnbvcxzwert6ytrewqazxcvbhjio098765432qwaszxcvbjk, xsdrtyui", false)]
        //[TestCase(@"1234567890abcdefghijklmnopqrstuvwxyz!@#$%^&*()_+=-|\~`?><,./ 	", true)]
        //public void AllCharactersAreUniqueTests(string source, bool result)
        //{
        //    Assert.That(AllCharactersAreUnique(source) == result);
        //}

        [TestCaseSource(nameof(DataCases))]
        public bool AllCharactersAreUniqueTests(string source)
        {
            return AllCharactersAreUnique(source);
        }

        [Test]
        public void AllCharactersAreUnique_WithUniqueEscSequences()
        {
            var chars = Enumerable.Range(0, 31).Select(x => (char)x).ToArray();

            string source = new string(chars.ToArray());

            Assert.IsTrue(AllCharactersAreUnique(source));
        }

        [Test]
        public void AllCharactersAreUnique_String_IsNull_Throw_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => AllCharactersAreUnique(null), "String cannot be null.");

        [Test]
        public void AllCharactersAreUnique_String_IsEmpty_Throw_ArgumentException()
            => Assert.Throws<ArgumentException>(() => AllCharactersAreUnique(string.Empty), "String cannot be empty.");

        [Test]
        public void AllCharactersAreUnique_AlwaysFalse()
        {
            string source = RandomString(CountASCIIChars * 2);
            Assert.IsFalse(StringExtension.AllCharactersAreUnique(source));
        }

        private string RandomString(int size)
        {
            var random = new Random();

            const string input = @"1234567890abcdefghijklmnopqrstuvwxyz!@#$%^&*()_+=-|\~`?><,./     ";

            var chars = Enumerable.Range(0, size).Select(x => input[random.Next(0, input.Length)]);

            return new string(chars.ToArray());
        }

    }
}
