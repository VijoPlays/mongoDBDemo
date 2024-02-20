using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBDemo.Models;

public class Student(string name, bool hasGraduated, int age)
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    [BsonElement("name")]
    public string Name { get; set; } = name;

    [BsonElement("graduated")]
    public bool HasGraduated { get; set; } = hasGraduated;

    [BsonElement("age")]
    public int Age { get; set; } = age;
}