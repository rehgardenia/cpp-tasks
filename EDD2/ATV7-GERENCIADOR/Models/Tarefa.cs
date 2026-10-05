namespace GerenciadorTarefas.Models;
public class Tarefa
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public int Prioridade { get; set; } // 1- alta, 2- média, 3- baixa
    public string Status { get; set; } // "Pendente", "Concluída", "Cancelada"
    public DateTime DataCriacao { get; set; }
    public DateTime DataConclusao { get; set; }

    public Tarefa()
    {
        DataCriacao = DateTime.Now;
    }
    public void Concluir()
    {
       
    }
    public void Cancelar()
    {
        
    }
    public void Reabrir()
    {
       
    }
}