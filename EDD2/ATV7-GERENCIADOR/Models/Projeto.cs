namespace GerenciadorDeTarefas.Models;

public class Projeto
{
    public int Id {get;set;}
    public string Nome {get;set;}
    public  List<Tarefa> Tarefas {get;set;}

    public Projeto()
    {
        Tarefas = new List<Tarefa>();
    }
    public void acionarTarefa(Tarefa tarefa)
    {
        Tarefas.Add(tarefa);
    }   
    public bool removerTarefa(Tarefa tarefa)
    {
        return Tarefas.Remove(tarefa);
    }
    public Tarefa buscarTarefa(Tarefa tarefa)
    {
        return Tarefas.FirstOrDefault(t => t.Id == tarefa.Id);
    }
    public List<Tarefa> tarefasPorStatus(string status)
    {
        return Tarefas.Where(t => t.Status == status).ToList();
    }
    public List<Tarefa> tarefasPorPrioridade(int prioridade)
    {
        return Tarefas.Where(t => t.Prioridade == prioridade).ToList();
    }
    public int totalAbertas()
    {
        return Tarefas.Count(t => t.Status == "Pendente");
    }
    public int totalConcluidas()
    {
        return Tarefas.Count(t => t.Status == "Concluída");
    }
}