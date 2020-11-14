using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ContainerVervoer
{
    public class Ship
    {
        public int MaxWeight { get; }
        public int MinWeight => MaxWeight / 2;
        public int Width { get; }
        public int Length { get; }
        
        private readonly Column[] _columns;
        public readonly ReadOnlyCollection<Column> Columns;

        public Ship(int maxWeight, int width, int length)
        {
            MaxWeight = maxWeight;
            Width = width;
            Length = length;
            _columns = new Column[width];
            PopulateShip(width, length);
            Columns = new ReadOnlyCollection<Column>(_columns);
        }

        public override string ToString()
        {
            return $"length={Length}&width={Width}&stacks={GetTypesString()}&weights={GetWeightsString()}";
        }

        public bool IsBalanced()
        {
            if ((double) GetRightSideWeight() / GetLeftSideWeight() > 1.5) //TODO magic number
                return false;
            return !((double) GetLeftSideWeight() / GetRightSideWeight() > 1.5);
        }
        
        public int GetLeftSideWeight()
        {
            int weight = 0;
            int max = Convert.ToInt32(Math.Floor(Width / 2.0));
            for (int i = 0; i < max; i++)
            {
                weight += _columns[i].Weight;
            }
            return weight;
        }

        public int GetRightSideWeight()
        {
            int weight = 0;
            int min = Convert.ToInt32(Math.Ceiling(Width / 2.0));
            for (int i = min; i < Width; i++)
            {
                weight += _columns[i].Weight;
            }
            return weight;
        }
        
        private void PopulateShip(int width, int length)
        {
            for (int i = 0; i < width; i++)
            {
                _columns[i] = new Column(length);
            }
        }

        private string GetTypesString()
        {
            return string.Join('/',_columns.Select(x => x.GetTypesString()));
        }
        
        private string GetWeightsString()
        {
            return string.Join('/',_columns.Select(x => x.GetWeightsString()));
        }
    }
}