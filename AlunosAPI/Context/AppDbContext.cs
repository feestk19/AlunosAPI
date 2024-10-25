using AlunosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AlunosAPI.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Aluno> Alunos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Cria os atributos da tabela Alunos
        modelBuilder.Entity<Aluno>(aluno =>
        {
            aluno.HasKey(a => a.Id);

            aluno.Property(a => a.Nome)
            .IsRequired()
            .HasMaxLength(80);

            aluno.Property(a => a.Email)
            .IsRequired()
            .HasMaxLength(100)
            .HasAnnotation("EmailAdress", true);

            aluno.Property(a => a.Idade)
            .IsRequired();
        });

        //Verifica se há dados na tabela, caso não tenha adiciona conforme o que será passado manualmente
        modelBuilder.Entity<Aluno>().HasData(
            new Aluno
            {
                Id = 1,
                Nome = "Maria da Penha",
                Email = "mariapenha@yahoo.com",
                Idade = 23
            },
            new Aluno
            {
                Id = 2,
                Nome = "Manuel Bueno",
                Email = "manuel@yahoo.com",
                Idade = 22
            }
            );
    }
}
