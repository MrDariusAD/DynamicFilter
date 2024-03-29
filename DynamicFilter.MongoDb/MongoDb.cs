﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DynamicFilter.Domain.Comparer;
using DynamicFilter.Domain.Core;
using DynamicFilter.Domain.Core.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DynamicFilter.MongoDb {
    public static class MongoDb {
        private static MongoClient _client;
        private static bool _isConnected;
        private static string _lastDatabase;
        private static string _lastCollection;
        private static IMongoDatabase _database;
        private static IMongoCollection<Item> _collection;

        #region Delete

        public static bool Delete(string id) {
            if (!_isConnected) return false;
            OpenCollection(nameof(Item) + "s");
            return _collection.DeleteOne(GetIdFilterDefinition(id)).DeletedCount > 0;
        }
        public static FilterDefinition<Item> GetIdFilterDefinition(string id) {
            return Builders<Item>.Filter.Eq("_id", ObjectId.Parse(id));
        }

        #endregion

        #region Infrastructure

        public static void Connect(string connectionString) {
            if (_isConnected) return;
            _client = new MongoClient(connectionString);
            _isConnected = true;
        }


        private static void OpenDatabase(string databaseName) {
            if (!_isConnected) return;
            if (_lastDatabase == databaseName) return;
            _database = _client.GetDatabase(databaseName);
            _lastDatabase = databaseName;
        }

        private static void OpenCollection(string collectionName) {
            if (!_isConnected) return;
            OpenDatabase("DynamicFilter");
            if (_lastCollection == collectionName) return;
            _collection = _database.GetCollection<Item>(collectionName);
            _lastCollection = collectionName;
        }

        #endregion

        #region Load

        public static List<Item> Load(Item filterItem) {
            if (!_isConnected) return null;
            OpenCollection(nameof(Item) + "s");
            var filter = Builders<Item>.Filter;
            var buildFilter = FilterDefinition<Item>.Empty;
            if (!string.IsNullOrWhiteSpace(filterItem.Name)) {
                var regex = new BsonRegularExpression($".*{filterItem.Name}.*", "i");
                buildFilter &= filter.Regex(x => x.Name, regex);
            }

            if (filterItem.Attributes != null) {
                foreach (var attribute in filterItem.Attributes) {
                    if (attribute == null) continue;
                    buildFilter &= filter.ElemMatch(x => x.Attributes, y => y.Name == attribute.Name && y.Value == attribute.Value);
                }
            }


            var comparer = new AttributeComparer();
            if (filterItem.AttributeGroups != null) {
                foreach (var attributeGroup in filterItem.AttributeGroups) {
                    if (attributeGroup == null) continue;
                    foreach (var attribute in attributeGroup.Attributes) {
                        if (attribute == null) continue;
                        buildFilter &= filter.ElemMatch(x => x.AttributeGroups,
                            y => y.Name == attributeGroup.Name && y.Attributes.Any(z=> z.Name == attribute.Name && z.Value == attribute.Value));
                    }
                }
            }

            var result = _collection.Find(buildFilter).ToList();
            return result;
        }

        public static List<Item> Load() {
            if (!_isConnected) return null;
            OpenCollection(nameof(Item) + "s");
            var cursor = _collection.FindSync(FilterDefinition<Item>.Empty);
            var result = new List<Item>();

            while (cursor.MoveNext()) result.AddRange(cursor.Current);
            return result;
        }

        public static Item Load(string id) {
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

        public static void Save(Item itemToSave) {
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

        #region Edit

        public static bool Edit(string id, string fieldName, string newValue) {
            if (!_isConnected) return false;
            OpenCollection(nameof(Item) + "s");
            var updateDef = Builders<Item>.Update.Set("Attributes.$.Value", newValue);
            return _collection.UpdateOne(
                           GetIdFilterDefinition(id) & Builders<Item>.Filter.Eq("Attributes.Name", fieldName),
                           updateDef)
                       .ModifiedCount > 0;
        }

        public static bool Edit(string id, string newName) {
            if (!_isConnected) return false;
            OpenCollection(nameof(Item) + "s");
            var updateDef = Builders<Item>.Update.Set("Name", newName);
            return _collection.UpdateOne(
                           GetIdFilterDefinition(id),
                           updateDef)
                       .ModifiedCount > 0;
        }

        public static bool Edit(string id, string fieldName, AttributeType newType) {
            if (!_isConnected) return false;
            OpenCollection(nameof(Item) + "s");
            var updateDef = Builders<Item>.Update.Set("Attributes.$.Type", newType);
            return _collection.UpdateOne(
                           GetIdFilterDefinition(id) & Builders<Item>.Filter.Eq("Attributes.Name", fieldName),
                           updateDef)
                       .ModifiedCount > 0;
        }

        #endregion
    }
}