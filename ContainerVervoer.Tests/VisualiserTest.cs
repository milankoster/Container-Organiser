using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ContainerVervoer.Tests
{
    public class VisualiserTest
    {
        private Config _config = new Config();
        
        [Test]
        public void TestEmptyUnevenShip()
        {
            Ship ship = new Ship(500000,3,3, _config);
            Assert.AreEqual("https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html?length=3&width=3&stacks=,,/,,/,,&weights=,,/,,/,,",ShipVisualiser.GetUrl(ship));
        }

        [Test]
        public void TestEmptyEvenShip()
        {
            Ship ship = new Ship(500000,4,4, _config);
            Assert.AreEqual("https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html?length=4&width=4&stacks=,,,/,,,/,,,/,,,&weights=,,,/,,,/,,,/,,,", ShipVisualiser.GetUrl(ship));
        }

        [Test]
        public void TestShipWithContainers()
        {
            Ship ship = new Ship(200000, 3, 3, _config);
            List<Container> containers = new List<Container>()
            {
                new Container(5000, ContainerType.VaCo),
                new Container(5500, ContainerType.VaCo),
                new Container(6000, ContainerType.VaCo),
                new Container(6500, ContainerType.Cooled),
                new Container(6500, ContainerType.Cooled),
                new Container(6500, ContainerType.Cooled),
                new Container(6500, ContainerType.Cooled),
                new Container(6500, ContainerType.Cooled),
                new Container(6500, ContainerType.Valuable),
                new Container(6500, ContainerType.Valuable), 
                new Container(6500, ContainerType.Valuable),
                new Container(6500, ContainerType.Normal),
                new Container(6500, ContainerType.Normal),
                new Container(6500, ContainerType.Normal),
                new Container(6500, ContainerType.Normal),
                new Container(6500, ContainerType.Normal),
                new Container(6500, ContainerType.Normal),
                new Container(6500, ContainerType.Normal),
                new Container(6500, ContainerType.Normal),
                new Container(6500, ContainerType.Normal),
            };
            try
            {
                PreSortingChecker.ExecuteChecks(ship,containers, _config);
                ContainerCrane.Sort(ship, containers, _config);
                Assert.AreEqual("https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html?length=3&width=3&" +
                              "stacks=3-3-4,1-1,1-2/3-4,1-1,1-2/3-3-4,1-1,1-2&" +
                              "weights=6500-6500-5500,6500-6500,6500-6500/6500-5000,6500-6500,6500-6500/6500-6500-6000,6500-6500,6500-6500", ShipVisualiser.GetUrl(ship));
            }
            catch(Exception e)
            {
                Assert.Fail();              
            }
        }
        
    }
}