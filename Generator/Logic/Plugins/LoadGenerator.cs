using System;
using System.IO;
using System.Reflection;

namespace Generator.Plugins
{
    public class LoadGenerator
    {
        private readonly string _dllLibrary;
        private Assembly _assembly;

        public LoadGenerator(string library)
        {
            _dllLibrary = library;
        }
        
        public void PluginLoad()
        {
            string aboutLibName = @"C:\Users\dauks\source\repos\Spp_Lab2_faker\Generator\" + _dllLibrary;
            if (!File.Exists(aboutLibName))
            {
                throw new IOException("No plugin file");
            }
            _assembly = Assembly.LoadFrom(aboutLibName);
            foreach (Type type in _assembly.GetExportedTypes())
            {
                if (type.IsClass && typeof(IGenerator).IsAssignableFrom(type))
                {
                    IGenerator plugin = (IGenerator)Activator.CreateInstance(type);
                    plugin.GenerateRandomValue();
                }
            }
            
        }
    }
}