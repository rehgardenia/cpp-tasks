namespace Escola.Model;

public class Curso
{
    public int Id { get; set; }
    public string Descricao { get; set; } = "";
    public Disciplina?[] Disciplinas { get; } = new Disciplina?[12];

    public bool AdicionarDisciplina(Disciplina disciplina)
    {
        for (int i = 0; i < Disciplinas.Length; i++)
        {
            if (Disciplinas[i] != null && Disciplinas[i]!.Id == disciplina.Id)
            {
                return false;
            }
        }

        for (int i = 0; i < Disciplinas.Length; i++)
        {
            if (Disciplinas[i] == null)
            {
                Disciplinas[i] = disciplina;
                return true;
            }
        }

        return false;
    }

    public Disciplina? PesquisarDisciplina(int id)
    {
        for (int i = 0; i < Disciplinas.Length; i++)
        {
            if (Disciplinas[i] != null && Disciplinas[i]!.Id == id)
            {
                return Disciplinas[i];
            }
        }

        return null;
    }

    public bool RemoverDisciplina(int id)
    {
        for (int i = 0; i < Disciplinas.Length; i++)
        {
            if (Disciplinas[i] != null && Disciplinas[i]!.Id == id)
            {
                Disciplinas[i] = null;
                return true;
            }
        }

        return false;
    }
}
