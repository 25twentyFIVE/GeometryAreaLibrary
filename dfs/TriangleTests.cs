using GeometryAreaLibrary;
using Newtonsoft.Json.Bson;
using NUnit.Framework;

namespace GeometryTest
{
    [TestFixture]
    public class TriangleTests
    {
        [TestCase(-1, -1, -1)]
        [TestCase(0, 0, 0)]
        [TestCase(0, 1, 2)]
        [TestCase(-1, 0, 1)]
        public static void IncorrectEdgesExceptionTest(double a, double b, double c)
        {
            Assert.Catch<ArgumentException>(() => new Triangle(a, b, c));
        }

        [TestCase(3, 4, 5, 6)]
        [TestCase(2, 5, 6, 4.68)]
        [TestCase(1, 3, 3, 1.48)]
        [TestCase(5, 7, 9, 17.41)]
        [TestCase(2, 8, 7, 6.44)]
        public static void AreaTest(double a, double b, double c, double expectedResult)
        {
            var triangle = new Triangle(a, b, c);
            double actualResult = Math.Round(triangle.GetArea(), 2);
            Assert.NotNull(actualResult);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(3, 4, 5, 12)]
        [TestCase(5, 6, 4, 15)]
        [TestCase(1, 3, 3, 7)]
        [TestCase(4, 8, 5, 17)]

        public static void PerimeterTest(double a, double b, double c, double expectedResult)
        {
            var triangle = new Triangle(a, b, c);
            double actualResult = triangle.GetPerimeter();
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestCase(3, 4, 5, true)]
        [TestCase(6, 8, 10, true)]
        [TestCase(1, 3, 3, false)]
        [TestCase(4, 8, 5, false)]
        public static void IsRightTest(double a, double b, double c, bool expectedResult)
        {
            var triangle = new Triangle(a, b, c);
            bool actualResult = triangle.IsRight();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}