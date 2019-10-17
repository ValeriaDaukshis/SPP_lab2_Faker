

namespace Generator.Generators
{
    public class ValueGenerators
    {
//        public object Generator(Type type, Plugin.IGenerator generator, int count)
//        {
//            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IList<>))
//            {
//                var b = type.GetGenericArguments()[0];
//                object list = Activator.CreateInstance(typeof(List<>).MakeGenericType(b));
//
//                return Generics(list, b, new Random().Next(2, 10));
//            }
//
//            if (type.IsClass && generator == null)
//            {
//                var classObj = Activator.CreateInstance(type);
//                return RecursiveGenerator(classObj, type, count);
//            }
//            return generator?.GenerateRandomValue();
//        }
//        
//        private object Generics(object list,Type b, int count)
//        {
//            if (count == 0)
//                return list;
//            --count;
//            ((IList)list).Add(new ValueGenerators().Generator(b, new Faker.Faker(new DictionaryOfGenerators()).GetTypeGenerator(b, null), count));
//            return Generics(list, b, count);
//        }
//
//        private object RecursiveGenerator(object classObj, Type type, int count)
//        {
//            if (count == 0)
//                return classObj;
//            --count;
//            
//            var generator = new Faker.Faker(new DictionaryOfGenerators()).GetTypeGenerator(type, null);
//            classObj = new ValueGenerators().Generator(type, generator, count);
//            
//            return RecursiveGenerator(classObj, type,  count);
//        }
    }
}