using System;
using System.Collections.Generic;
using Plugin;

namespace Generator.Generators
{
    public class DictionaryOfGenerators
    {
        public Dictionary<Type, IGenerator> dictionary = new Dictionary<Type, IGenerator>()
            {
                { typeof(int), new Int32Generator()},
                { typeof(double), new DoubleGenerator()},
                { typeof(string), new StringGenerator()},
                { typeof(IList<>), null}
            };

        public Dictionary<Type, Tuple<string, IGenerator>> configDictionary;
    }
}