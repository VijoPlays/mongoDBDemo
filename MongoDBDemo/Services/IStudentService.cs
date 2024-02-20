using MongoDBDemo.Models;

namespace MongoDBDemo.Services;

public interface IStudentService
{
    public Student GetStudent(string name);
    public void AddStudent(Student student);
    public void UpdateStudent(Student student);
    public void DeleteStudent(string id);
}