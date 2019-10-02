﻿using System;
using Generator.Faker;
using Generator.Generators;
using Generator.TestClasses;

namespace EnterPoint
{
    internal class main
    {
        public static void Main(string[] args)
        {
            Faker faker = new Faker(new GeneratorsDictionary());
            TestClass1 obj = faker.Create<TestClass1>();
            new ConsoleWriter().GetClassFields<TestClass1>(obj);
            
            Faker faker2 = new Faker(new GeneratorsDictionary());
            TestClass2 test2 = faker2.Create<TestClass2>();
            new ConsoleWriter().GetClassFields<TestClass2>(test2);
        }
    }
}