public class Exemplar
{
    public int Tombo { get; set; }
    public List<Emprestimo> Emprestimos { get; set; }

    public Exemplar()
    {
        Emprestimos = new List<Emprestimo>();
    }

    public bool emprestar()
    {
        Emprestimos.Add(new Emprestimo());
        return true;
    }
    public bool devolver()
    {
        if (Emprestimos.Count > 0)
        {
            Emprestimos.Last().DataDevolucao = DateTime.Now;
            return true;
        }
        return false;
    }
    public bool Disponivel ()
    {
        if (Emprestimos.Count == 0)
        {
            return true;
        }
        else
        {
            return Emprestimos.Last().DataDevolucao != null;
        }   
    }
    public int qtdEmprestimos()
    {
        return Emprestimos.Count;
    }

}