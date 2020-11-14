using System;
using System.Collections.Generic;
using ContainerVervoer.Exceptions;

namespace ContainerVervoer
{
    static class Program
    {
        /*To Do List
         * Begin checks
         *     - Size
         *     - Weight
         * 
         * Min / Max weight containers
         * Min / Max weight ship
         *
         * Magic Numbers 
         * 
         * Unit Testing
         * 
         * Check Private / public getter setter
         */
        
        
        static void Main(string[] args)
        {
            Ship ship = new Ship(100000, 3, 3);
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
                ContainerCrane.Sort(ship, containers);
                ShipVisualiser.OpenInChrome(ship);
            }
            catch(NoValidLocationException e)
            {
                Console.WriteLine(e.ErrorMessage);                
            }

            
            
            
        }
    }
}