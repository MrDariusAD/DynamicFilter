using System;
using System.Collections.Generic;
using System.Threading;
using DynamicFilter.Domain.Core.Models;
using DynamicFilter.MongoDb;
using MongoDB.Bson;
using Attribute = DynamicFilter.Domain.Core.Models.Attribute;

namespace ItemImporter {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine($"DynamicFilterItemImporter{Environment.NewLine}");

            var items = new List<Item>();
            while (true) {
                Console.WriteLine("Name (x to finish) : ");
                var name = Console.ReadLine() ?? "";
                if (name.ToLowerInvariant() == "x") {
                    break;
                }
                var attributes = new List<Attribute>();
                while (true) {
                    Console.WriteLine("Attribute Name (x to finish): ");
                    var attributeName = Console.ReadLine() ?? "";
                    if (attributeName.ToLowerInvariant() == "x")
                        break;
                    if (string.IsNullOrWhiteSpace(attributeName)) {
                        Console.WriteLine("Attribute Name cannot be empty!");
                        Thread.Sleep(2000);
                        continue;
                    }

                    Console.WriteLine("Attribute Type (1: string, 2: int, 3: bool): ");
                    var attributeType = Console.ReadLine() ?? "";

                    if (string.IsNullOrWhiteSpace(attributeType)) {
                        Console.WriteLine("Attribute Type cannot be empty!");
                        Thread.Sleep(2000);
                        continue;
                    }

                    if (!int.TryParse(attributeType, out var attributeTypeAsInt)) {
                        Console.WriteLine("Attribute Type has to be a number!");
                        Thread.Sleep(2000);
                        continue;
                    }

                    if (!(attributeTypeAsInt >= 1 && attributeTypeAsInt <= 3)) {
                        Console.WriteLine("Attribute Type has to be between 1 and 3!");
                        Thread.Sleep(2000);
                        continue;
                    }

                    Console.WriteLine("Attribute Value: ");
                    var attributeValue = Console.ReadLine() ?? "";

                    if (string.IsNullOrWhiteSpace(attributeValue)) {
                        Console.WriteLine("Attribute Value cannot be empty!");
                        Thread.Sleep(2000);
                        continue;
                    }
                    Console.WriteLine("Attribute Weight: ");
                    var attributeWeight = Console.ReadLine() ?? "";

                    if (string.IsNullOrWhiteSpace(attributeWeight)) {
                        Console.WriteLine("Attribute Weight cannot be empty!");
                        Thread.Sleep(2000);
                        continue;
                    }
                    if (!decimal.TryParse(attributeWeight, out var attributeWeightAsDecimal)) {
                        Console.WriteLine("Attribute Weight has to be a number!");
                        Thread.Sleep(2000);
                        continue;
                    }

                    attributes.Add(new Attribute {
                        Name = attributeName,
                        Type = (AttributeType)attributeTypeAsInt - 1,
                        Value = attributeValue,
                        Weight = attributeWeightAsDecimal
                    });
                }

                items.Add(new Item {
                    Name = name,
                    Attributes = attributes,
                    Id = ObjectId.GenerateNewId()
                });

            }
            Console.WriteLine("Saving items...");
            MongoDb.Connect("localhost");
            MongoDb.Save(items); 
            Console.WriteLine("Saved!");
        }
    }
}
