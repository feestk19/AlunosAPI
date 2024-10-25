#region Features History
/*
    FEATURE_DATE: 25/10/2024
    FEATURE: Added new Classes
 */
#endregion

using AlunosAPI.Models;

namespace AlunosAPI.Services;

public class StudentService : IStudentService
{
    public Task<IEnumerable<Aluno>> GetStudents()
    {
        throw new NotImplementedException();
    }

    public Task<Aluno> GetStudentById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Aluno>> GetStudentsByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task CreateStudent(Aluno stundent)
    {
        throw new NotImplementedException();
    }

    public Task UpdateStudent(Aluno stundent)
    {
        throw new NotImplementedException();
    }

    public Task DeleteStudent(Aluno stundent)
    {
        throw new NotImplementedException();
    }







}
