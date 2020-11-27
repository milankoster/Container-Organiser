namespace ContainerVervoer.Tests
{
    public class Config : IConfiguration
    {
        public double ShipBalance { get; set; }
        public int ContainerBaseWeight { get; set; }
        public int ContainerMaxWeight { get; set; }
        public int ContainerTopWeight { get; set; }

        public Config()
        {
            ShipBalance = 1.5;
            ContainerBaseWeight = 1000;
            ContainerMaxWeight = 10000;
            ContainerTopWeight = 40000;    
        }
    }
}