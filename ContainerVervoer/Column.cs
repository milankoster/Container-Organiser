using System;
using System.Collections.Generic;
using System.Linq;

namespace ContainerVervoer
{
    public class Column
    {
        public readonly Stack[] Stacks; //ToDo Readonly collection? 
        public int Weight => Stacks.Sum(x => x.Weight);
        
        public Column(int length)
        {
            Stacks = new Stack[length];
            PopulateColumns(length);
        }

        public Column(Stack[] stacks)
        {
            Stacks = stacks;
        }

        private void PopulateColumns(int length)
        {
            for (int i = 0; i < length; i++)
            {
                Stacks[i] = new Stack();
            }
        }

        public string GetTypesString()
        {
            return string.Join(',', Stacks.Select(x => x.GetTypesString()));
        }
        
        public string GetWeightsString()
        {
            return string.Join(',', Stacks.Select(x => x.GetWeightsString()));
        }
    }
}