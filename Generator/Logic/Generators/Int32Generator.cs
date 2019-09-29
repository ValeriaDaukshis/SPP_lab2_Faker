using System;
using Generator.Plugins;

namespace Generator.Generators
{
    public class Int32Generator : IGenerator
    {
        public object GenerateRandomValue()
        {
            Random rand = new Random();
            return rand.Next(Int32.MinValue, Int32.MaxValue);
        }
    }
}