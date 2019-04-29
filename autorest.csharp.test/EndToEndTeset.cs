using System;
using System.Collections.Generic;
using Agoda.RoundRobin;
using Agoda.Test.Client;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
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
            Console.WriteLine(result);
            Assert.Pass();
        }
    }
}