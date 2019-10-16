using System;
using System.Collections.Generic;

namespace Generator.Generators
{
    public interface IDictionaryGenerator
    {
        Dictionary<Type, Plugin.IGenerator> dictionary { get;}
    }
}