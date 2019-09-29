using System;
using Plugin;

namespace DateTimeGenerator
{
    public class DateTimeGenerator : IGenerator
    {
        public object GenerateRandomValue()
        {
            return DateTime.Now;
        }
    }
}