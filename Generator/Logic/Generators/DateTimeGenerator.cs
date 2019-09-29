using System;

namespace Generator.Generators
{
    public class DateTimeGenerator : IGenerator
    {
        public object GenerateRandomValue()
        {
            return DateTime.Now;
        }
    }
}