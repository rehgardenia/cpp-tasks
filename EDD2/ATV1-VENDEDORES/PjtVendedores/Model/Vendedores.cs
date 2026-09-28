namespace PjtVendedores.Model;

public class Vendedores
{
    private Vendedor[] osVendedores;
    private int max;
    private int qtde;

    public Vendedores()
    {
        this.max = 10;
        this.qtde = 0;

        osVendedores = new Vendedor[max];
    }

    public int Qtde
    {
        get { return qtde; }
    }

    public bool EstaCheio
    {
        get { return qtde >= max; }
    }

    public Vendedor[] OsVendedores
    {
        get { return osVendedores; }
    }

    public bool addVendedor(Vendedor v)
    {
        if (qtde >= max)
        {
            return false;
        }

        if (searchVendedor(v) != null)
        {
            return false;
        }

        osVendedores[qtde] = v;

        qtde++;

        return true;
    }

    public bool delVendedor(Vendedor v)
    {
        for (int i = 0; i < qtde; i++)
        {
            if (osVendedores[i].Id == v.Id)
            {
                if (osVendedores[i].possuiVenda())
                {
                    return false;
                }

                for (int j = i; j < qtde - 1; j++)
                {
                    osVendedores[j] = osVendedores[j + 1];
                }

                osVendedores[qtde - 1] = null!;

                qtde--;

                return true;
            }
        }

        return false;
    }

    public Vendedor? searchVendedor(Vendedor v)
    {
        for (int i = 0; i < qtde; i++)
        {
            if (osVendedores[i].Id == v.Id)
            {
                return osVendedores[i];
            }
        }

        return null;
    }

    public double valorVendas()
    {
        double total = 0;

        for (int i = 0; i < qtde; i++)
        {
            total += osVendedores[i].valorVendas();
        }

        return total;
    }

    public double valorComissao()
    {
        double total = 0;

        for (int i = 0; i < qtde; i++)
        {
            total += osVendedores[i].valorComissao();
        }

        return total;
    }
}
