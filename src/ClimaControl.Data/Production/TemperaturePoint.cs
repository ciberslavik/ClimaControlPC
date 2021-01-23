namespace ClimaControl.Data.Production
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