#region Features History
/*
    FEATURE_DATE: 25/10/2024
    FEATURE: Concrete methods implemented.
 */
#endregion

using AlunosAPI.Context;
using AlunosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AlunosAPI.Services;

public class StudentService : IStudentService
{
    private readonly AppDbContext _context;

    public StudentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Aluno>> GetStudents()
    {
        try
        {
            return await _context.Alunos.ToListAsync();
        }
        catch
        {
            throw;
        }
    }

    public async Task<IEnumerable<Aluno>> GetStudentsByName(string name)
    {
        IEnumerable<Aluno> students;
        if (!string.IsNullOrWhiteSpace(name))
        {
            students = await _context.Alunos.Where(n => n.Nome.Contains(name)).ToListAsync();
        }
        else
        {
            students = await GetStudents();
        }

        return students;
    }

    public async Task<Aluno> GetStudentById(int id)
    {
        var student = await _context.Alunos.FindAsync(id);
        return student;
    }

    public async Task CreateStudent(Aluno student)
    {
        _context.Alunos.Add(student);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateStudent(Aluno student)
    {
        _context.Entry(student).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteStudent(Aluno student)
    {
        _context.Alunos.Remove(student);
        await _context.SaveChangesAsync();
    }
}
