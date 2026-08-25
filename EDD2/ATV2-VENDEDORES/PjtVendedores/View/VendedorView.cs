namespace PjtVendedores.View;

public class VendedorView
{
    public void ExibirMenu()
    {
        Console.WriteLine("\n0 - Sair");
        Console.WriteLine("1 - Cadastrar vendedor");
        Console.WriteLine("2 - Consultar vendedor");
        Console.WriteLine("3 - Excluir vendedor");
        Console.WriteLine("4 - Registrar venda");
        Console.WriteLine("5 - Listar vendedores");
    }

    public int LerOpcao()
    {
        try{
            Console.Write("Opcao: ");
            int op = int.Parse(Console.ReadLine() ?? "0");
            return op;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Opção Inválida!");
            return -1;
        }
    
    }

    public void ExibirMensagem(string mensagem)
    {
        Console.WriteLine(mensagem);
    }
}
