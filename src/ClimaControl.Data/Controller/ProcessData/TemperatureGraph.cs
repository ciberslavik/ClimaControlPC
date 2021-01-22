using System.Collections.Generic;

namespace ClimaControl.Data.Controller.ProcessData
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