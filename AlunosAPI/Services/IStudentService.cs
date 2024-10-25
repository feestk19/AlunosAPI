using AlunosAPI.Models;

namespace AlunosAPI.Services;

public interface IStudentService
{
    Task<IEnumerable<Aluno>> GetStudents();
    Task<Aluno> GetStudentById(int id);
    Task<IEnumerable<Aluno>> GetStudentsByName(string name);
    Task CreateStudent(Aluno stundent);
    Task UpdateStudent(Aluno stundent);
    Task DeleteStudent(Aluno stundent);
}
