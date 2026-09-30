using ATV6_BIBLIOTECA.Models;
using ATV6_BIBLIOTECA.Controllers;
namespace ATV6_BIBLIOTECA;
class Program
{
    static void Main(string[] args)
    {
        Livros livros = new Livros();
        BibliotecaController bibliotecaController = new BibliotecaController();

        while (true)
        {
            bibliotecaController.Menu();
            string opcao = Console.ReadLine() ?? "";

            switch (opcao)
            {
                case "0":
                    return;
                case "1":
                    bibliotecaController.AdicionarLivro(livros);
                    break;
                case "2":
                    bibliotecaController.PesquisarLivroSintetico(livros);
                    break;
                case "3":
                    bibliotecaController.PesquisarLivroAnalitico(livros);
                    break;
                case "4":
                    bibliotecaController.AdicionarExemplar(livros);
                    break;
                case "5":
                    bibliotecaController.RegistrarEmprestimo(livros);
                    break;
                case "6":
                    bibliotecaController.RegistrarDevolucao(livros);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}