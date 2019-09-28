using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Generator
{
    public static class ValueGenerators
    {
        public static object GetType(Type type, int count)
        {
            object a = 0;
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IList<>))
            {
                object list = Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
                //count = 2; 
                if(count == 2)
                    return list;
               
                return ((IList)list).Add(ValueGenerators.GetType(type, ++count));
                
            }
            else if (type == typeof(DateTime))
            {
                a = DateTime.Now;
            }
            else if (type.IsValueType)
            {
                a = GenerateRandomValueType(type);
            }
            else if (type == typeof(String))
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

            return a;
        }

        private static ValueType GenerateRandomValueType(Type type)
        {
            Random rand = new Random();
            if (type == typeof(int))
            {
                return rand.Next(10, 1000);
            }

            if (type == typeof(double))
            {
                return rand.Next();
            }
            
            if (type == typeof(float))
            {
                return rand.Next();
            }

            return 0;
        }
    }
}