using System;
using System.Collections.Generic;

namespace Generator.TestClasses
{
    public class TestClass1
    {
        //public IList<int> List;
        public string str;
        //public int number;
        public double doubleNumber;
        public float floatNumber; 
        public DateTime date;

        public TestClass1(string str, double number)
        {
            this.str = str;
            doubleNumber = number;
        }
        public TestClass1(){}

    }
}