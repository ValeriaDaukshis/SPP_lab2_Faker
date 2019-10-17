using System;
using System.Collections;
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
        HashSet<Type> members = new HashSet<Type>();
        private readonly Faker f;

        public Faker(DictionaryOfGenerators generator)
        {
            _generator = generator;
            f = this;
        }

        private object Create(Type type)
        {
            if (members.Contains(type))
            {
                return null;
            }
            ConstructorInfo constructor = GetConstructorsInfo(type);
            if (constructor == null)
            {
                _obj = null;
            }
            else if (constructor.GetParameters().Length == 0)
            {
                _obj = Activator.CreateInstance(type);
               
                members.Add(type);
                _obj = GenerateByFields(type, _obj);
            }
            else
            {
                members.Add(type);
                _obj = GenerateByConstructor(constructor);
            }
            return _obj;
        }
        public T Create<T>()
        {
            LoadPlugins();
            return (T)Create(typeof(T));
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
            object[] values = new object[info.Length];
            for (int i=0; i < info.Length; i++)
            {
                var thisType = info[i].ParameterType;
                values[i] = GetTypeGenerator(thisType, info[i].Name); 
            }
            return constructor.Invoke(values);
        }

        private object GenerateByFields(Type type, object obj)
        {
            FieldInfo[] fields = type.GetFields();
            foreach (FieldInfo info in fields)
            {
                var thisType = info.FieldType;
                object value = GetTypeGenerator(thisType, info.Name); // 5
                info.SetValue(obj, value); //testClass5.setValue(obj4,obj5)
            }

            return obj;
        }

        private object GetTypeGenerator(Type type, string fieldName)
        {
            Dictionary<Type, Tuple<string, IGenerator>> configDictionary = _generator.configDictionary;
            if (configDictionary != null && configDictionary.ContainsKey(type) )
            {
                if(fieldName == configDictionary[type].Item1)
                    return configDictionary[type].Item2.GenerateRandomValue();
            }
            Dictionary<Type, IGenerator> dictionary = _generator.dictionary;
            if (dictionary.ContainsKey(type))
                return dictionary[type].GenerateRandomValue();
            
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IList<>))
            {
                var b = type.GetGenericArguments()[0];
                object list = Activator.CreateInstance(typeof(List<>).MakeGenericType(b));

                return Generics(list, b, new Random().Next(2, 10));
            }
            
            if (type.IsClass)
            {
                return f.Create(type);
            }
            return null;
        }
        
        private object Generics(object list,Type b, int count)
        {
            if (count == 0)
                return list;
            --count;
            ((IList)list).Add(f.GetTypeGenerator(b, null));
            return Generics(list, b, count);
        }
    }
}