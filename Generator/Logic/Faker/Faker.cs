using System;
using System.Collections.Generic;
using System.Reflection;
using Generator.Generators;
using Generator.Plugins;

namespace Generator.Faker
{
    public class Faker : IFaker
    {
        private object _obj;
        private LoadGenerator dateTime;
        private LoadGenerator floatGenerator;
        public T Create<T>()
        {
            LoadPlugins();
            Type type = typeof(T);
            int maxValues = -1;
            ConstructorInfo constructor = GetConstructorsInfo(type, ref maxValues);
            if (maxValues == 0)
            {
                _obj = Activator.CreateInstance(type);
                GenerateByFields(type, _obj);
            }
            return (T)_obj;
        }

        private void LoadPlugins()
        {
            dateTime = new LoadGenerator("DateTimeGenerator.dll");
            dateTime.PluginLoad();
            
            floatGenerator = new LoadGenerator("FloatGenerator.dll");
            floatGenerator.PluginLoad(); 
        }

        private static ConstructorInfo GetConstructorsInfo(Type type, ref int maxValues)
        {
            ConstructorInfo[] constructors = type.GetConstructors();
            ConstructorInfo constructor = null;
            foreach (ConstructorInfo c in constructors)
            {
                if (c.GetParameters().Length > maxValues)
                {
                    constructor = c;
                    maxValues = c.GetParameters().Length;
                }
            } 
            return constructor;
        }

        private static void GenerateByConstructor(ConstructorInfo constructor)
        {
            
        }

        private void GenerateByFields(Type type, object obj)
        {
            FieldInfo[] fields = type.GetFields();
            ValueGenerators generators = new ValueGenerators();
            foreach (FieldInfo info in fields)
            {
                var thisType = info.FieldType;
                object value = generators.Generator(thisType);
                info.SetValue(obj, value); 
            }
        }
    }
}