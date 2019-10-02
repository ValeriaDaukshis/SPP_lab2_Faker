using System;
using System.Collections.Generic;
using Plugin;

namespace Generator.Generators
{
    public interface IDictionary
    {
         Dictionary<Type, IGenerator> GeneratorDictionary();
    }
}