namespace ATV5_AGENDA_WFA.Models;


public class Data
{
    private int dia;
    private int mes;
    private int ano;

    public Data()
    {
    }

    public Data(int dia, int mes, int ano)
    {
        setData(dia, mes, ano);
    }

    public int Dia
    {
        get => dia;
        set => dia = value;
    }

    public int Mes
    {
        get => mes;
        set => mes = value;
    }

    public int Ano
    {
        get => ano;
        set => ano = value;
    }

    public void setData(int dia, int mes, int ano)
    {
        this.dia = dia;
        this.mes = mes;
        this.ano = ano;
    }

    public override string ToString()
    {
        return $"{dia:D2}/{mes:D2}/{ano}";
    }
}