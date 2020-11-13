using System;
using System.Collections.Generic;
using System.Linq;

namespace ContainerVervoer
{
    public class Stack
    {
        private readonly List<Container> _containers;

        public Stack()
        {
            _containers = new List<Container>();
        }

        public int GetSize()
        {
            return _containers.Count;
        }
        
        public int GetTopWeight()
        {
            if (!_containers.Any()) return 0;
            return GetWeight() - _containers.First().Weight;
        }

        public int GetWeight()
        {
            return _containers.Sum(x => x.Weight);
        }
        
        public string GetTypesString()
        {
            return string.Join('-',_containers.Select(x => ((int) x.Type).ToString()));
        }
        
        public string GetWeightsString()
        {
            return string.Join('-',_containers.Select(x => x.Weight.ToString()));
        }

        public bool HasValuable()
        {
            return _containers.Any(c => c.Type == ContainerType.Valuable);
        }

        public void Add(Container container)
        {
            _containers.Add(container);
        }
    }
}