using System.Collections.Generic;
using System.Linq;

namespace ContainerVervoer
{
    public class Stack
    {
        private readonly List<Container> _containers;
        public int Size => _containers.Count;
        public int Weight => _containers.Sum(x => x.Weight);
        
        public Stack()
        {
            _containers = new List<Container>();
        }

        public int GetTopWeight()
        {
            if (!_containers.Any()) return 0;
            return Weight - _containers.First().Weight;
        }

        public string GetTypesString()
        {
            return string.Join('-',_containers.Select(x => ((int) x.Type).ToString()));
        }
        
        public string GetWeightsString()
        {
            return string.Join('-',_containers.Select(x => x.Weight.ToString()));
        }

        public bool ContainsValuableContainer()
        {
            return _containers.Any(c => c.Type == ContainerType.Valuable) || _containers.Any(c => c.Type == ContainerType.VaCo);
        }

        public void Add(Container container)
        {
            if (!ContainsValuableContainer())
                _containers.Add(container);
            else 
                _containers.Insert(_containers.Count - 1, container);
        }
    }
}