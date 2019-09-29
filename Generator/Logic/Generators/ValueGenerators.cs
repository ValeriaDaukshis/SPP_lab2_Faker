using System;
using System.Collections.Generic;
using Generator.Plugins;

namespace Generator.Generators
{
    public class ValueGenerators
    {
        
        public object Generator(Type type)
        {
            object a = 0;
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IList<>))
            {
                object list = Activator.CreateInstance(typeof(List<>).MakeGenericType(type)); 
               
                //return ((IList)list).Add(ValueGenerators.Generator(type));
                
            }
            else if (type == typeof(DateTime))
            {
                DateTimeGenerator.DateTimeGenerator f = new global::DateTimeGenerator.DateTimeGenerator();
                return f.GenerateRandomValue();
            }
            else if (type == typeof(double))
            {
            }
            else if (type == typeof(String))
            {
               
            }

            return a;
        }
    }
}