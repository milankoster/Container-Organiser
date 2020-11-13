using System;
using System.Collections.Generic;
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

        private string _url = "https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html?";
        
        
        public Ship(int maxWeight, int width, int length)
        {
            MaxWeight = maxWeight;
            Width = width;
            Length = length;
            _columns = new Column[width];
            PopulateShip(width, length);
            Console.WriteLine(GetTypesString());
            Console.WriteLine(GetTypesString());
        }

        public override string ToString()
        {
            return $"{_url}length={Length}&width={Width}&stacks={GetTypesString()}&weights={GetWeightsString()}";
        }

        public Column[] GetColumns()
        {
            return _columns;
        }

        public bool IsBalanced()
        {
            if ((double) GetRightSideWeight() / GetLeftSideWeight() > 1.5)
                return false;
            if ((double) GetLeftSideWeight() / GetRightSideWeight() > 1.5)
                return false;
            return true;
        }
        
        public int GetLeftSideWeight()
        {
            int weight = 0;
            int max = Convert.ToInt16(Math.Floor(Width / 2.0));
            for (int i = 0; i < max; i++)
            {
                weight += _columns[i].GetWeight();
            }
            return weight;
        }

        public int GetRightSideWeight()
        {
            int weight = 0;
            int min = Convert.ToInt16(Math.Ceiling(Width / 2.0));
            for (int i = min; i < Width; i++)
            {
                weight += _columns[i].GetWeight();
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