using System;
using System.Reflection;

namespace Generator
{
    public class Faker 
    { 
        public T Create<T>()
        {
            Type type = typeof(T);
            FieldInfo[] fields = type.GetFields();
            Object o = Activator.CreateInstance(type);  
            for (int i = 0; i < fields.Length; i++)
            {
                //var thisName = fields[i].Name;
                var thisType = fields[i].FieldType;
                object value = ValueGenerators.GetType(thisType, 0);
                fields[i].SetValue(o, value);
            }
            return (T)o;
        }
    }
}