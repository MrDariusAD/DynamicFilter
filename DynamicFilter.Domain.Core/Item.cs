using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DynamicFilter.Domain.Core
{
  public class Item
  {
    public ObjectId Id { get; set; }
    public List<Attribute> Attributes { get; set; }
  }
}