using System;
using Generator.Plugins;

namespace Generator.Generators
{
    public class GenericGenerator : IGenerator
    {
        public object GenerateRandomValue()
        {
            Random rand = new Random();
            int count = rand.Next(2, 10);
            throw new System.NotImplementedException();
        }
    }
}