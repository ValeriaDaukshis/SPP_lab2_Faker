using System;
using System.Collections;
using System.Collections.Generic;
using Plugin;

namespace Generator.Generators
{
    public class ValueGenerators
    {
        public object Generator(Type type, IGenerator generator)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IList<>))
            {
                var b = type.GetGenericArguments()[0];
                object list = Activator.CreateInstance(typeof(List<>).MakeGenericType(b));

                return Generics(list, b, 2);
            }

            return generator?.GenerateRandomValue();
        }

        private object Generics(object list,Type b, int count)
        {
            if (count == 0)
                return list;
            ((IList)list).Add(new ValueGenerators().Generator(b, new Faker.Faker().GetTypeGenerator(b)));
            return Generics(list, b, --count);
        }
    }
}