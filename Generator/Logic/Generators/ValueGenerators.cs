using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection; 

namespace Generator.Generators
{
    public static class ValueGenerators
    {
        public static object Generator(Type type)
        {
            object a = 0;
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IList<>))
            {
                object list = Activator.CreateInstance(typeof(List<>).MakeGenericType(type)); 
               
                return ((IList)list).Add(ValueGenerators.Generator(type));
                
            }
            else if (type == typeof(DateTime))
            {
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