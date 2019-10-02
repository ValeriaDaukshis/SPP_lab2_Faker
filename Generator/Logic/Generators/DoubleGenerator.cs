using System;
using Plugin;

namespace Generator.Generators
{
    public class DoubleGenerator : IGenerator
    {
        public object GenerateRandomValue()
        {
            Random rand = new Random();
            return (double)rand.Next(Int32.MinValue, Int32.MaxValue);
        }
    }
}