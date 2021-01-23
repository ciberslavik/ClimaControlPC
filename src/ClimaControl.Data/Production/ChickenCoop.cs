using System;
using System.Collections.Generic;

namespace ClimaControl.Data.Production
{
    public class ChickenCoop:ObservableObject
    {
        private DateTime _landingDate;
        private TemperatureGraph _temperatureGraph;

        public DateTime LandingDate
        {
            get => _landingDate;
            set => Update(ref _landingDate, value);
        }

        public TemperatureGraph Graph
        {
            get => _temperatureGraph;
            set => Update(ref _temperatureGraph, value);
        }
    }
}