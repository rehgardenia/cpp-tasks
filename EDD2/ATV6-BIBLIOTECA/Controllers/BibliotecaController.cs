using ATV6_BIBLIOTECA.Models;
namespace ATV6_BIBLIOTECA.Controllers;
public class BibliotecaController
{
    public void Menu()
    {
        Console.WriteLine("Bem-vindo à Biblioteca!");
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("0. Sair");
        Console.WriteLine("1. Adicionar livro");
        Console.WriteLine("2. Pesquisar Livro (sintético)");
        Console.WriteLine("3. Pesquisar Livro (analítico)");
        Console.WriteLine("4. Adicionar exemplar"); 
        Console.WriteLine("5. Registrar empréstimo"); 
        Console.WriteLine("6. Registrar devolução"); 
    }

    public void AdicionarLivro(Livros livros)
    {
        try
        {
            Console.WriteLine("===== ADICIONAR LIVRO =====");
            Console.WriteLine("Digite o ISBN do livro:");
            string isbn = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Digite o título do livro:");
            string titulo = Console.ReadLine() ?? "";
            Console.WriteLine("Digite o autor do livro:");
            string autor = Console.ReadLine() ?? "";
            Console.WriteLine("Digite a editora do livro:");
            string editora = Console.ReadLine() ?? "";

            Livro livro = new Livro(isbn, titulo, autor, editora);
            livros.adicionar(livro);

            Console.WriteLine("Livro adicionado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao adicionar livro: " + ex.Message);
        }

    }
    public void PesquisarLivroSintetico(Livros livros)
    {
        try
        {
            Console.WriteLine("===== PESQUISAR LIVRO =====");
            Console.WriteLine("Digite o ISBN do livro:");
            string isbn = Console.ReadLine() ?? string.Empty;

            Livro? livro = livros.pesquisar(isbn);
            if (livro != null)
            {
                Console.WriteLine($"ISBN: {livro.Isbn}");
                Console.WriteLine($"Título: {livro.Titulo}");
                Console.WriteLine($"Autor: {livro.Autor}");
                Console.WriteLine($"Editora: {livro.Editora}");
                Console.WriteLine($"Quantidade de exemplares: {livro.qtdExemplares()}");
                Console.WriteLine($"Quantidade de exemplares disponíveis: {livro.qtdDisponiveis()}");
                Console.WriteLine($"Quantidade de empréstimos: {livro.qtdEmprestimos()}");
                Console.WriteLine($"Percentual de disponibilidade: {livro.percDisponiveis():F2}%");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao pesquisar livro: " + ex.Message);
        }
    }
    public void PesquisarLivroAnalitico(Livros livros)
    {
        try
        {
            Console.WriteLine("===== PESQUISAR LIVRO (ANALÍTICO) =====");
            Console.WriteLine("Digite o ISBN do livro:");
            string isbn = Console.ReadLine() ?? string.Empty;


            Livro? livro = livros.pesquisar(isbn);
            if (livro != null)
            {
                Console.WriteLine($"ISBN: {livro.Isbn}");
                Console.WriteLine($"Título: {livro.Titulo}");
                Console.WriteLine($"Autor: {livro.Autor}");
                Console.WriteLine($"Editora: {livro.Editora}");
                Console.WriteLine($"Quantidade de exemplares: {livro.qtdExemplares()}");
                Console.WriteLine($"Quantidade de exemplares disponíveis: {livro.qtdDisponiveis()}");
                Console.WriteLine($"Quantidade de empréstimos: {livro.qtdEmprestimos()}");
                Console.WriteLine($"Percentual de disponibilidade: {livro.percDisponiveis():F2}%");

                foreach (var exemplar in livro.Exemplares)
                {
                    Console.WriteLine($"Exemplar Tombo: {exemplar.Tombo}");
                    Console.WriteLine($"Disponível: {(exemplar.Disponivel() ? "Sim" : "Não")}");
                    foreach (var emprestimo in exemplar.Emprestimos)
                    {
                        Console.WriteLine($"Data Empréstimo: {emprestimo.DataEmprestimo}");
                        Console.WriteLine($"Data Devolução: {(emprestimo.DataDevolucao.HasValue ? emprestimo.DataDevolucao.Value.ToString() : "Não devolvido")}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao pesquisar livro: " + ex.Message);
        }
    }
    public void AdicionarExemplar(Livros livros)
    {
        try
        {
            Console.WriteLine("===== ADICIONAR EXEMPLAR =====");
            Console.WriteLine("Digite o ISBN do livro:");
            string isbn = Console.ReadLine() ?? string.Empty;

            Livro? livro = livros.pesquisar(isbn);
            if (livro != null)
            {
                Exemplar exemplar = new Exemplar();
                livro.AdicionarExemplar(exemplar);
                Console.WriteLine("Exemplar adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao adicionar exemplar: " + ex.Message);
        }
    }
    public void RegistrarEmprestimo(Livros livros)
    {
        try
        {
            Console.WriteLine("===== REGISTRAR EMPRÉSTIMO =====");
            Console.WriteLine("Digite o ISBN do livro:");
            string isbn = Console.ReadLine() ?? string.Empty;

            Livro? livro = livros.pesquisar(isbn);
            if (livro != null)
            {
                Exemplar? exemplarDisponivel = livro.Exemplares.FirstOrDefault(e => e.Disponivel());
                if (exemplarDisponivel != null)
                {
                    exemplarDisponivel.emprestar();
                    Console.WriteLine("Empréstimo registrado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não há exemplares disponíveis para empréstimo.");
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao registrar empréstimo: " + ex.Message);
        }
    }
    public void RegistrarDevolucao(Livros livros)
    {
        try
        {
            Console.WriteLine("===== REGISTRAR DEVOLUÇÃO =====");
            Console.WriteLine("Digite o ISBN do livro:");
            string isbn = Console.ReadLine() ?? string.Empty;

            Livro? livro = livros.pesquisar(isbn);
            if (livro != null)
            {
                Exemplar? exemplarEmprestado = livro.Exemplares.FirstOrDefault(e => !e.Disponivel());
                if (exemplarEmprestado != null)
                {
                    exemplarEmprestado.devolver();
                    Console.WriteLine("Devolução registrada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não há exemplares emprestados para devolução.");
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao registrar devolução: " + ex.Message);
        }
    }
}
