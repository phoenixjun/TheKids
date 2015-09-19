
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;
using Ploeh.AutoFixture;
using TheKids.WebApi.Components;

namespace TheKids.UnitTests.WebApi.Components
{
    [TestFixture]
    public class PartialObjectConverterTests
    {
        private class TestObject
        {
            public int TestObjectId { get; set; }
            public string URI { get; set; }
            public string Something { get; set; }
            public int Integer { get; set; }
            public double Double { get; set; }
            public DateTime Birthday { get; set; }
            public int? NullableInteger { get; set; }
            public double? NullableDouble { get; set; }
            public DateTime? NullableBirthday { get; set; }
            public TestObject2 NestedObject { get; set; }
            public IList<TestObject3> ListObjects { get; set; } 
        }


        private class TestObject2
        {
            public int TestObject2Id { get; set; }
            public string URI { get; set; }
            public string Something { get; set; }
            public int Integer { get; set; }
            public double Double { get; set; }
            public DateTime Birthday { get; set; }
            public int? NullableInteger { get; set; }
            public double? NullableDouble { get; set; }
            public DateTime? NullableBirthday { get; set; }
        }

        private class TestObject3
        {
            public int TestObject3Id { get; set; }
            public string URI { get; set; }
            public string OtherProperty { get; set; }
        }

        [Test]
        public void Should_Include_IdAndUri()
        {
            var response = new Fixture().Create<TestObject>();
            var objectConverter = new PartialObjectConverter();
            var responseObject = objectConverter.ConvertToExpandoObject(response, new ObjectDefinition());
            var responseDict = responseObject as IDictionary<string, object>;
            Assert.AreEqual(2, responseDict.Keys.Count);
            Assert.AreEqual(response.TestObjectId, responseDict["TestObjectId"]);
            Assert.AreEqual(response.URI, responseDict["URI"]);
        }

        [Test]
        public void Should_Include_PropertiesWithinObject()
        {
            var response = new Fixture().Create<TestObject>();
            var objectConverter = new PartialObjectConverter();
            var responseObject = objectConverter.ConvertToExpandoObject(response,
                new ObjectDefinition()
                {
                    Properties = new Dictionary<string, ObjectDefinition>()
                    {
                        {"Birthday", null},
                        {"Integer", null},
                        {"NullableDouble", null},
                        {"NullableBirthday", null}
                    }
                });
            var responseDict = responseObject as IDictionary<string, object>;
            Assert.AreEqual(6, responseDict.Keys.Count);
            Assert.AreEqual(response.TestObjectId, responseDict["TestObjectId"]);
            Assert.AreEqual(response.URI, responseDict["URI"]);
            Assert.AreEqual(response.Integer, responseDict["Integer"]);
            Assert.AreEqual(response.Birthday, responseDict["Birthday"]);
            Assert.AreEqual(response.NullableDouble, responseDict["NullableDouble"]);
            Assert.AreEqual(response.NullableBirthday, responseDict["NullableBirthday"]);

        }

        [Test]
        public void Should_Include_NestedObject()
        {
            var response = new Fixture().Create<TestObject>();
            var objectConverter = new PartialObjectConverter();
            var responseObject = objectConverter.ConvertToExpandoObject(response,
                new ObjectDefinition()
                {
                    Properties = new Dictionary<string, ObjectDefinition>()
                    {
                        {"Birthday", null},
                        {"Integer", null},
                        {"NullableDouble", null},
                        {"NullableBirthday", null},
                        {"NestedObject", null}
                    }
                });

            var responseDict = responseObject as IDictionary<string, object>;
            Assert.AreEqual(7, responseDict.Keys.Count);
            Assert.AreEqual(response.NestedObject, responseDict["NestedObject"]);
        }

