using System.Collections.Generic;
using DynamicFilter.Domain.Core;
using FluentAssertions;
using MongoDB.Bson;
using Xunit;

namespace DynamicFilter.MongoDb.Tests {
  public class Tests {
    [Fact]
    public void Save_SaveAnExampleItemIntoTheDatabase_ExampleFileIsSavedAndCanBeLoaded() {
      //Arrange
      MongoDb.Connect("localhost");
      var id = ObjectId.GenerateNewId().ToString();
      var item = new Item {
        Id = ObjectId.Parse(id),
        Attributes = new List<Attribute>
      {
        new Attribute
        {
          Name = "Test",
          Value = "true",
          Type = AttributeType.String
        }
      }
      };

      //Act
      MongoDb.Save(item);

      //Assert
      var res = MongoDb.Load(id);
      res.Should().NotBeNull();

      MongoDb.Delete(id);
    }
    [Fact]
    public void Load_SaveAnExampleItemIntoTheDatabase_ExampleFileIsSavedAndCanBeLoaded() {
      //Arrange
      MongoDb.Connect("localhost");
      var id = ObjectId.GenerateNewId().ToString();
      var item = new Item {
        Id = ObjectId.Parse(id),
        Attributes = new List<Attribute>
        {
          new Attribute
          {
            Name = "Test",
            Value = "true",
            Type = AttributeType.String
          }
        }
      };

      //Act
      MongoDb.Save(item);

      //Assert
      var res = MongoDb.Load(item);
      res.Should().NotBeNull();

      MongoDb.Delete(id);
    }

    [Fact] public void Load_SaveMultipleExampleItemsIntoTheDatabase_ResultContainsAllExampleItems() {
      //Arrange
      MongoDb.Connect("localhost");
      var item1 = new Item {
        Id = ObjectId.GenerateNewId(),
        Attributes = new List<Attribute>
        {
          new Attribute
          {
            Name = "Test1",
            Value = "true",
            Type = AttributeType.String
          }
        }
      };
      var item2 = new Item {
        Id = ObjectId.GenerateNewId(),
        Attributes = new List<Attribute>
        {
          new Attribute
          {
            Name = "Test2",
            Value = "true",
            Type = AttributeType.String
          }
        }
      };
      var item3 = new Item {
        Id = ObjectId.GenerateNewId(),
        Attributes = new List<Attribute>
        {
          new Attribute
          {
            Name = "Test3",
            Value = "true",
            Type = AttributeType.String
          }
        }
      };
      var item4 = new Item {
        Id = ObjectId.GenerateNewId(),
        Attributes = new List<Attribute>
        {
          new Attribute
          {
            Name = "Test4",
            Value = "true",
            Type = AttributeType.String
          }
        }
      };

      //Act
      MongoDb.Save(item1);
      MongoDb.Save(item2);
      MongoDb.Save(item3);
      MongoDb.Save(item4);

      //Assert
      var res = MongoDb.Load();
      res.Should().ContainEquivalentOf(item1);
      res.Should().ContainEquivalentOf(item2);
      res.Should().ContainEquivalentOf(item3);
      res.Should().ContainEquivalentOf(item4);

      MongoDb.Delete(item1.Id.ToString());
      MongoDb.Delete(item2.Id.ToString());
      MongoDb.Delete(item3.Id.ToString());
      MongoDb.Delete(item4.Id.ToString());
    }
  }
}
