namespace Escola.Model;

public class EscolaModel
{
    public Curso?[] Cursos { get; } = new Curso?[5];

    public bool AdicionarCurso(Curso curso)
    {
        for (int i = 0; i < Cursos.Length; i++)
        {
            if (Cursos[i] != null && Cursos[i]!.Id == curso.Id)
            {
                return false;
            }
        }

        for (int i = 0; i < Cursos.Length; i++)
        {
            if (Cursos[i] == null)
            {
                Cursos[i] = curso;
                return true;
            }
        }

        return false;
    }

    public Curso? PesquisarCurso(int id)
    {
        for (int i = 0; i < Cursos.Length; i++)
        {
            if (Cursos[i] != null && Cursos[i]!.Id == id)
            {
                return Cursos[i];
            }
        }

        return null;
    }

    public bool RemoverCurso(int id)
    {
        for (int i = 0; i < Cursos.Length; i++)
        {
            if (Cursos[i] != null && Cursos[i]!.Id == id)
            {
                Cursos[i] = null;
                return true;
            }
        }

        return false;
    }
}
