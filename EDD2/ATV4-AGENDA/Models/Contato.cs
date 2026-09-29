namespace ATV4_AGENDA.Models;

public class Contato
{
    private string nome;
    private string email;
    private Data dtNasc;
    private List<Telefone> telefones;

    public Contato()
    {
        nome = string.Empty;
        email = string.Empty;
        dtNasc = new Data();
        telefones = new List<Telefone>();
    }

    public Contato(string nome, string email, Data dtNasc)
    {
        this.nome = nome ?? string.Empty;
        this.email = email ?? string.Empty;
        this.dtNasc = dtNasc ?? new Data();
        telefones = new List<Telefone>();
    }

    public string Nome
    {
        get => nome;
        set => nome = value ?? string.Empty;
    }

    public string Email
    {
        get => email;
        set => email = value ?? string.Empty;
    }

    public Data DtNasc
    {
        get => dtNasc;
        set => dtNasc = value ?? new Data();
    }

    public List<Telefone> Telefones
    {
        get => telefones;
        set => telefones = value ?? new List<Telefone>();
    }

    public int getIdade()
    {
        if (dtNasc == null)
        {
            return 0;
        }

        DateTime hoje = DateTime.Today;
        int idade = hoje.Year - dtNasc.Ano;

        if (hoje.Month < dtNasc.Mes || (hoje.Month == dtNasc.Mes && hoje.Day < dtNasc.Dia))
        {
            idade--;
        }

        return idade;
    }

    public void adicionarTelefone(Telefone t)
    {
        if (t == null)
        {
            return;
        }

        telefones.Add(t);
    }

    public string getTelefonePrincipal()
    {
        foreach (Telefone telefone in telefones)
        {
            if (telefone.Principal)
            {
                return telefone.Numero;
            }
        }

        return string.Empty;
    }

    public override string ToString()
    {
        string telefonePrincipal = getTelefonePrincipal();
        return $"Nome: {nome}\nEmail: {email}\nData de nascimento: {dtNasc}\nIdade: {getIdade()}\nTelefone principal: {(string.IsNullOrEmpty(telefonePrincipal) ? "Nenhum" : telefonePrincipal)}";
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj is not Contato outro)
        {
            return false;
        }

        return string.Equals(nome, outro.nome, StringComparison.OrdinalIgnoreCase)
            && string.Equals(email, outro.email, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(nome?.Trim(), email?.Trim());
    }
}