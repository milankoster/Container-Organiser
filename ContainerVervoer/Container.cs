﻿using System.ComponentModel;

namespace ContainerVervoer
{
    public class Container
    {
        public int MaxWeight { get; set; }
        public int MinWeight { get; }
        public int MaxTopWeight { get; }
        public int Weight;
        public ContainerType Type { get; }
        public Container(int weight, ContainerType type)
        {
            MaxWeight = 30000;
            MinWeight = 4000;
            MaxTopWeight = 120000;
            Weight = weight;
            Type = type;
        }
    }
}