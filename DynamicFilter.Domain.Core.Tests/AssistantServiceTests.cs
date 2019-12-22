using System.Collections.Generic;
using System.Linq;
using DynamicFilter.Domain.Core;
using DynamicFilter.Domain.Core.Services;
using FluentAssertions;
using MongoDB.Bson;
using static DynamicFilter.MongoDb.MongoDb;
using Xunit;
    

namespace DynamicFilter.Domain.Core.Tests {
    public class AssistantServiceTests {
        [Fact]
        public void CalculateOptimalItem_MethodIsCalledWithTheUserPreferences() {
            //Arrange
            Connect("localhost");
            var item1 = new Item {
                Id = ObjectId.GenerateNewId(),
                Attributes = new List<Attribute>
                {
                    new Attribute
                    {
                        Name = "Usability",
                        Value = "1",
                        Type = AttributeType.Int
                    },
                    new Attribute
                    {
                        Name = "Price",
                        Value = "1",
                        Type = AttributeType.Int
                    },
                    new Attribute
                    {
                        Name = "Scalable",
                        Value = "false",
                        Type = AttributeType.Bool
                    }
                }
            };
            var item2 = new Item {
                Id = ObjectId.GenerateNewId(),
                Attributes = new List<Attribute>
                {
                    new Attribute
                    {
                        Name = "Usability",
                        Value = "2",
                        Type = AttributeType.Int
                    },
                    new Attribute
                    {
                        Name = "Price",
                        Value = "2",
                        Type = AttributeType.Int
                    },
                    new Attribute
                    {
                        Name = "Scalable",
                        Value = "false",
                        Type = AttributeType.Bool
                    }
                }
            };
            var item3 = new Item {
                Id = ObjectId.GenerateNewId(),
                Attributes = new List<Attribute>
                {
                    new Attribute
                    {
                        Name = "Usability",
                        Value = "2",
                        Type = AttributeType.Int
                    },
                    new Attribute
                    {
                        Name = "Price",
                        Value = "7",
                        Type = AttributeType.Int
                    }
                }
            };
            var item4 = new Item {
                Id = ObjectId.GenerateNewId(),
                Attributes = new List<Attribute>
                {
                    new Attribute
                    {
                        Name = "Usability",
                        Value = "2",
                        Type = AttributeType.Int
                    },
                    new Attribute
                    {
                        Name = "Price",
                        Value = "2",
                        Type = AttributeType.Int
                    },
                    new Attribute
                    {
                        Name = "Scalable",
                        Value = "true",
                        Type = AttributeType.Bool
                    }
                }
            };

            var reportModel = new AssistantRequestReportModel
            {
                PreferenceAttributes = new List<Attribute>
                {
                    new Attribute
                    {
                        Name = "Usability",
                        Value = "2",
                        Type = AttributeType.Int
                    },
                    new Attribute
                    {
                        Name = "Price",
                        Value = "2",
                        Type = AttributeType.Int
                    },
                    new Attribute
                    {
                        Name = "Scalable",
                        Value = "true",
                        Type = AttributeType.Bool
                    }
                }
            };

            //Act
            var res = AssistantService.CalculateOptimalItem(reportModel, new List<Item>()
            {
                item1,
                item2,
                item3,
                item4
            });

            //Assert
            var first = res.FirstOrDefault();
            first.Should().NotBeNull();
            first.Item.Id.Should().BeEquivalentTo(item4.Id);
            first.RateInPercent.Should().Be(1);
            var second = res.ElementAt(1);
            second.Item.Id.Should().BeEquivalentTo(item2.Id);
            second.RateInPercent.Should().Be((float)2 / 3);
            var third = res.ElementAt(2);
            third.Item.Id.Should().BeEquivalentTo(item3.Id);
            third.RateInPercent.Should().Be((float)1 / 3);
            var fourth = res.ElementAt(3);
            fourth.Item.Id.Should().BeEquivalentTo(item1.Id);
            fourth.RateInPercent.Should().Be((float)0 / 3);
        }
    }
}
