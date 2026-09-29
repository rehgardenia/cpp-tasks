using ATV4_AGENDA.Models;

namespace ATV4_AGENDA.Controller;

public class AgendaController
{

    public static void Menu()
    {
        Console.WriteLine("=== AGENDA DE CONTATOS ===");
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("0. Sair");
        Console.WriteLine("1. Adicionar Contato");
        Console.WriteLine("2. Pesquisar Contato");
        Console.WriteLine("3. Alterar Contato");
        Console.WriteLine("4. Remover Contato");
        Console.WriteLine("5. Listar Contatos");
    }

    private static bool TryLerData(string prompt, out Data? data)
    {
        data = null;

        Console.Write(prompt);
        string input = Console.ReadLine() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }

        string[] partes = input.Split('/');
        if (partes.Length != 3)
        {
            Console.WriteLine("Data inválida. Use o formato dd/mm/aaaa.");
            return false;
        }

        if (!int.TryParse(partes[0], out int dia) ||
            !int.TryParse(partes[1], out int mes) ||
            !int.TryParse(partes[2], out int ano))
        {
            Console.WriteLine("Data inválida. Use apenas números.");
            return false;
        }

        if (mes < 1 || mes > 12 || dia < 1 || dia > 31)
        {
            Console.WriteLine("Data inválida. Valores fora do intervalo permitido.");
            return false;
        }

        data = new Data(dia, mes, ano);
        return true;
    }

    public static void AdicionarContato(Contatos contatos)
    {
        Console.WriteLine("=== ADICIONAR CONTATO ===");
        Contato novoContato = new Contato();

        Console.Write("Nome: ");
        string? nome = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("Nome inválido.");
            return;
        }
        novoContato.Nome = nome;

        Console.Write("Email: ");
        string? email = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(email) )
        {
            Console.WriteLine("Email inválido.");
            return;
        }
        novoContato.Email = email;

        if (!TryLerData("Data de Nascimento (dd/mm/aaaa): ", out Data? dataNascimento))
        {
            Console.WriteLine("Data inválida. O contato não foi adicionado.");
            return;
        }

        novoContato.DtNasc = dataNascimento!;

        while (true)
        {
            Telefone telefone = new Telefone();
            Console.Write("Tipo do Telefone (ex: Celular, Residencial, Comercial): ");
            string? tipo = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(tipo))
            {
                Console.WriteLine("Tipo de telefone inválido.");
                return;
            }
            telefone.Tipo = tipo;

            Console.Write("Número do Telefone: ");
            string? numero = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(numero))
            {
                Console.WriteLine("Número inválido.");
                return;
            }
            telefone.Numero = numero;

            Console.Write("É o telefone principal? (s/n): ");
            string? principal = Console.ReadLine();
            telefone.Principal = principal?.ToLower() == "s";

            novoContato.adicionarTelefone(telefone);

            Console.Write("Deseja adicionar outro telefone? (s/n): ");
            if (Console.ReadLine()?.ToLower() != "s")
                break;
        }

        if (contatos.adicionar(novoContato))
        {
            Console.WriteLine("Contato adicionado com sucesso!");
        }
        else
        {
            Console.WriteLine("Erro: Contato já existe na agenda.");
        }
    }

    public static void PesquisarContato(Contatos contatos)
    {
        Console.WriteLine("=== PESQUISAR CONTATO ===");
        Console.Write("Digite o nome do contato: ");
        string nome = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("Nome inválido.");
            return;
        }

        Contato? contatoEncontrado = contatos.Agenda.FirstOrDefault(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        if (contatoEncontrado != null)
        {
            Console.WriteLine("Contato encontrado:");
            Console.WriteLine(contatoEncontrado);
            string telefonePrincipal = contatoEncontrado.getTelefonePrincipal();
            if (!string.IsNullOrEmpty(telefonePrincipal))
            {
                Console.WriteLine($"Telefone Principal: {telefonePrincipal}");
            }
            else
            {
                Console.WriteLine("Nenhum telefone principal cadastrado.");
            }
        }
        else
        {
            Console.WriteLine("Contato não encontrado.");
        }
    }

    public static void AlterarContato(Contatos contatos)
    {
        Console.WriteLine("=== ALTERAR CONTATO ===");
        Console.Write("Digite o nome do contato que deseja alterar: ");
        string nome = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("Nome inválido.");
            return;
        }

        Contato? contatoExistente = contatos.Agenda.FirstOrDefault(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        if (contatoExistente != null)
        {
            Console.WriteLine("Contato encontrado. Insira os novos dados:");

            Console.Write("Novo Nome (deixe em branco para não alterar): ");
            string novoNome = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(novoNome))
            {
            
                    contatoExistente.Nome = novoNome;

            }

            Console.Write("Novo Email (deixe em branco para não alterar): ");
            string novoEmail = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(novoEmail))
            {
              
                    contatoExistente.Email = novoEmail;
           
            }

            if (TryLerData("Nova Data de Nascimento (dd/mm/aaaa) (deixe em branco para não alterar): ", out Data? novaData))
            {
                contatoExistente.DtNasc = novaData!;
            }
        }
        else
        {
            Console.WriteLine("Contato não encontrado.");
        }
    }

    public static void RemoverContato(Contatos contatos)
    {
        Console.WriteLine("=== REMOVER CONTATO ===");
        Console.Write("Digite o nome do contato que deseja remover: ");
        string nome = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("Nome inválido.");
            return;
        }

        Contato? contato = contatos.Agenda.FirstOrDefault(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

        if (contato != null && contatos.remover(contato))
        {
            Console.WriteLine("Contato removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Contato não encontrado.");
        }
    }

    public static void ListarContatos(Contatos contatos)
    {
        Console.WriteLine("=== LISTA DE CONTATOS ===");
        if (contatos.Agenda.Count == 0)
        {
            Console.WriteLine("Nenhum contato cadastrado.");
        }
        else
        {
            foreach (var contato in contatos.Agenda)
            {
                Console.WriteLine(contato);
                string telefonePrincipal = contato.getTelefonePrincipal();
                if (!string.IsNullOrEmpty(telefonePrincipal))
                {
                    Console.WriteLine($"Telefone Principal: {telefonePrincipal}");
                }
                else
                {
                    Console.WriteLine("Nenhum telefone principal cadastrado.");
                }
                Console.WriteLine("-------------------------");
            }
        }
    }
}
