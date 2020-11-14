namespace ContainerVervoer
{
    public class Container
    {
        public int MaxWeight { get; }
        public int MinWeight { get; }
        public int MaxTopWeight { get; } //TODO Current unused due to magic num
        public int Weight { get; }
        public ContainerType Type { get; }
        public Container(int weight, ContainerType type)
        {
            MaxWeight = 30000;
            MinWeight = 4000;
            MaxTopWeight = 0;
            Weight = weight;
            Type = type;
        }
    }
}