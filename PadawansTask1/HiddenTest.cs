using System;
using NUnit.Framework;

namespace PadawansTask1.Tests
{
    [TestFixture]
    public class HiddenTest
    {
        [TestCase(1500, 5, 100, 5000, ExpectedResult = 15)]
        [TestCase(1500000, 2.5, 10000, 2000000, ExpectedResult = 10)]
        [TestCase(1500000, 0.25, 1000, 2000000, ExpectedResult = 94)]
        public int GetYearsTests(int initialPopulation, double percent, int visitors, int currentPopulation)
            => Population.GetYears(initialPopulation, percent, visitors, currentPopulation);

        [TestCase(0, 0.25, 1000, 2000000)]
        [TestCase(-100, 0.25, 1000, 2000000)]
        [Property("Mark", 2)]
        public void GetYearsTest_InitialPopulation_LessOrEqualsZero_ThrowArgumentException(int initialPopulation, double percent, int visitors, int currentPopulation)
        {
            Assert.Throws<ArgumentException>(() =>
                Population.GetYears(initialPopulation, percent, visitors, currentPopulation),
            message:"Initial population cannot be less or equals zero.");
        }

        [TestCase(1500, 101, 100, 5000)]
        [TestCase(1500, -1, 100, 5000)]
        [Property("Mark", 2)]
        public void GetYearsTest_PercentOutOfRange_ThrowArgumentOutOfRangeException(int initialPopulation, double percent, int visitors, int currentPopulation)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                    Population.GetYears(initialPopulation, percent, visitors, currentPopulation),
                message: "Value of percents cannot be less then 0% or more then 100%.");
        }

        [TestCase(1500, 5, -100, 5000)]
        [TestCase(1500, 1, -5, 5000)]
        [Property("Mark", 2)]
        public void GetYearsTest_Visitors_LessOrEqualsZero_ThrowArgumentException(int initialPopulation, double percent, int visitors, int currentPopulation)
        {
            Assert.Throws<ArgumentException>(() =>
                    Population.GetYears(initialPopulation, percent, visitors, currentPopulation),
                message: "Count of visitors cannot be less zero.");
        }

        [TestCase(0, 0.25, 1000, 0)]
        [TestCase(-100, 0.25, 1000, -100)]
        [Property("Mark", 2)]
        public void GetYearsTest_CurrentPopulation_LessOrEqualsZero_ThrowArgumentException(int initialPopulation, double percent, int visitors, int currentPopulation)
        {
            Assert.Throws<ArgumentException>(() =>
                    Population.GetYears(initialPopulation, percent, visitors, currentPopulation),
                message: "Current population cannot be less or equals zero.");
        }
    }
}