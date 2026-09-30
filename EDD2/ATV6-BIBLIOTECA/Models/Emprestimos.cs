public class Emprestimo
{
    public DateTime DataEmprestimo { get; set; }
    public DateTime? DataDevolucao { get; set; }

    public Emprestimo()
    {
        DataEmprestimo = DateTime.Now;
        DataDevolucao = null;
    }
    
}