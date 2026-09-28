using Escola.Model;
using Escola.View;

namespace Escola.Controller;

public class EscolaController
{
    private EscolaModel escola;
    private EscolaView view;

    public EscolaController(EscolaModel escola, EscolaView view)
    {
        this.escola = escola;
        this.view = view;
    }

    public void AdicionarCurso()
    {
        Curso curso = new Curso();
        curso.Id = view.LerId("ID do curso: ");
        curso.Descricao = view.LerTexto("Descrição do curso: ");

        if (escola.AdicionarCurso(curso))
        {
            view.ExibirMensagem("Curso adicionado.");
        }
        else
        {
            view.ExibirMensagem("Não foi possível adicionar o curso.");
        }
    }

    public void PesquisarCurso()
    {
        int id = view.LerId("ID do curso: ");
        Curso? curso = escola.PesquisarCurso(id);

        if (curso == null)
        {
            view.ExibirMensagem("Curso não encontrado.");
        }
        else
        {
            view.ExibirCurso(curso);
        }
    }

    public void RemoverCurso()
    {
        int id = view.LerId("ID do curso: ");
        Curso? curso = escola.PesquisarCurso(id);

        if (curso == null)
        {
            view.ExibirMensagem("Curso não encontrado.");
            return;
        }

        foreach (Disciplina? disciplina in curso.Disciplinas)
        {
            if (disciplina != null)
            {
                view.ExibirMensagem("O curso possui disciplinas e não pode ser removido.");
                return;
            }
        }

        escola.RemoverCurso(id);
        view.ExibirMensagem("Curso removido.");
    }

    public void AdicionarDisciplina()
    {
        Curso? curso = LerCurso();

        if (curso == null)
        {
            return;
        }

        Disciplina disciplina = new Disciplina();
        disciplina.Id = view.LerId("ID da disciplina: ");
        disciplina.Descricao = view.LerTexto("Descrição da disciplina: ");

        if (curso.AdicionarDisciplina(disciplina))
        {
            view.ExibirMensagem("Disciplina adicionada.");
        }
        else
        {
            view.ExibirMensagem("Não foi possível adicionar a disciplina.");
        }
    }

    public void PesquisarDisciplina()
    {
        Disciplina? disciplina = LerDisciplina();

        if (disciplina != null)
        {
            view.ExibirDisciplina(disciplina);
        }
    }

    public void RemoverDisciplina()
    {
        Curso? curso = LerCurso();

        if (curso == null)
        {
            return;
        }

        int idDisciplina = view.LerId("ID da disciplina: ");
        Disciplina? disciplina = curso.PesquisarDisciplina(idDisciplina);

        if (disciplina == null)
        {
            view.ExibirMensagem("Disciplina não encontrada.");
            return;
        }

        foreach (Aluno? aluno in disciplina.Alunos)
        {
            if (aluno != null)
            {
                view.ExibirMensagem("A disciplina possui alunos e não pode ser removida.");
                return;
            }
        }

        curso.RemoverDisciplina(idDisciplina);
        view.ExibirMensagem("Disciplina removida.");
    }

    public void MatricularAluno()
    {
        Disciplina? disciplina = LerDisciplina();

        if (disciplina == null)
        {
            return;
        }

        Aluno aluno = new Aluno();
        aluno.Id = view.LerId("ID do aluno: ");
        aluno.Nome = view.LerTexto("Nome do aluno: ");

        if (disciplina.MatricularAluno(aluno))
        {
            view.ExibirMensagem("Aluno matriculado.");
        }
        else
        {
            view.ExibirMensagem("Não foi possível matricular o aluno.");
        }
    }

    public void DesmatricularAluno()
    {
        Disciplina? disciplina = LerDisciplina();

        if (disciplina == null)
        {
            return;
        }

        int idAluno = view.LerId("ID do aluno: ");

        if (disciplina.DesmatricularAluno(idAluno))
        {
            view.ExibirMensagem("Aluno desmatriculado.");
        }
        else
        {
            view.ExibirMensagem("Aluno não encontrado.");
        }
    }

    public void PesquisarAluno()
    {
        string nome = view.LerTexto("Nome do aluno: ");
        bool encontrou = false;

        foreach (Curso? curso in escola.Cursos)
        {
            if (curso == null)
            {
                continue;
            }

            foreach (Disciplina? disciplina in curso.Disciplinas)
            {
                if (disciplina == null)
                {
                    continue;
                }

                foreach (Aluno? aluno in disciplina.Alunos)
                {
                    if (aluno != null && aluno.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
                    {
                        if (!encontrou)
                        {
                            view.ExibirAluno(aluno);
                            view.ExibirMensagem("Matrículas:");
                            encontrou = true;
                        }

                        view.ExibirMatricula(curso, disciplina);
                    }
                }
            }
        }

        if (!encontrou)
        {
            view.ExibirMensagem("Aluno não encontrado.");
        }
    }

    private Curso? LerCurso()
    {
        int id = view.LerId("ID do curso: ");
        Curso? curso = escola.PesquisarCurso(id);

        if (curso == null)
        {
            view.ExibirMensagem("Curso não encontrado.");
        }

        return curso;
    }

    private Disciplina? LerDisciplina()
    {
        Curso? curso = LerCurso();

        if (curso == null)
        {
            return null;
        }

        int id = view.LerId("ID da disciplina: ");
        Disciplina? disciplina = curso.PesquisarDisciplina(id);

        if (disciplina == null)
        {
            view.ExibirMensagem("Disciplina não encontrada.");
        }

        return disciplina;
    }
}
