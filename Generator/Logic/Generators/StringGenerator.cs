using System;
using System.Text;

namespace Generator.Generators
{
    public class StringGenerator : IGenerator
    {
        public object GenerateRandomValue()
        {
            Random random = new Random();
            int length = random.Next(1, 20);
            string symbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
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