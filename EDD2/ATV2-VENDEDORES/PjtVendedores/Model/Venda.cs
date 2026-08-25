namespace PjtVendedores.Model;

public class Venda
{
    private int qtde;
    private double valor;

    public Venda(int qtde, double valor)
    {
        this.qtde = qtde;
        this.valor = valor;
    }

    public int Qtde
    {
        get { return qtde; }
    }

    public double Valor
    {
        get { return valor; }
    }

    public double valorMedio()
    {
        if (qtde == 0)
            return 0;

        return valor / qtde;
    }
}