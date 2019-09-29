using System;
using Generator.Faker;
using Generator.TestClasses;

namespace EnterPoint
{
    internal class main
    {
        public static void Main(string[] args)
        {
            Faker faker = new Faker();
            TestClass1 obj = faker.Create<TestClass1>();
            new ConsoleWriter().GetClassFields<TestClass1>(obj);
            TestClass2 test2 = faker.Create<TestClass2>();
            new ConsoleWriter().GetClassFields<TestClass2>(test2);
        }
    }
}