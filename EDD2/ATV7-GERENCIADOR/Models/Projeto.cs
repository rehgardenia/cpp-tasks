namespace ATV7_GERENCIADOR.Models;

public class Projeto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public List<Tarefa> Tarefas { get; set; }

    public Projeto()
    {
        Tarefas = new List<Tarefa>();
    }

    public void AdicionarTarefa(Tarefa tarefa)
    {
        if (tarefa is null) return;
        Tarefas.Add(tarefa);
    }

    public bool RemoverTarefa(Tarefa tarefa)
    {
        if (tarefa is null) return false;
        return Tarefas.Remove(tarefa);
    }

    public Tarefa? BuscarTarefaPorId(int id)
    {
        return Tarefas.FirstOrDefault(t => t.Id == id);
    }

    public List<Tarefa> TarefasPorStatus(string status)
    {
        return Tarefas.Where(t => t.Status == status).ToList();
    }

    public List<Tarefa> TarefasPorPrioridade(int prioridade)
    {
        return Tarefas.Where(t => t.Prioridade == prioridade).ToList();
    }

    public int TotalAbertas()
    {
        return Tarefas.Count(t => t.Status == "Pendente");
    }

    public int TotalConcluidas()
    {
        return Tarefas.Count(t => t.Status == "Concluída");
    }
}