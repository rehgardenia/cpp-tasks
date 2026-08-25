using PjtVendedores.Controller;
using PjtVendedores.Model;
using PjtVendedores.View;

public static class Program
{
    public static void Main(string[] args)
    {
        Vendedores vendedores = new Vendedores();
        VendedorView view = new VendedorView();
        VendedorController controller = new VendedorController(vendedores, view);

        controller.Iniciar();
    }
}
