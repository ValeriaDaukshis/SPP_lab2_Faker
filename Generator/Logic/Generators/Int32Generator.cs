using System;
using Plugin;

namespace Generator.Generators
{
    public class Int32Generator : IGenerator
    {
        private int maxValue = Int32.MaxValue ;
        public object GenerateRandomValue()
        {
            Random rand = new Random();
            return rand.Next(Int32.MinValue, maxValue);
        }
    }
}