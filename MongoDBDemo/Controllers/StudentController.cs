using Microsoft.AspNetCore.Mvc;
using MongoDBDemo.Models;
using MongoDBDemo.Services;

namespace MongoDBDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController(IStudentService studentService) : ControllerBase
{

    [HttpGet("{name}")]
    public IActionResult GetStudent(string name)
    {
        var student = studentService.GetStudent(name);
        return Ok(student);
    }

    /// <summary>
    /// You shouldn't use the database entities for these calls, create separate models for them instead!
    /// </summary>
    /// <param name="student"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult AddStudent(Student student)
    {
        studentService.AddStudent(student);
        return Ok();
    }

    [HttpPut]
    public IActionResult UpdateStudent(Student student)
    {
        studentService.UpdateStudent(student);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(string id)
    {
        studentService.DeleteStudent(id);
        return Ok();
    }
}