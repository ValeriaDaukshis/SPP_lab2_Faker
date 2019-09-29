﻿using System;
using Plugin;

namespace Generator.Generators
{
    public class DoubleGenerator : IGenerator
    {
        public object GenerateRandomValue()
        {
            Random rand = new Random();
            return (Double)rand.Next(1, 1000);
        }
    }
}