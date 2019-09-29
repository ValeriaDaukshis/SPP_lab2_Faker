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
        private LoadGenerator _dateTime;
        private LoadGenerator _floatGenerator;
        public T Create<T>()
        {
            LoadPlugins();
            Type type = typeof(T);
            int maxValues = -1;
            ConstructorInfo constructor = GetConstructorsInfo(type, ref maxValues);
            _obj = Activator.CreateInstance(type);
            if (maxValues == 0)
            {
                GenerateByFields(type, _obj);
            }
            else
            {
                GenerateByConstructor(constructor, _obj);
            }
            return (T)_obj;
        }

        private void LoadPlugins()
        {
            _dateTime = new LoadGenerator("DateTimeGenerator.dll");
            _dateTime.PluginLoad();
            
            _floatGenerator = new LoadGenerator("FloatGenerator.dll");
            _floatGenerator.PluginLoad(); 
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

        private void GenerateByConstructor(ConstructorInfo constructor, object obj)
        {
            ParameterInfo[] info = constructor.GetParameters();
            ValueGenerators generators = new ValueGenerators();
            object[] values = new object[info.Length];
            for (int i=0; i < info.Length; i++)
            {
                var thisType = info[i].ParameterType;
                values[i] = generators.Generator(thisType);
                
            }
            constructor.Invoke(values);
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