        [Test]
        public void Should_Include_NestedObjectProperties()
        {
            var response = new Fixture().Create<TestObject>();
            var objectConverter = new PartialObjectConverter();
            var responseObject = objectConverter.ConvertToExpandoObject(response,
                new ObjectDefinition()
                {
                    Properties = new Dictionary<string, ObjectDefinition>()
                    {
                        {"Birthday", null},
                        {"Integer", null},
                        {"NullableDouble", null},
                        {"NullableBirthday", null},
                        {
                            "NestedObject",
                            new ObjectDefinition()
                            {
                                Properties = new Dictionary<string, ObjectDefinition>()
                                {
                                    {"Birthday", null},
                                    {"Integer", null}
                                }
                            }
                        }
                    }
                });

            var responseDict = responseObject as IDictionary<string, object>;
            Assert.AreEqual(7, responseDict.Keys.Count);
            Assert.AreNotEqual(response.NestedObject, responseDict["NestedObject"]);
            var nestObjectDict = responseDict["NestedObject"] as IDictionary<string, object>;
            Assert.IsNotNull(nestObjectDict);
            Assert.AreEqual(4, nestObjectDict.Keys.Count);
            Assert.AreEqual(response.NestedObject.TestObject2Id, nestObjectDict["TestObject2Id"]);
            Assert.AreEqual(response.NestedObject.URI, nestObjectDict["URI"]);
            Assert.AreEqual(response.NestedObject.Birthday, nestObjectDict["Birthday"]);
            Assert.AreEqual(response.NestedObject.Integer, nestObjectDict["Integer"]);
        }

        [Test]
        public void Should_Include_NestedObjectPropertiesAndList()
        {
            var response = new Fixture().Create<TestObject>();
            var objectConverter = new PartialObjectConverter();
            var responseObject = objectConverter.ConvertToExpandoObject(response,
                new ObjectDefinition()
                {
                    Properties = new Dictionary<string, ObjectDefinition>()
                    {
                        {"Birthday", null},
                        {"Integer", null},
                        {"NullableDouble", null},
                        {"NullableBirthday", null},
                        {
                            "NestedObject",
                            new ObjectDefinition()
                            {
                                Properties = new Dictionary<string, ObjectDefinition>()
                                {
                                    {"Birthday", null},
                                    {"Integer", null}
                                }
                            }
                        },
                        {
                            "ListObjects", new ObjectDefinition()
                            {
                                Properties = new Dictionary<string, ObjectDefinition>()
                                {
                                    {"OtherProperty", null}
                                }
                            }
                        }
                    }
                });

            var responseDict = responseObject as IDictionary<string, object>;
            Assert.AreEqual(8, responseDict.Keys.Count);

            // check the nested object
            var nestObjectDict = responseDict["NestedObject"] as IDictionary<string, object>;
            Assert.IsNotNull(nestObjectDict);
            Assert.AreEqual(4, nestObjectDict.Keys.Count);
            Assert.AreEqual(response.NestedObject.TestObject2Id, nestObjectDict["TestObject2Id"]);
            Assert.AreEqual(response.NestedObject.URI, nestObjectDict["URI"]);
            Assert.AreEqual(response.NestedObject.Birthday, nestObjectDict["Birthday"]);
            Assert.AreEqual(response.NestedObject.Integer, nestObjectDict["Integer"]);

            // check the listed object
            var listObjects = responseDict["ListObjects"] as ICollection<ExpandoObject>;
            Assert.IsNotNull(listObjects);
            Assert.AreEqual(response.ListObjects.Count, listObjects.Count);
            for (int i = 0; i < listObjects.Count; i++)
            {
                var convertedElement = listObjects.ElementAt(i) as IDictionary<string, object>;
                Assert.AreEqual(response.ListObjects[i].TestObject3Id, convertedElement["TestObject3Id"]);
                Assert.AreEqual(response.ListObjects[i].URI, convertedElement["URI"]);
                Assert.AreEqual(response.ListObjects[i].OtherProperty, convertedElement["OtherProperty"]);

            }
            Console.WriteLine(JsonConvert.SerializeObject(responseObject));
        }
    }
}
