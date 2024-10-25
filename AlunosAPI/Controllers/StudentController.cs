#region Features History
/*
    FEATURE_DATE: 25/10/2024
    FEATURE: CRUD Implemented.
 */
#endregion

using AlunosAPI.Models;
using AlunosAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlunosAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;        
    }

    [HttpGet]
    public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetStudents()
    {
        try
        {
            var students = await _studentService.GetStudents();
            return Ok(students);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving student.");
        }
    }

    [HttpGet("StudentByName")]
    public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetStudentsByName([FromQuery] string name)
    {
        try
        {
            var students = await _studentService.GetStudentsByName(name);

            if (students is null)
                return NotFound($"No students found with the specified name -> {name}");

            return Ok(students);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving student by name.");
        }
    }

    [HttpGet("{id:int}", Name= "GetStudentsById")]
    public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetStudentsById(int id)
    {
        try
        {
            var student = await _studentService.GetStudentById(id);

            if (student is null)
                return NotFound($"No student found with id -> {id}");

            return Ok(student);
        }
        catch
        {
            return BadRequest("Invalid Request.");
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateStudent(Aluno student)
    {
        try
        {
            await _studentService.CreateStudent(student);
            return CreatedAtRoute(nameof(GetStudentsById), new { id = student.Id }, student);
        }
        catch (Exception)
        {
            return BadRequest("Invalid Request.");
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> EditStudent(int id, [FromBody] Aluno student)
    {
        try
        {
            if(student.Id == id)
            {
                await _studentService.UpdateStudent(student);
                //return NoContent();
                return Ok($"Student with id={id} updated successfully!");
            }
            else
            {
                return BadRequest("Inconsistent data.");
            }
        }
        catch
        {
            return BadRequest("Invalid Request.");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteStudent(int id)
    {
        try
        {
            var student = await _studentService.GetStudentById(id);
            if (student != null)
            {
                await _studentService.DeleteStudent(student);
                return Ok($"Student with id= {id} deleted.");
            }
            else
            {
                return NotFound($"Student with id= {id} not found.");
            }
        }
        catch
        {
            return BadRequest("Invalid Request.");
        }
    }
}
