using MongoDB.Driver;
using MongoDBDemo.Models;
using MongoDBDemo.MongoDB;

namespace MongoDBDemo.Repository;

public class StudentRepository(MongoDbContext mongoDbContext) : IStudentRepository
{
    /// <summary>
    /// Only retrieves the first student with the name, not very useful for an actual application.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Student GetStudent(string name)
    {
        return mongoDbContext.Students.Find(x => x.Name == name).First();
    }

    public void AddStudent(Student student)
    {
        mongoDbContext.Students.InsertOne(student);
    }

    public void UpdateStudent(Student student)
    {
        var filter = Builders<Student>.Filter.Eq(x => x.Id, student.Id);
        mongoDbContext.Students.ReplaceOne(filter, student);
    }

    public void DeleteStudent(string id)
    {
        mongoDbContext.Students.DeleteOne(x => x.Id == id);
    }

    public IEnumerable<Student> GetAllStudents()
    {
        return mongoDbContext.Students.Find(_ => true).ToList();
    }
}