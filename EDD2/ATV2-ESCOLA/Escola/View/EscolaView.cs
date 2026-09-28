using Escola.Model;

namespace Escola.View;

public class EscolaView
{
    public int ExibirMenu()
    {
        Console.WriteLine("=== Menu da Escola ===");
        Console.WriteLine("0. Sair");
        Console.WriteLine("1. Adicionar Curso");
        Console.WriteLine("2. Pesquisar Curso");
        Console.WriteLine("3. Remover Curso");
        Console.WriteLine("4. Adicionar Disciplina");
        Console.WriteLine("5. Pesquisar Disciplina");
        Console.WriteLine("6. Remover Disciplina");
        Console.WriteLine("7. Matricular Aluno");
        Console.WriteLine("8. Desmatricular Aluno");
        Console.WriteLine("9. Pesquisar Aluno");

        return LerNumero("Opção: ", 0, 9);
    }

    public int LerId(string mensagem)
    {
        return LerNumero(mensagem, 1, 999999);
    }

    public string LerTexto(string mensagem)
    {
        string? texto = "";

        while (texto == "")
        {
            Console.Write(mensagem);
            texto = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(texto))
            {
                Console.WriteLine("Este campo não pode ficar vazio.");
                texto = "";
            }
        }

        return texto;
    }

    public void ExibirMensagem(string mensagem)
    {
        Console.WriteLine(mensagem);
    }

    public void ExibirCurso(Curso curso)
    {
        Console.WriteLine($"Curso: {curso.Id} - {curso.Descricao}");
        Console.WriteLine("Disciplinas:");

        foreach (Disciplina? disciplina in curso.Disciplinas)
        {
            if (disciplina != null)
            {
                Console.WriteLine($"{disciplina.Id} - {disciplina.Descricao}");
            }
        }
    }

    public void ExibirDisciplina(Disciplina disciplina)
    {
        Console.WriteLine($"Disciplina: {disciplina.Id} - {disciplina.Descricao}");
        Console.WriteLine("Alunos:");

        foreach (Aluno? aluno in disciplina.Alunos)
        {
            if (aluno != null)
            {
                Console.WriteLine($"{aluno.Id} - {aluno.Nome}");
            }
        }
    }

    public void ExibirAluno(Aluno aluno)
    {
        Console.WriteLine($"Aluno: {aluno.Id} - {aluno.Nome}");
    }

    public void ExibirMatricula(Curso curso, Disciplina disciplina)
    {
        Console.WriteLine($"Curso: {curso.Descricao} | Disciplina: {disciplina.Descricao}");
    }

    private int LerNumero(string mensagem, int minimo, int maximo)
    {
        int numero;

        while (true)
        {
            Console.Write(mensagem);

            if (int.TryParse(Console.ReadLine(), out numero))
            {
                if (numero >= minimo && numero <= maximo)
                {
                    return numero;
                }
            }

            Console.WriteLine("Número inválido.");
        }
    }
}
