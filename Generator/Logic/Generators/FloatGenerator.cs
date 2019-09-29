using System;

namespace Generator.Generators
{
    public class FloatGenerator : IGenerator
    {
        public object GenerateRandomValue()
        {
            Random rand = new Random();
            return (Single)rand.Next(Int32.MinValue, Int32.MaxValue);
        }
    }
}