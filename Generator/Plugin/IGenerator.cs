using System;

namespace Plugin
{
    public interface IGenerator
    {
//        Type SupportedType { get; }
        object GenerateRandomValue();
    }
}