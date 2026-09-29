using ATV3_RESTAURANTE.Models;
using ATV3_RESTAURANTE.Controllers;

class Program
{
    public static void Main(string[] args)
    {
        Restaurante restaurante = new Restaurante();
        Console.WriteLine("Bem-vindo ao Restaurante da Kiki!");
        while (true)
        {
            RestauranteController.Menu();
            if (!int.TryParse(Console.ReadLine(), out int op))
            {
                Console.WriteLine("Opção inválida.");
                return;
            }
            switch (op)
            {
                case 0:
                    Console.WriteLine("Saindo...");
                    return;
                case 1:
                    // Criar novo Pedido
                    RestauranteController.NovoPedido(restaurante);
                    break;
                case 2:
                    // Adicionar Item ao Pedido
                    RestauranteController.AdicionarItem(restaurante);
                    break;
                case 3:
                    // Remover Item do Pedido
                    RestauranteController.RemoverItem(restaurante);
                    break;
                case 4:
                    // Consultar Pedido
                    RestauranteController.ConsultarPedido(restaurante);
                    break;
                case 5:
                    // Cancelar Pedido
                    RestauranteController.CancelarPedido(restaurante);
                    break;
                case 6:
                    // Listar todos os Pedidos
                    RestauranteController.ListarPedidos(restaurante);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}