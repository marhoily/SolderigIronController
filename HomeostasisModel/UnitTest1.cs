using System;
using System.Collections.Generic;
using Xunit;

namespace HomeostasisModel
{
    public enum Choice{Heat, Wait}
    public sealed class Controller
    {
        public double TargetTemp { get; set; }
        public sealed class Slice
        {
            // K/second of heat transferred between the tip and the environment
            public double HeatLossSpeed { get; set; }
            public double AmbientTemp { get; set; }
            public double TipTemp { get; set; }
            public double PredictedSensorTemp { get; set; }
            public double ActualSensorTemp { get; set; }
        }

        // First element is a second ago, the last one is now.
        private readonly LinkedList<Slice> _history = new LinkedList<Slice>();


        public Choice Step(double sensorValue)
        {
            // Init
            if (_history.Count == 0)
                for (var i = 0; i < 10; i++)
                    _history.AddLast(new Slice
                    {
                        HeatLossSpeed = 1, // Assume we were in the air
                        AmbientTemp = sensorValue, // Assume we were in the air
                        TipTemp = sensorValue, // Assume the tip was in eq with the air
                        PredictedSensorTemp = sensorValue, // Assume the tip was in eq with the tip
                        ActualSensorTemp = sensorValue, // Assume the tip was in eq with the tip
                    });
            // trying to construct a fresh slice
            var now = new Slice
            {
                PredictedSensorTemp = 
                ActualSensorTemp = sensorValue, // Assume the tip was in eq with the tip
                HeatLossSpeed = 1, // Assume we were in the air
                AmbientTemp = sensorValue, // Assume we were in the air
                TipTemp = sensorValue, // Assume the tip was in eq with the air
            };
        }
    }
    public sealed class World
    {
        public sealed class Slice
        {
            // K/second of heat transferred between the tip and the environment
            public double HeatLossSpeed { get; set; }
            public double AmbientTemp { get; set; }
            public double TipTemp { get; set; }
            public double SensorTemp { get; set; }
        }

        public World()
        {
            _series.AddFirst(new Slice
            {
                HeatLossSpeed = 1, // Air
                AmbientTemp = 22, // Room temperature,
                SensorTemp = 22,
                TipTemp = 22,
            });
        }

        // First element is a second ago, the last one is now.
        private readonly LinkedList<Slice> _series = new LinkedList<Slice>();

        public Slice Step(double heatLossSpeed)
        {

        }

    }
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }
    }
}
