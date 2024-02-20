using MongoDBDemo.Models;
using MongoDBDemo.Repository;

namespace MongoDBDemo.Services;

public class StudentService(IStudentRepository studentRepository) : IStudentService
{
    public Student GetStudent(string name)
    {
        return studentRepository.GetStudent(name);
    }

    public void AddStudent(Student student)
    {
        studentRepository.AddStudent(student);
    }

    public void UpdateStudent(Student student)
    {
        studentRepository.UpdateStudent(student);
    }

    public void DeleteStudent(string id)
    {
        studentRepository.DeleteStudent(id);
    }
}