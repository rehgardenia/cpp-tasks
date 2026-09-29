using ATV4_AGENDA.Models;
using ATV4_AGENDA.Controller;
class Program
{
    static void Main(string[] args)
    {
       Contatos contatos = new Contatos();
        int opcao;

        do
        {
            AgendaController.Menu();
            Console.Write("Opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida. Digite um número.");
                Console.WriteLine();
                continue;
            }

            switch (opcao)
            {
                case 1:
                    AgendaController.AdicionarContato(contatos);
                    break;
                case 2:
                    AgendaController.PesquisarContato(contatos);
                    break;
                case 3:
                    AgendaController.AlterarContato(contatos);
                    break;
                case 4:
                    AgendaController.RemoverContato(contatos);
                    break;
                case 5:
                    AgendaController.ListarContatos(contatos);
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            Console.WriteLine();
        } while (opcao != 0);
    }
}