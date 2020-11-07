using Cube.Domain.Aggregates.CubeAggregate;
using NUnit.Framework;

namespace Cube.Test
{
    public class CubeUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CubesShouldNot_CollidesWith_WhenTheyAreDifferent()
        {
            var pointX = new Point(2, 2, 2);
            var cubeX = new Domain.Aggregates.CubeAggregate.Cube(pointX, 2);

            var pointY = new Point(10, 10, 10);
            var cubeY = new Domain.Aggregates.CubeAggregate.Cube(pointY, 10);

            Assert.IsFalse(cubeX.CollidesWith(cubeY));
        }

        [Test]
        public void CubesShould_CollidesWith_WhenTheyAreEquals()
        {
            var pointX = new Point(2, 2, 2);
            var cubeX = new Domain.Aggregates.CubeAggregate.Cube(pointX, 2);

            var pointY = new Point(3, 2, 2);
            var cubeY = new Domain.Aggregates.CubeAggregate.Cube(pointY, 2);

            Assert.IsTrue(cubeX.CollidesWith(cubeY));
        }

        [Test]
        public void CubesShould_IntersectinoVolumeWith_WhenTheyAreValids()
        {
            var pointX = new Point(2, 2, 2);
            var cubeX = new Domain.Aggregates.CubeAggregate.Cube(pointX, 2);

            var pointY = new Point(3, 2, 2);
            var cubeY = new Domain.Aggregates.CubeAggregate.Cube(pointY, 2);

            Assert.AreEqual(4d,cubeX.IntersectionVolumeWith(cubeY));
        }

    }
}