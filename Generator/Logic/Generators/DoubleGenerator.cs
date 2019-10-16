using System;

namespace Generator.Generators
{
    public class DoubleGenerator : Plugin.IGenerator
    {
        private double MaxValue = Double.MaxValue;
        public object GenerateRandomValue()
        {
            Random rand = new Random();
            return (double)rand.Next(Int32.MinValue, (int)MaxValue);
        }
    }
}