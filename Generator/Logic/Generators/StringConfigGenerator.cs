﻿using System;
using System.Text;

namespace Generator.Generators
{
    public class StringConfigGenerator : Plugin.IGenerator
    {
        public string symbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public object GenerateRandomValue()
        {
            Random random = new Random();
            int length = random.Next(5, 20);
            
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                int pos = random.Next(0, symbols.Length);
                result.Append(symbols[pos]);
            }
            return result.ToString();
        }
    }
}