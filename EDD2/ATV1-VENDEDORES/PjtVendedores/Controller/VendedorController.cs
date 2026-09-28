using PjtVendedores.Model;
using PjtVendedores.View;

namespace PjtVendedores.Controller;

public class VendedorController
{
    private Vendedores vendedores;
    private VendedorView view;

    public VendedorController(Vendedores vendedores, VendedorView view)
    {
        this.vendedores = vendedores;
        this.view = view;
    }

    public void Iniciar()
    {
        int opcao;

        do
        {
            view.ExibirMenu();
            opcao = view.LerOpcao();

            switch (opcao)
            {
                case 1:
                    CadastrarVendedor();
                    break;
                case 2:
                    ConsultarVendedor();
                    break;
                case 3:
                    ExcluirVendedor();
                    break;
                case 4:
                    RegistrarVenda();
                    break;
                case 5:
                    ListarVendedores();
                    break;
                default:
                    if (opcao <0 || opcao > 5)
                    {
                        view.ExibirMensagem("Opcao invalida, esta fora do intervalo de 0 a 5.");
                    }
                    break;
            }
        } while (opcao != 0);
    }

    public void CadastrarVendedor()
    {
        if (vendedores.Qtde == 10)
        {
            view.ExibirMensagem("Limite de 10 vendedores atingido.");
            return;
        }

        Console.Write("Nome: ");
        string nome = Console.ReadLine() ?? "";
        Console.Write("Percentual de comissao: ");
        double percComissao = double.Parse(Console.ReadLine() ?? "0");

        Vendedor vendedor = new Vendedor(vendedores.Qtde + 1, nome, percComissao);
        vendedores.addVendedor(vendedor);

        view.ExibirMensagem("Vendedor cadastrado com sucesso.");
    }

    public void ConsultarVendedor()
    {
        Console.Write("ID do vendedor: ");
        int id = int.Parse(Console.ReadLine() ?? "0");
        Vendedor? vendedor = vendedores.searchVendedor(new Vendedor(id));

        if (vendedor == null)
        {
            view.ExibirMensagem("Vendedor nao encontrado.");
        }
        else
        {
            view.ExibirMensagem($"ID: {vendedor.Id}");
            view.ExibirMensagem($"Nome: {vendedor.Nome}");
            view.ExibirMensagem($"Total das vendas: {vendedor.valorVendas():C2}");
            view.ExibirMensagem($"Comissao devida: {vendedor.valorComissao():C2}");
            view.ExibirMensagem($"Media das vendas diarias: {vendedor.valorMedioVendasDiarias():C2}");
        }
    }

    public void ExcluirVendedor()
    {
        Console.Write("ID do vendedor: ");
        int id = int.Parse(Console.ReadLine() ?? "0");
        Vendedor? vendedor = vendedores.searchVendedor(new Vendedor(id));

        if (vendedor == null)
        {
            view.ExibirMensagem("Vendedor nao encontrado.");
        }
        else if (vendedor.possuiVenda())
        {
            view.ExibirMensagem("Vendedor possui vendas e nao pode ser excluido.");
        }
        else
        {
            vendedores.delVendedor(vendedor);
            view.ExibirMensagem("Vendedor excluido com sucesso.");
        }
    }

    public void RegistrarVenda()
    {
        Console.Write("ID do vendedor: ");
        int id = int.Parse(Console.ReadLine() ?? "0");
        Vendedor? vendedor = vendedores.searchVendedor(new Vendedor(id));

        if (vendedor == null)
        {
            view.ExibirMensagem("Vendedor nao encontrado.");
            return;
        }

        Console.Write("Dia da venda (1 a 31): ");
        int dia = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Quantidade de vendas: ");
        int qtde = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Valor total das vendas: ");
        double valor = double.Parse(Console.ReadLine() ?? "0");

        vendedor.registrarVenda(dia, new Venda(qtde, valor));
        view.ExibirMensagem("Venda registrada com sucesso.");
    }

    public void ListarVendedores()
    {
        for (int i = 0; i < vendedores.Qtde; i++)
        {
            Vendedor vendedor = vendedores.OsVendedores[i];

            view.ExibirMensagem($"ID: {vendedor.Id} | Nome: {vendedor.Nome} | " +
                $"Total vendas: {vendedor.valorVendas():C2} | " +
                $"Comissao: {vendedor.valorComissao():C2}");
        }

        view.ExibirMensagem($"Total das vendas: {vendedores.valorVendas():C2}");
        view.ExibirMensagem($"Total das comissoes: {vendedores.valorComissao():C2}");
    }
}
