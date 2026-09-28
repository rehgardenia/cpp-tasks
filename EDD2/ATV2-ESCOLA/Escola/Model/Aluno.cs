namespace Escola.Model;
public class Aluno
{
    public int Id { get; set; }
    public string Nome { get; set; } 

    public Aluno()
    {
        Id = 0;
        Nome = string.Empty;
    }

    public void ExibirInformacoes()
    {
        Console.WriteLine($"Id: {Id} - Nome: {Nome}");
    }
}