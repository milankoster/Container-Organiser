using System.Linq;
using NUnit.Framework;

namespace ContainerVervoer.Tests
{
    public class ShipTest
    {
        private Config _config = new Config();

        [Test]
        public void CreateShip()
        {
            Ship ship = new Ship(50000,4,3,_config);
            Assert.AreEqual(4,ship.Columns.Count);
            Assert.AreEqual(3,ship.Columns.First().Stacks.Count);
        }
    }
}