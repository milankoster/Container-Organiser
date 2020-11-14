using System.Diagnostics;
using System.Linq;

namespace ContainerVervoer
{
    public static class ShipVisualiser
    {
        private const string Url = "https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html?";

        private static string GetUrl(Ship ship)
        {
            return Url + ship;
        }
        
        public static void OpenInChrome(Ship ship)
        {
            var processes = Process.GetProcessesByName("Chrome");
            var path  = processes.FirstOrDefault()?.MainModule?.FileName;
            Process.Start(path,  GetUrl(ship));
        }
    }
}