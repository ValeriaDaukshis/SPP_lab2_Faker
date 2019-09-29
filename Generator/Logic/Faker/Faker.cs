using System;
using System.Collections.Generic;
using System.Reflection;
using Generator.Generators;

namespace Generator.Faker
{
    public class Faker : IFaker
    {
        private object _obj;
        public T Create<T>()
        {
            Type type = typeof(T);
            int maxValues = 0;
            ConstructorInfo constructor = GenerateByConstructor(type, ref maxValues);
            if (maxValues == 0)
            {
                _obj = Activator.CreateInstance(type);
                GenerateByFields(type, _obj);
            }
            return (T)_obj;
        }

        private static ConstructorInfo GenerateByConstructor(Type type, ref int maxValues)
        {
            ConstructorInfo[] constructors = type.GetConstructors();
            ConstructorInfo constructor = null;
            foreach (ConstructorInfo c in constructors)
            {
                if (c.GetParameters().Length > maxValues)
                {
                    constructor = c;
                }
            } 
            return constructor;
        }

        private static void GenerateByFields(Type type, object obj)
        {
            FieldInfo[] fields = type.GetFields();
            foreach (FieldInfo info in fields)
            {
                var thisType = info.FieldType;
                object value = ValueGenerators.Generator(thisType);
                info.SetValue(obj, value); 
            }
        }
    }
}