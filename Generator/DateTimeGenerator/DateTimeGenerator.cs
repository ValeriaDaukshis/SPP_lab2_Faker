using System;
using Generator.Generators;
using Generator.Plugins;

namespace DateTimeGenerator
{
    public class DateTimeGenerator 
    {
        public object GenerateRandomValue()
        {
            return DateTime.Now;
        }
    }
}