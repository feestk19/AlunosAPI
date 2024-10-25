#region Features History
/*
    FEATURE_DATE: 25/10/2024
    FEATURE: Added maintenance coment
 */
#endregion
namespace AlunosAPI.Models;

public class Aluno
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public int Idade { get; set; }
}
