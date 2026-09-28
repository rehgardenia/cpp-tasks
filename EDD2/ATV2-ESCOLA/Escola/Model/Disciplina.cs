namespace Escola.Model;

public class Disciplina
{
    public int Id { get; set; }
    public string Descricao { get; set; } = "";
    public Aluno?[] Alunos { get; } = new Aluno?[15];

    public bool MatricularAluno(Aluno aluno)
    {
        for (int i = 0; i < Alunos.Length; i++)
        {
            if (Alunos[i] != null && Alunos[i]!.Id == aluno.Id)
            {
                return false;
            }
        }

        for (int i = 0; i < Alunos.Length; i++)
        {
            if (Alunos[i] == null)
            {
                Alunos[i] = aluno;
                return true;
            }
        }

        return false;
    }

    public bool DesmatricularAluno(int id)
    {
        for (int i = 0; i < Alunos.Length; i++)
        {
            if (Alunos[i] != null && Alunos[i]!.Id == id)
            {
                Alunos[i] = null;
                return true;
            }
        }

        return false;
    }
}
