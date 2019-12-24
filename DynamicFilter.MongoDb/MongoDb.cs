using System.Collections.Generic;
using System.Linq;
using DynamicFilter.Domain.Core;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DynamicFilter.MongoDb {
  public static class MongoDb
  {
    private static MongoClient _client;
    private static bool _isConnected = false;
    private static string _lastDatabase;
    private static string _lastCollection;
    private static IMongoDatabase _database;
    private static IMongoCollection<Item> _collection;

    #region Infrastructure
    public static void Connect(string connectionUrl)
    {
      if (_isConnected) return;
      _client = new MongoClient(new MongoClientSettings
      {
        Server = new MongoServerAddress(connectionUrl)
      });
      _isConnected = true;
    }

    private static void OpenDatabase(string databaseName)
    {
      if (!_isConnected) return;
      if (_lastDatabase == databaseName) return;
      _database = _client.GetDatabase(databaseName);
      _lastDatabase = databaseName;
    }

    private static void OpenCollection(string collectionName)
    {
      if (!_isConnected) return;
      OpenDatabase("DynamicFilter");
      if (_lastCollection == collectionName) return;
      _collection = _database.GetCollection<Item>(collectionName);
      _lastCollection = collectionName;
    }

    public static FilterDefinition<Item> GetIdFilterDefinition(string id)
    {
      return Builders<Item>.Filter.Eq("_id", ObjectId.Parse(id));
    }
    #endregion

    #region Load
    public static List<Item> Load(Item filterItem)
    {
      if (!_isConnected) return null;
      OpenCollection(nameof(Item) + "s");
      //var filter = Builders<Item>.Filter;
      //var buildFilter = FilterDefinition<Item>.Empty;

      //foreach (var attribute in filterItem.Attributes)
      //{
      //  buildFilter &= filter.ElemMatch(x => x.Attributes, y => y.Name == attribute.Name && y.Value == attribute.Value);
      //}
      var filterBson = filterItem.ToBsonDocument();
      var cursor = _collection.FindSync<Item>(filterBson);
      var result = new List<Item>();

      while (cursor.MoveNext()) { 
        result.AddRange(cursor.Current);
      }
      return result;
    }

    public static List<Item> Load()
    {
      if (!_isConnected) return null;
      OpenCollection(nameof(Item) + "s");
      var cursor = _collection.FindSync(FilterDefinition<Item>.Empty);
      var result = new List<Item>();

      while (cursor.MoveNext()) {
        result.AddRange(cursor.Current);
      }
      return result;
    }

    public static Item Load(string id)
    {
      if (!_isConnected) return null;
      OpenCollection(nameof(Item) + "s");
      var test = _collection.Find(_ => true).ToList();
      var query = _collection.FindSync(GetIdFilterDefinition(id)).ToList();
      var cur = query;
      var res = cur?.FirstOrDefault();
      return res;
    }


    #endregion

    #region Save
    public static void Save(Item itemToSave)
    {
      if (!_isConnected) return;
      OpenCollection(nameof(Item) + "s");
      _collection.InsertOne(itemToSave);
    }

    public static void Save(List<Item> itemsToSave) {
      if (!_isConnected || !itemsToSave.Any()) return;
      OpenCollection(nameof(Item) + "s");
      _collection.InsertMany(itemsToSave);
    }
    #endregion

    #region Delete

    public static bool Delete(string id)
    {
      if (!_isConnected) return false;
      OpenCollection(nameof(Item) + "s");
      return _collection.DeleteOne(GetIdFilterDefinition(id)).DeletedCount>0;
    }
    #endregion

    #region Edit

    public static bool Edit(string id, string fieldName, string newValue)
    {
      if (!_isConnected) return false;
      OpenCollection(nameof(Item) + "s");
      var updateDef = Builders<Item>.Update.Set($"Attributes.$.Value", newValue);
      return _collection.UpdateOne(GetIdFilterDefinition(id) & Builders<Item>.Filter.Eq("Attributes.Name", fieldName), updateDef).ModifiedCount>0;
    }

    public static bool Edit(string id, string fieldName, AttributeType newType) {
      if (!_isConnected) return false;
      OpenCollection(nameof(Item) + "s");
      var updateDef = Builders<Item>.Update.Set($"Attributes.$.Type", newType);
      return _collection.UpdateOne(GetIdFilterDefinition(id) & Builders<Item>.Filter.Eq("Attributes.Name", fieldName), updateDef).ModifiedCount > 0;
    }

    #endregion
  }
}
