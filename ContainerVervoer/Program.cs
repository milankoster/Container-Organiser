using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using ContainerVervoer.Exceptions;

namespace ContainerVervoer
{
    static class Program
    {
        static void Main(string[] args)
        {
            Config config = new Config();
            
            Ship ship = new Ship(200000, 3, 3, config);
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
            };

            
            
            try
            {
                PreSortingChecker.ExecuteChecks(ship,containers, config);
                ContainerCrane.Sort(ship, containers, config);
                ShipVisualiser.OpenInChrome(ship);
            }
            
            catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");                
            }
        }
    }
}