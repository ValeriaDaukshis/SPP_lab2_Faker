using System.Linq;
using Generator.Faker;
using Generator.Generators;
using Generator.TestClasses;
using NUnit.Framework;

namespace Generator.Tests
{

    [TestFixture]
    public class Tests
    {
        private TestClass2 _test2;
        private TestClass1 _test1;

        private void SetUp()
        {
            _test2 = new Faker.Faker(new DictionaryOfGenerators()).Create<TestClass2>();
            _test1 = new Faker.Faker(new DictionaryOfGenerators()).Create<TestClass1>();
        }

        [Test]
        public void Faker_CompareFieldsWithDefaultValues()
        {
            SetUp();
            Assert.AreNotEqual(_test1.str, null);
            Assert.AreNotEqual(_test2.str, null);
            Assert.AreNotEqual(_test1.List, null);
            Assert.AreNotEqual(_test1.date, null);
            Assert.AreNotEqual(_test1.doubleNumber, 0.0);
            Assert.AreNotEqual(_test2.doubleNumber, 0.0);
        }

        [Test]
        public void Faker_CompareHashCodes()
        {
            SetUp();
            Assert.AreNotEqual(_test1.GetHashCode(), _test2.GetHashCode()); 
            Assert.AreEqual(_test1.GetHashCode(), _test1.GetHashCode()); 
            Assert.AreEqual(_test2.GetHashCode(), _test2.GetHashCode()); 
        }
        
        [Test]
        public void Faker_TestFieldsWithNoGenerators()
        {
            SetUp();
            Assert.AreEqual(_test1.byteNumber, 0);
            Assert.AreEqual(_test1.charValue, '\u0000');
        }
        
        [Test]
        public void Faker_CheckList()
        {
            SetUp();
            Assert.AreNotEqual(_test1.List.Count, 0);
        }
        [Test]
        public void Faker_TestClassWithPrivateConstructor()
        {
            var faker = new Faker.Faker(new DictionaryOfGenerators());
            var privateCtor = faker.Create<TestClass3>();
            Assert.Null(privateCtor);
        }
        
        [Test]
        public void Faker_TestClassWithFakerConfig()
        {
            DictionaryOfGenerators dict = new DictionaryOfGenerators();
            var config = new FakerConfig(dict);
            
            config.Add<TestClass1, string, StringConfigGenerator>(TestClass1 => TestClass1.str );
            Faker.Faker faker = new Faker.Faker(dict);
            TestClass1 obj = faker.Create<TestClass1>();
            var a = from b in obj.str
                where b >= '0' && b <= '9'
                select b;
            Assert.AreEqual(0, a.Count());
        }
        
        [Test]
        public void FakerConfig_TestNumberOfSmallLetters()
        {
            DictionaryOfGenerators dict = new DictionaryOfGenerators();
            var config = new FakerConfig(dict);
            
            config.Add<TestClass1, string, StringConfigGenerator>(TestClass1 => TestClass1.str );
            Faker.Faker faker = new Faker.Faker(dict);
            TestClass1 obj = faker.Create<TestClass1>();
            var a = from b in obj.str.ToLower()
                where b >= 'a' && b <= 'z'
                select b;
            Assert.AreEqual(obj.str.Length, a.Count());
        }

        [Test]
        public void Faker_TestRecursion()
        {
            Faker.Faker faker4 = new Faker.Faker(new DictionaryOfGenerators());
            TestClass4 test4 = faker4.Create<TestClass4>();
            Assert.AreNotEqual(null, test4.testClass5);
        }
    }
}