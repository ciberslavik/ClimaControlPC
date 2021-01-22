using System;

namespace ClimaControl.Data.Controller.ProcessData
{
    public class TemperaturePoint:ObservableObject
    {
        public TemperaturePoint()
        {
        }
        public double Temperature { get; set; }
        public int Day { get; set; }

    }
}