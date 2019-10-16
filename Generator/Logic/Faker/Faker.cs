using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Generator.Generators;
using Plugin;

namespace Generator.Faker
{
    public class Faker : IFaker
    {
        private object _obj;
        private readonly DictionaryOfGenerators _generator;
        HashSet<object> members = new HashSet<object>();

        public Faker(DictionaryOfGenerators generator)
        {
            _generator = generator;
        }
        public T Create<T>() 
        {
            LoadPlugins();
            Type type = typeof(T);
            ConstructorInfo constructor = GetConstructorsInfo(type);
            if (constructor == null)
            {
                _obj = null;
                return (T)_obj;
            }
            if (constructor.GetParameters().Length == 0)
            {
                _obj = Activator.CreateInstance(type);
                GenerateByFields(type, _obj);
            }
            else
                _obj = GenerateByConstructor(constructor);
            
            return (T)_obj;
        }

        private void LoadPlugins()
        {
            string pluginPath = @"C:\Users\dauks\source\repos\Spp_Lab2_faker\Generator\Plugins\";
            DirectoryInfo pluginDirectory = new DirectoryInfo(pluginPath);
            if (!pluginDirectory.Exists)
                throw new IOException();
            
            var pluginFiles = Directory.GetFiles(pluginPath, "*.dll");
            foreach (var file in pluginFiles)
            {
                Assembly assembly = Assembly.LoadFrom(file);
                foreach (Type type in assembly.GetExportedTypes())
                {
                    if (type.IsClass && typeof(IGenerator).IsAssignableFrom(type))
                    {
                        var plugin = assembly.CreateInstance(type.FullName ?? throw new Exception("Error is plugin loading")) as IGenerator;
                        FieldInfo fieldType = type.GetFields(BindingFlags.NonPublic | 
                                                       BindingFlags.Instance)[0];
//                        plugin.SupportedType
                        _generator.dictionary.Add(fieldType.FieldType, plugin);
                    }
                }
            }
        }

        private ConstructorInfo GetConstructorsInfo(Type type)
        {
            int maxValues = -1;
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

        private object GenerateByConstructor(ConstructorInfo constructor)
        {
            ParameterInfo[] info = constructor.GetParameters();
            ValueGenerators generators = new ValueGenerators();
            object[] values = new object[info.Length];
            for (int i=0; i < info.Length; i++)
            {
                var thisType = info[i].ParameterType;
                values[i] = generators.Generator(thisType, GetTypeGenerator(thisType, info[i].Name), 2); 
            }
            return constructor.Invoke(values);
        }

        private void GenerateByFields(Type type, object obj)
        {
            FieldInfo[] fields = type.GetFields();
            ValueGenerators generators = new ValueGenerators();
            foreach (FieldInfo info in fields)
            {
                var thisType = info.FieldType;
                object value = generators.Generator(thisType, GetTypeGenerator(thisType, info.Name), 2);
                info.SetValue(obj, value); 
            }
        }

        public IGenerator GetTypeGenerator(Type type, string fieldName)
        {
            Dictionary<Type, Tuple<string, IGenerator>> configDictionary = _generator.configDictionary;
            if (configDictionary != null && configDictionary.ContainsKey(type) )
            {
                if(fieldName == configDictionary[type].Item1)
                    return configDictionary[type].Item2;
            }
            Dictionary<Type, IGenerator> dictionary = _generator.dictionary;
            if (dictionary.ContainsKey(type))
                return dictionary[type];
            return null;
        }
    }
}