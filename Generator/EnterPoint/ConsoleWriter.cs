using System;
using System.Reflection;

namespace EnterPoint
{
    public class ConsoleWriter
    {
        public void GetClassFields<T>(Object obj)
        {
            Type type = typeof(T);
            FieldInfo[] fields = type.GetFields();
            Console.WriteLine("\n{0}", obj);
            foreach (FieldInfo info in fields)
            {
                Console.Write("{0}: {1}\n", info.Name, info.GetValue(obj));
            }
        }
    }
}