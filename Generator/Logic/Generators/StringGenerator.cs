﻿using System;
using System.Text;
using Plugin;

namespace Generator.Generators
{
    public class StringGenerator : Plugin.IGenerator
    {
        public string symbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
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