using System;
using System.Collections.Generic;
using Plugin;

namespace Generator.Generators
{
    public class GeneratorsDictionary : IDictionary
    {
        public Dictionary<Type, IGenerator> GeneratorDictionary()
        {
            Dictionary<Type, IGenerator> generator = new Dictionary<Type, IGenerator>()
            {
                { typeof(int), new Int32Generator()},
                { typeof(double), new DoubleGenerator()},
                { typeof(string), new StringGenerator()},
                { typeof(IList<>), null},
                { typeof(DateTime), new global::DateTimeGenerator.DateTimeGenerator()},
                { typeof(float), new global::FloatGenerator.FloatGenerator()},
            };
            return generator;
        }
    }
}