using GeometryAreaLibrary;
using Newtonsoft.Json.Bson;
using NUnit.Framework;

namespace GeometryTest
{
    [TestFixture]
    public class CircleTests
    {
        [TestCase(-5)]
        [TestCase(0)]
        [TestCase(1e-10)]
        [TestCase(-1)]
        public static void IncorrectRadiusExceptionTest(double r)
        {
            Assert.Catch<ArgumentException>(() => new Circle(r));
        }

        [TestCase(3, Math.PI * 3 * 3)]
        [TestCase(2, Math.PI * 2 * 2)]
        [TestCase(1, Math.PI * 1 * 1)]
        [TestCase(5, Math.PI * 5 * 5)]
        [TestCase(2, Math.PI * 2 * 2)]
        public static void AreaTest(double r, double expectedResult)
        {
            var circle = new Circle(r);
            double actualResult = circle.GetArea();
            Assert.NotNull(actualResult);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
