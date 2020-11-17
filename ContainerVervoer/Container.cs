using System;
using System.Collections.Specialized;
using System.Configuration;
using ContainerVervoer.Exceptions;

namespace ContainerVervoer
{
    public class Container
    {
        public int Weight { get; }
        public ContainerType Type { get; }
        public Container(int weight, ContainerType type)
        {
            Weight = weight;
            Type = type;
        }
    }
}