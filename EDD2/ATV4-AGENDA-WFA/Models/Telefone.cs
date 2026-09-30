namespace ATV4_AGENDA.Models;

public class Telefone
{
    private string tipo;
    private string numero;
    private bool principal;

    public Telefone()
    {
        tipo = string.Empty;
        numero = string.Empty;
    }

    public Telefone(string tipo, string numero, bool principal)
    {
        this.tipo = tipo;
        this.numero = numero;
        this.principal = principal;
    }

    public string Tipo
    {
        get => tipo;
        set => tipo = value ?? string.Empty;
    }

    public string Numero
    {
        get => numero;
        set => numero = value ?? string.Empty;
    }

    public bool Principal
    {
        get => principal;
        set => principal = value;
    }
}