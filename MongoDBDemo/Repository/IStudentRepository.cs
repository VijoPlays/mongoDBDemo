using MongoDBDemo.Models;

namespace MongoDBDemo.Repository;

public interface IStudentRepository
{
    public Student GetStudent(string name);
    public void AddStudent(Student student);
    public void UpdateStudent(Student student);
    public void DeleteStudent(string id);
}