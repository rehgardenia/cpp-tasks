namespace ATV5_AGENDA_WFA.Models;


public class Contatos
{
    private readonly List<Contato> agenda;

    public Contatos()
    {
        agenda = new List<Contato>();
    }

    public List<Contato> Agenda => agenda;

    public bool adicionar(Contato contato)
    {
        if (contato == null || agenda.Contains(contato))
        {
            return false;
        }

        agenda.Add(contato);
        return true;
    }

    public Contato? pesquisar(Contato? contato)
    {
        if (contato == null)
        {
            return null;
        }

        return agenda.FirstOrDefault(c => c.Equals(contato));
    }

    public bool alterar(Contato? contato)
    {
        if (contato == null)
        {
            return false;
        }

        int indice = agenda.FindIndex(c => c.Equals(contato));
        if (indice == -1)
        {
            return false;
        }

        agenda[indice] = contato;
        return true;
    }

    public bool remover(Contato? contato)
    {
        if (contato == null)
        {
            return false;
        }

        return agenda.Remove(contato);
    }
}