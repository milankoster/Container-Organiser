using System;
using System.Collections.Generic;
using System.Linq;

namespace ContainerVervoer
{
    public class Column
    {
        private readonly Stack[] _stacks;

        public Column(int length)
        {
            _stacks = new Stack[length];
            PopulateColumns(length);
        }

        public Column(Stack[] stacks)
        {
            _stacks = stacks;
        }

        public int GetWeight() //Todo change to getter property 
        {
            return _stacks.Sum(x => x.GetWeight());
        }
        
        private void PopulateColumns(int length)
        {
            for (int i = 0; i < length; i++)
            {
                _stacks[i] = new Stack();
            }
        }

        public Stack[] GetStacks()
        {
            return _stacks;
        }

        public string GetTypesString()
        {
            return string.Join(',', _stacks.Select(x => x.GetTypesString()));
        }
        
        public string GetWeightsString()
        {
            return string.Join(',', _stacks.Select(x => x.GetWeightsString()));
        }
    }
}