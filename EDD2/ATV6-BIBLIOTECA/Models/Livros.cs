namespace ATV6_BIBLIOTECA.Models;
public class Livros
{
    public List<Livro> Acervo { get; set; }

    public Livros()
    {
        Acervo = new List<Livro>();
    }
    public void adicionar(Livro l)
    {
        Acervo.Add(l);
    }
    public Livro? pesquisar(Livro l)
    {
        return Acervo.FirstOrDefault(livro => livro.Isbn == l.Isbn);
    }
    public Livro? pesquisar(string isbn)
    {
        return Acervo.FirstOrDefault(livro => livro.Isbn == isbn);
    }
}
