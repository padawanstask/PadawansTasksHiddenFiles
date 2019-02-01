using System.Collections.Generic;
using CartesianNeighbors;
using NUnit.Framework;
using System;

namespace PadawansTask9.Tests
{
    [TestFixture]
    public class HiddenTest
    {

        private Point[] points;

        private static IEnumerable<TestCaseData> DataCases
        {
            get
            {
                yield return new TestCaseData(new Point(3, 3), 2, new List<Point> {
                                                                    new Point(3, 4),
                                                                    new Point(4, 4),
                                                                    new Point(2, 3),
                                                                    new Point(2, 2),
                                                                    new Point(5, 2)
                                                                  });
                yield return new TestCaseData(new Point(3, 3), 1, new List<Point> {
                                                                    new Point(3, 4),
                                                                    new Point(4, 4),
                                                                    new Point(2, 3),
                                                                    new Point(2, 2)
                                                                  });
                yield return new TestCaseData(new Point(-2, -4), 3, new List<Point> {
                                                                    new Point(-2, -5),
                                                                    new Point(0, -3) 
                                                                  });
                yield return new TestCaseData(new Point(-1, 10), 6, new List<Point> {
                                                                    new Point(-2, 5),
                                                                    new Point(3, 4),
                                                                    new Point(4, 4),
                                                                    new Point(0, 16)
                                                                  });
            }
        }

        [SetUp]
        public void Init()
        {
            points = new Point[]
            {
                new Point(-2, 5),
                new Point(6, 6),
                new Point(3, 4),
                new Point(4, 4),
                new Point(2, 3),
                new Point(2, 2),
                new Point(5, 2),
                new Point(3, -2),
                new Point(-2, -5),
                new Point(0, 16),
                new Point(31, 14),
                new Point(-12, 44),
                new Point(20, 13),
                new Point(22, -2),
                new Point(-5, 2),
                new Point(3, -2),
                new Point(-2, -50),
                new Point(-76, -6),
                new Point(-30, 04),
                new Point(40, 4),
                new Point(0, -3),
                new Point(-2, 0),
                new Point(0, 0),
                new Point(12, -2)
            };
        }

        [TestCaseSource(nameof(DataCases))]
        public void GetNeighborsTests(Point point, int range, List<Point> expected)
        {
            var actual = Cartesian—oordinates.GetNeighbors(point, range, this.points);

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void GetNeighbors_IfRangeLessOrEqualsZero_ThrowArgumentException()
        {
            var point = new Point();

            int range = -1;

            Assert.Throws<ArgumentException>(() => Cartesian—oordinates.GetNeighbors(point, range, this.points),
                message: "Range cannot be less or equals zero.");
        }

        [Test]
        public void GetNeighbors_IfPointsIsEqualNull_ThrowArgumentNullException()
        {
            var point = new Point();

            int range = 1;

            points = null;

            Assert.Throws<ArgumentNullException>(() => Cartesian—oordinates.GetNeighbors(point, range, this.points),
                message: "Points cannot be equals null.");
        }
    }
}
