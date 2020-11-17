using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using ContainerVervoer.Exceptions;

namespace ContainerVervoer
{
    static class Program
    {
        /*To Do List
         * Unit Testing
        */
        
       static void Main(string[] args)
        {
            Ship ship = new Ship(200000, 3, 3);
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
                PreSortingChecker.ExecuteChecks(ship,containers);
                ContainerCrane.Sort(ship, containers);
                ShipVisualiser.OpenInChrome(ship);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");                
            }

            

        }
    }
}