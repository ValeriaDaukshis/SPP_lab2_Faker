using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Generator.Generators;
using Plugin;

namespace Generator.Faker
{
    public class FakerConfig
    {
        private Dictionary<Type, Tuple<string, IGenerator>> dictionary;
        private readonly DictionaryOfGenerators _generator;
        public FakerConfig(DictionaryOfGenerators dictionaryOfGenerators)
        {
            _generator = dictionaryOfGenerators;
            dictionary = new Dictionary<Type, Tuple<string, IGenerator>>();
        }
        
        public void Add<TClass, TType, TGenerator>(Expression<Func<TClass, TType>> expression)
        {
            var generator = (IGenerator)Activator.CreateInstance<TGenerator>();

            var body = (MemberExpression)expression.Body;
            var memberInfo = body.Member;                                                                    
            dictionary.Add(body.Type, new Tuple<string, IGenerator>(memberInfo.Name, generator));
            _generator.configDictionary = dictionary;
        }
    }
}