namespace ATV7_GERENCIADOR.Controller;

using ATV7_GERENCIADOR.Models;

public class ProjetosController
{
    private readonly Projetos _projetos;

    public ProjetosController()
    {
        _projetos = new Projetos();
    }

    public bool AdicionarProjeto(Projeto p)
    {
        return _projetos.Adicionar(p);
    }

    public bool RemoverProjeto(Projeto projeto)
    {
        return _projetos.Remover(projeto);
    }

    public Projeto? BuscarProjeto(string nome)
    {
        return _projetos.BuscarPorNome(nome);
    }

    public List<Projeto> ListarProjetos()
    {
        return _projetos.Listar();
    }
}