using System;
using Generator.Faker;
using Generator.Generators;
using Generator.TestClasses;

namespace EnterPoint
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
//            DictionaryOfGenerators dict = new DictionaryOfGenerators();
//            var config = new FakerConfig(dict);
//            
//            config.Add<TestClass1, string, StringConfigGenerator>(TestClass1 => TestClass1.str );
//            Faker faker = new Faker(dict);
//            TestClass1 obj = faker.Create<TestClass1>();
//            
//            if(obj != null)
//                new ConsoleWriter().GetClassFields<TestClass1>(obj);
            
//            Faker faker2 = new Faker(new DictionaryOfGenerators());
//            TestClass2 test2 = faker2.Create<TestClass2>();
//            if(test2 != null)
//                new ConsoleWriter().GetClassFields<TestClass2>(test2);

            Faker faker4 = new Faker(new DictionaryOfGenerators());
            TestClass4 test4 = faker4.Create<TestClass4>();
            if(test4 != null)
                new ConsoleWriter().GetClassFields<TestClass4>(test4);
        }
    }
}