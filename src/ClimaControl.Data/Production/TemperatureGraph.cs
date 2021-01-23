using System.Collections.Generic;

namespace ClimaControl.Data.Production
{
    public class TemperatureGraph
    {
        public TemperatureGraph()
        {
            Points=new List<TemperaturePoint>();
        }
        public string GraphName { get; set; }
        public List<TemperaturePoint> Points { get; set; }
    }
}