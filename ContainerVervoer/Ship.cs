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
        
        public readonly Column[] Columns; //TODO Readonly array?
        

        public Ship(int maxWeight, int width, int length)
        {
            MaxWeight = maxWeight;
            Width = width;
            Length = length;
            Columns = new Column[width];
            PopulateShip(width, length);
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
                weight += Columns[i].Weight;
            }
            return weight;
        }

        public int GetRightSideWeight()
        {
            int weight = 0;
            int min = Convert.ToInt32(Math.Ceiling(Width / 2.0));
            for (int i = min; i < Width; i++)
            {
                weight += Columns[i].Weight;
            }
            return weight;
        }
        
        private void PopulateShip(int width, int length)
        {
            for (int i = 0; i < width; i++)
            {
                Columns[i] = new Column(length);
            }
        }

        private string GetTypesString()
        {
            return string.Join('/',Columns.Select(x => x.GetTypesString()));
        }
        
        private string GetWeightsString()
        {
            return string.Join('/',Columns.Select(x => x.GetWeightsString()));
        }
    }
}