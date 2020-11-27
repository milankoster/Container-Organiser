namespace ContainerVervoer
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
            ContainerBaseWeight = 4000;
            ContainerMaxWeight = 30000;
            ContainerTopWeight = 120000;
        }
    }
}