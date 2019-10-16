using System;

namespace Generator.TestClasses
{
    public class TestClass2
    { 
        public DateTime date;
        public string str;
        public double doubleNumber;

        public TestClass2(DateTime date, string str, double doubleNumber)
        {
            this.date = date;
            this.str = str;
            this.doubleNumber = doubleNumber;
        }
        
        public TestClass2(){}
    }
}