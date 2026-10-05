namespace GerenciadorDeTarefas.Models;

public class Projetos
{
    private List<Projeto> itens;

    public Projetos()
    {
        itens = new List<Projeto>();
    }
    public bool adicionar(Projetos p)
    {
        if (itens.Any(projeto => projeto.Nome == p.Nome))
        {
            return false; // Projeto com o mesmo nome já existe
        }
        itens.Add(p);
        return true; // Projeto adicionado com sucesso
    }
    public bool remover(Projetos p)
    {
        return itens.Remove(p);
    }
    public Projeto buscar(string nome)
    {
        return itens.FirstOrDefault(projeto => projeto.Nome == nome);
    }
    public List<Projeto> listar()
    {
        return itens;
    }
}