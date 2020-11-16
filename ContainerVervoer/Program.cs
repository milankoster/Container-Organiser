using System;
using System.Collections.Generic;
using ContainerVervoer.Exceptions;

namespace ContainerVervoer
{
    static class Program
    {
        /*To Do List
         * Exceptions with variables
         * 
         * Min / Max weight containers
         * 
         * Magic Numbers 
         * 
         * Unit Testing
         */
        
        
        static void Main(string[] args)
        {
            Ship ship = new Ship(50000, 3, 3);
            List<Container> containers = new List<Container>()
            {
                new Container(1000, ContainerType.VaCo),
                new Container(1500, ContainerType.VaCo),
                new Container(2000, ContainerType.VaCo),
                new Container(1500, ContainerType.Cooled),
                new Container(1500, ContainerType.Cooled),
                new Container(1500, ContainerType.Cooled),
                new Container(1500, ContainerType.Cooled),
                new Container(1500, ContainerType.Cooled),
                new Container(1500, ContainerType.Valuable),
                new Container(1500, ContainerType.Valuable),
                new Container(1500, ContainerType.Valuable),
                new Container(1500, ContainerType.Normal),
                new Container(1500, ContainerType.Normal),
                new Container(1500, ContainerType.Normal),
                new Container(1500, ContainerType.Normal),
                new Container(1500, ContainerType.Normal),
                new Container(1500, ContainerType.Normal),
                new Container(1500, ContainerType.Normal),
                new Container(1500, ContainerType.Normal),
                new Container(1500, ContainerType.Normal),


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