using System;
using System.Collections.Generic;

namespace ContainerVervoer
{
    class Program
    {
        /*To Do List
         * Improve code quality
         * Work through all TO DOs
         * Throw Proper Exceptions 
         * Begin checks
         *     - Size
         *     - Height
         * Unit Testing
         * Render in program / auto open browser
         * Min / Max weight containers
         * Min / Max weight ship
         * Check requirements
         * Getters
         * Magic Number Maxtopweight
         * Private / public getter setter 
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
                

            };
            ContainerCrane.Sort(ship, containers);
            
            
            Console.WriteLine(ship);
        }
    }
}