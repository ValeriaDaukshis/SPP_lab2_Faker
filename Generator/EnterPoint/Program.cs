using System;
using Generator;

namespace EnterPoint
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Faker faker = new Faker();
            TestClass1 obj = faker.Create<TestClass1>();
            Console.WriteLine(obj.str);
            Console.WriteLine(obj.number);
            Console.WriteLine(obj.doubleNumber);
            Console.WriteLine(obj.floatNumber);
            Console.WriteLine(obj.date);
        }
    }
}