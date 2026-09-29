using ATV3_RESTAURANTE.Models;

namespace ATV3_RESTAURANTE.Controllers
{
    public class RestauranteController
    {
        public static void Menu()
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Criar novo Pedido");
            Console.WriteLine("2. Adicionar Item ao Pedido");
            Console.WriteLine("3. Remover Item do Pedido");
            Console.WriteLine("4. Consultar Pedido(id, cliente, itens e total)");
            Console.WriteLine("5. Cancelar Pedido");
            Console.WriteLine("6. Listar todos os Pedidos (id, valor total, soma geral do dia)");
        }

        public static void NovoPedido(Restaurante restaurante)
        {
            Pedido novoPedido = new Pedido();
            Console.WriteLine("Digite o ID do pedido:");
            if (!int.TryParse(Console.ReadLine(), out int pedidoId))
            {
                Console.WriteLine("ID inválido.");
                return;
            }
            else if (restaurante.buscarPedido(pedidoId) != null)
            {
                Console.WriteLine("Já existe um pedido com esse ID.");
                return;
            }
            else
            {
                novoPedido.Id = pedidoId;
                Console.WriteLine("Digite o nome do cliente:");
                novoPedido.Client = Console.ReadLine() ?? string.Empty;

                Console.WriteLine(restaurante.novoPedido(novoPedido) ? "Pedido criado com sucesso!" : "Não foi possível criar o pedido. Limite de pedidos atingido.");
            }
        }

        public static void AdicionarItem(Restaurante restaurante)
        {
            Console.WriteLine("Digite o ID do pedido para adicionar o item:");
            if (!int.TryParse(Console.ReadLine(), out int pedidoId))
            {
                Console.WriteLine("ID inválido.");
                return;
            }
            Pedido? pedido = restaurante.buscarPedido(pedidoId);

            if (pedido != null)
            {
                Item novoItem = new Item();
                Console.WriteLine("Digite o ID do item:");
                if (!int.TryParse(Console.ReadLine(), out int novoItemId))
                {
                    Console.WriteLine("ID inválido.");
                    return;
                }
                novoItem.Id = novoItemId;
                Console.WriteLine("Digite a descrição do item:");
                novoItem.Description = Console.ReadLine() ?? string.Empty;
                Console.WriteLine("Digite o preço do item:");
                if (!decimal.TryParse(Console.ReadLine(), out decimal preco))
                {
                    Console.WriteLine("Preço inválido.");
                    return;
                }
                novoItem.Price = preco;

                Console.WriteLine(pedido.addItem(novoItem) ? "Item adicionado com sucesso!" : "Não foi possível adicionar o item. Limite de itens atingido.");
            }
            else
            {
                Console.WriteLine("Pedido não encontrado.");
            }
        }

        public static void RemoverItem(Restaurante restaurante)
        {
            Console.WriteLine("Digite o ID do pedido para remover o item:");
            if (!int.TryParse(Console.ReadLine(), out int pedidoId))
            {
                Console.WriteLine("ID inválido.");
                return;
            }
            Pedido? pedido = restaurante.buscarPedido(pedidoId);

            if (pedido != null)
            {
                Console.WriteLine("Digite o ID do item a ser removido:");
                if (!int.TryParse(Console.ReadLine(), out int itemId))
                {
                    Console.WriteLine("ID inválido.");
                    return;
                }
                Item? itemToRemove = pedido.Items.FirstOrDefault(i => i.Id == itemId);

                Console.WriteLine(itemToRemove != null && pedido.removerItem(itemToRemove) ? "Item removido com sucesso!" : "Item não encontrado ou não foi possível remover.");
            }
            else
            {
                Console.WriteLine("Pedido não encontrado.");
            }
        }

        public static void ConsultarPedido(Restaurante restaurante)
        {
            Console.WriteLine("Digite o ID do pedido para consultar:");
            if (!int.TryParse(Console.ReadLine(), out int pedidoId))
            {
                Console.WriteLine("ID inválido.");
                return;
            }
            Pedido? pedido = restaurante.buscarPedido(pedidoId);

            if (pedido != null)
            {
                Console.WriteLine(pedido.dadosPedido());
                Console.WriteLine($"Total do pedido: {pedido.calcularTotal():C}");
            }
            else
            {
                Console.WriteLine("Pedido não encontrado.");
            }
        }

        public static void CancelarPedido(Restaurante restaurante)
        {
            Console.WriteLine("Digite o ID do pedido para cancelar:");
            if (!int.TryParse(Console.ReadLine(), out int pedidoId))
            {
                Console.WriteLine("ID inválido.");
                return;
            }
            Pedido? pedido = restaurante.buscarPedido(pedidoId);

            Console.WriteLine(pedido != null && restaurante.removerPedido(pedido) ? "Pedido cancelado com sucesso!" : "Pedido não encontrado ou não foi possível cancelar.");
        }

        public static void ListarPedidos(Restaurante restaurante)
        {
            if (restaurante.Pedidos.Count == 0)
            {
                Console.WriteLine("Nenhum pedido registrado.");
                return;
            }

            decimal somaGeral = 0;
            foreach (var pedido in restaurante.Pedidos)
            {
                decimal totalPedido = pedido.calcularTotal();
                somaGeral += totalPedido;
                Console.WriteLine($"Pedido ID: {pedido.Id}, Total: {totalPedido:C}");
            }
            Console.WriteLine($"Soma geral do dia: {somaGeral:C}");
        }
    }
}
