﻿using System;
using System.Collections.Generic;

namespace ContainerVervoer
{
    class Program
    {
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