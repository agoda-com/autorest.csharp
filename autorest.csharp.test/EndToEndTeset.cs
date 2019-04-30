using System;
using System.Collections.Generic;
using Agoda.RoundRobin;
using Agoda.Test.Client;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Agoda.Test.Client.Models;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestShouldSerializeBasicDataTypes()
        {
            var config = new ApiBaseConfig()
            {
                settings = new List<ServerSettings>()
                {
                    new ServerSettings("http://localhost:8443", 100)
                },
                name = "petstore",
                retryCount = 0,
                timeout = TimeSpan.FromMinutes(1)
            };
            var client = new SwaggerPetstore(config);
            var result = client.GetPetByIdAsync(1).Result;
            List<Tag> expectedTag = new List<Tag>();
            expectedTag.Add(new Tag(2, "Beagle"));
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.Category.Name, "Dog");
            Assert.IsTrue(TagEqual(result.Tags, expectedTag));
        }
        
        
        [Test]
        public void TestShouldSerializeDixtionary()
        {
            var config = new ApiBaseConfig()
            {
                settings = new List<ServerSettings>()
                {
                    new ServerSettings("http://localhost:8443", 100)
                },
                name = "petstore",
                retryCount = 0,
                timeout = TimeSpan.FromMinutes(1)
            };
            var client = new SwaggerPetstore(config);
            var result = client.GetPetByIdAsync(1).Result;
            List<Tag> expectedTag = new List<Tag>();
            expectedTag.Add(new Tag(2, "Beagle"));
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.Category.Name, "Dog");
            Assert.IsTrue(TagEqual(result.Tags, expectedTag));
        }

        class TagComparer : IEqualityComparer<Tag>
        {
            public bool Equals(Tag x, Tag y)
            {
                if (Object.ReferenceEquals(x, y)) return true;
                return x.Id == y.Id && x.Name == y.Name;
            }

            public int GetHashCode(Tag obj)
            {
                return obj.Id.GetHashCode() + obj.Name.GetHashCode();
            }
        }
        private static bool TagEqual(List<Tag> result, List<Tag> expectedTags)
        {
            var firstNotSecond = result.Except(expectedTags, new TagComparer()).ToList();
            var secondNotFirst = expectedTags.Except(result, new TagComparer()).ToList();
            return !firstNotSecond.Any() && !secondNotFirst.Any();
        }
    }
}