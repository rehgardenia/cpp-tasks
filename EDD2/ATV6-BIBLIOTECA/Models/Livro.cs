public class Livro
{
    public int Isbn { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Editora { get; set; }
    public List<Exemplar> Exemplares { get; set; }

    public Livro()
    {
        Exemplares = new List<Exemplar>();
    }
    public Livro(int isbn, string titulo, string autor, string editora)
    {
        Isbn = isbn;
        Titulo = titulo;
        Autor = autor;
        Editora = editora;
        Exemplares = new List<Exemplar>();
    }

    public void AdicionarExemplar(Exemplar exemplar)
    {
        Exemplares.Add(exemplar);
    }
    public int qtdExemplares()
    {
        return Exemplares.Count;
    }
    public int qtdDisponiveis()
    {
        int count = 0;
        foreach (var exemplar in Exemplares)
        {
            if (exemplar.Disponivel())
            {
                count++;
            }
        }
        return count;
    }
    public int qtdEmprestimos()
    {
        int count = 0;
        foreach (var exemplar in Exemplares)
        {
            if (!exemplar.Disponivel())
            {
                count++;
            }
        }
        return count;
    } 
    public double percDisponiveis()
    {
        if (Exemplares.Count == 0)
        {
            return 0;
        }
        return (double)qtdDisponiveis() / Exemplares.Count * 100;
    }

}