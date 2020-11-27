namespace ContainerVervoer
{
    public interface IConfiguration
    {
        public double ShipBalance { get; set; }

        public int ContainerBaseWeight { get; set; }

        public int ContainerMaxWeight { get; set; }

        public int ContainerTopWeight { get; set; }
    }
}