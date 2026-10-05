

namespace ATV7_GERENCIADOR.Models;

public class Projetos
{
    private readonly List<Projeto> _itens;

    public Projetos()
    {
        _itens = new List<Projeto>();
    }

    public bool Adicionar(Projeto projeto)
    {
        if (projeto is null)
            return false;

        if (_itens.Any(item => item.Nome.Equals(projeto.Nome, StringComparison.OrdinalIgnoreCase)))
            return false;

        _itens.Add(projeto);
        return true;
    }

    public bool Remover(Projeto projeto)
    {
        if (projeto is null)
            return false;

        return _itens.Remove(projeto);
    }

    public Projeto? BuscarPorNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return null;

        return _itens.FirstOrDefault(item => item.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
    }

    public List<Projeto> Listar()
    {
        return new List<Projeto>(_itens);
    }
}