namespace PjtVendedores.Model;

public class Vendedor
{
    private int id;
    private string nome;
    private double percComissao;
    private Venda[] asVendas;

    public Vendedor(int id, string nome, double percComissao)
    {
        this.id = id;
        this.nome = nome;
        this.percComissao = percComissao;

        asVendas = new Venda[31];
    }

    public Vendedor(int id) : this(id, string.Empty, 0)
    {
    }

    public int Id
    {
        get { return id; }
    }

    public string Nome
    {
        get { return nome; }
    }

    public double PercComissao
    {
        get { return percComissao; }
    }

    public Venda[] AsVendas
    {
        get { return asVendas; }
    }

    public void registrarVenda(int dia, Venda venda)
    {
        if (dia >= 1 && dia <= 31)
        {
            asVendas[dia - 1] = venda;
        }
    }

    public double valorVendas()
    {
        double total = 0;

        for (int i = 0; i < asVendas.Length; i++)
        {
            if (asVendas[i] != null)
            {
                total += asVendas[i].Valor;
            }
        }

        return total;
    }

    public double valorComissao()
    {
        return valorVendas() * percComissao / 100;
    }

    public double valorMedioVendasDiarias()
    {
        int diasComVenda = 0;

        for (int i = 0; i < asVendas.Length; i++)
        {
            if (asVendas[i] != null)
            {
                diasComVenda++;
            }
        }

        return diasComVenda == 0 ? 0 : valorVendas() / diasComVenda;
    }

    public bool possuiVenda()
    {
        for (int i = 0; i < asVendas.Length; i++)
        {
            if (asVendas[i] != null)
            {
                return true;
            }
        }

        return false;
    }
}
