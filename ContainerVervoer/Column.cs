using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ContainerVervoer
{
    public class Column
    {
        private readonly Stack[] _stacks;
        public readonly ReadOnlyCollection<Stack> Stacks;
        public int Weight => _stacks.Sum(x => x.Weight);
        
        public Column(int length)
        {
            _stacks = new Stack[length];
            PopulateColumns(length);
            Stacks = new ReadOnlyCollection<Stack>(_stacks);
        }

        public Column(Stack[] stacks)
        {
            _stacks = stacks;
            Stacks = new ReadOnlyCollection<Stack>(_stacks);
        }

        private void PopulateColumns(int length)
        {
            for (int i = 0; i < length; i++)
            {
                _stacks[i] = new Stack();
            }
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