namespace ATV7_GERENCIADOR.Models;

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
       if (Status != "Concluída")
        {
            Status = "Concluída";
            DataConclusao = DateTime.Now;
        }
        else
        {
            Console.WriteLine("A tarefa já está concluída.");
        }
    }
    public void Cancelar()
    {
        if (Status != "Cancelada")
        {
            Status = "Cancelada";
        }
        else
        {
            Console.WriteLine("A tarefa já está cancelada.");
        }
    }
    public void Reabrir()
    {
        if (Status != "Pendente"){
            Status = "Pendente";
            DataConclusao = DateTime.MinValue;
        }
        else{
            Console.WriteLine("A tarefa já está aberta.");
        }
    }
}