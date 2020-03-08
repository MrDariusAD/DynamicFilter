using System.Collections.Generic;
using System.Linq;
using DynamicFilter.Domain.Core.Models;
using DynamicFilter.Domain.Services;
using FluentAssertions;
using MongoDB.Bson;
using Xunit;

namespace DynamicFilter.Domain.Tests {
    public class AssistantServiceTests {
        [Fact]
        public void CalculateOptimalItem_MethodIsCalledWithTheUserPreferences_AssistantReturnsAListOrderedByHitRate() {
            //Arrange
            MongoDb.MongoDb.Connect("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass%20Community&ssl=false");
            var item1 = new Item {
                Id = ObjectId.GenerateNewId(),
                Name = "TestItem1",
                Attributes = new List<Attribute> {
                    new Attribute {
                        Name = "Usability",
                        Value = "1",
                        Type = AttributeType.Int,
                        Weight = 1
                    },
                    new Attribute {
                        Name = "Price",
                        Value = "1",
                        Type = AttributeType.Int,
                        Weight = 1
                    },
                    new Attribute {
                        Name = "Scalable",
                        Value = "false",
                        Type = AttributeType.Bool,
                        Weight = 1
                    }
                }
            };
            var item2 = new Item {
                Id = ObjectId.GenerateNewId(),
                Name = "TestItem2",
                Attributes = new List<Attribute> {
                    new Attribute {
                        Name = "Usability",
                        Value = "2",
                        Type = AttributeType.Int,
                        Weight = 1
                    },
                    new Attribute {
                        Name = "Price",
                        Value = "2",
                        Type = AttributeType.Int,
                        Weight = 1
                    },
                    new Attribute {
                        Name = "Scalable",
                        Value = "false",
                        Type = AttributeType.Bool,
                        Weight = 1
                    }
                }
            };
            var item3 = new Item {
                Id = ObjectId.GenerateNewId(),
                Name = "TestItem3",
                Attributes = new List<Attribute> {
                    new Attribute {
                        Name = "Usability",
                        Value = "2",
                        Type = AttributeType.Int,
                        Weight = 1
                    },
                    new Attribute {
                        Name = "Price",
                        Value = "7",
                        Type = AttributeType.Int,
                        Weight = 1
                    }
                }
            };
            var item4 = new Item {
                Id = ObjectId.GenerateNewId(),
                Name = "TestItem4",
                Attributes = new List<Attribute> {
                    new Attribute {
                        Name = "Usability",
                        Value = "2",
                        Type = AttributeType.Int,
                        Weight = 1
                    },
                    new Attribute {
                        Name = "Price",
                        Value = "2",
                        Type = AttributeType.Int,
                        Weight = 1
                    },
                    new Attribute {
                        Name = "Scalable",
                        Value = "true",
                        Type = AttributeType.Bool,
                        Weight = 1
                    }
                }
            };

            var reportModel = new AssistantRequestModel {
                PreferenceAttributes = new List<Attribute> {
                    new Attribute {
                        Name = "Usability",
                        Value = "2",
                        Type = AttributeType.Int,
                        Weight = 1
                    },
                    new Attribute {
                        Name = "Price",
                        Value = "2",
                        Type = AttributeType.Int,
                        Weight = 1
                    },
                    new Attribute {
                        Name = "Scalable",
                        Value = "true",
                        Type = AttributeType.Bool,
                        Weight = 1
                    }
                }
            };

            //Act
            var res = AssistantService.CalculateOptimalItems(reportModel, new List<Item> {
                item1,
                item2,
                item3,
                item4
            }).Result;

            //Assert
            var first = res.FirstOrDefault();
            first.Should().NotBeNull();
            first?.Item.Id.Should().BeEquivalentTo(item4.Id.ToString());
            first?.RateInPercent.Should().Be(100);
            var second = res.ElementAt(1);
            second.Item.Id.Should().BeEquivalentTo(item2.Id.ToString());
            second.RateInPercent.Should().Be(66.67);
            var third = res.ElementAt(2);
            third.Item.Id.Should().BeEquivalentTo(item3.Id.ToString());
            third.RateInPercent.Should().Be(33.33);
            var fourth = res.ElementAt(3);
            fourth.Item.Id.Should().BeEquivalentTo(item1.Id.ToString());
            fourth.RateInPercent.Should().Be(0);
        }
    }
}