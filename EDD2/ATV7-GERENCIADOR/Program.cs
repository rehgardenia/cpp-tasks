using ATV7_GERENCIADOR.Controller;
using ATV7_GERENCIADOR.Models;

namespace ATV7_GERENCIADOR;

public class Program
{
    public static void adicionarProjeto(ProjetosController projetosController)
    {
        try
        {
            Console.Write("Digite o nome do projeto: ");
            string nomeProjeto = Console.ReadLine() ?? string.Empty;

            Projeto projeto = new Projeto { Nome = nomeProjeto };
            if (projetosController.AdicionarProjeto(projeto))
            {
                Console.WriteLine($"Projeto '{nomeProjeto}' adicionado com sucesso.");
            }
            else
            {
                Console.WriteLine($"Falha ao adicionar o projeto '{nomeProjeto}'. Ele pode já existir.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao adicionar o projeto: {ex.Message}");
        }
    }
    public static void pesquisarProjeto(ProjetosController projetosController)
    {
        try
        {
            Console.Write("Digite o nome do projeto a ser pesquisado: ");
            string nomeProjeto = Console.ReadLine() ?? string.Empty;

            Projeto? projeto = projetosController.BuscarProjeto(nomeProjeto);
            if (projeto != null)
            {
                Console.WriteLine($"Projeto encontrado: {projeto.Nome}");
                Console.WriteLine($"Total de tarefas abertas: {projeto.TotalAbertas()}");
                Console.WriteLine($"Total de tarefas concluídas: {projeto.TotalConcluidas()}");
            }
            else
            {
                Console.WriteLine($"Projeto '{nomeProjeto}' não encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao pesquisar o projeto: {ex.Message}");
        }
    }
    public static void removerProjeto(ProjetosController projetosController)
    {
        try
        {
            Console.Write("Digite o nome do projeto a ser removido: ");
            string nomeProjeto = Console.ReadLine() ?? string.Empty;

            Projeto? projeto = projetosController.BuscarProjeto(nomeProjeto);
            if (projeto != null)
            {
                if (projeto.Tarefas.Count == 0)
                {
                    if (projetosController.RemoverProjeto(projeto))
                    {
                        Console.WriteLine($"Projeto '{nomeProjeto}' removido com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine($"Falha ao remover o projeto '{nomeProjeto}'.");
                    }
                }
                else
                {
                    Console.WriteLine($"Não é possível remover o projeto '{nomeProjeto}' porque ele possui tarefas.");
                }
            }
            else
            {
                Console.WriteLine($"Projeto '{nomeProjeto}' não encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao remover o projeto: {ex.Message}");
        }
    }
    public static void adicionarTarefaEmProjeto(ProjetosController projetosController)
    {
        try
        {
            Console.Write("Digite o nome do projeto para adicionar a tarefa: ");
            string nomeProjeto = Console.ReadLine() ?? string.Empty;

            Projeto? projeto = projetosController.BuscarProjeto(nomeProjeto);
            if (projeto != null)
            {
                Console.Write("Digite o título da tarefa: ");
                string tituloTarefa = Console.ReadLine() ?? string.Empty;

                Console.Write("Digite a descrição da tarefa: ");
                string descricaoTarefa = Console.ReadLine() ?? string.Empty;

                Console.Write("Digite a prioridade da tarefa (1- alta, 2- média, 3- baixa): ");
                int prioridadeTarefa;
                while (!int.TryParse(Console.ReadLine(), out prioridadeTarefa) || prioridadeTarefa < 1 || prioridadeTarefa > 3)
                {
                    Console.Write("Prioridade inválida. Digite novamente (1- alta, 2- média, 3- baixa): ");
                }

                Tarefa tarefa = new Tarefa
                {
                    Titulo = tituloTarefa,
                    Descricao = descricaoTarefa,
                    Prioridade = prioridadeTarefa,
                    Status = "Pendente"
                };

                projeto.AdicionarTarefa(tarefa);
                Console.WriteLine($"Tarefa '{tituloTarefa}' adicionada ao projeto '{nomeProjeto}'.");
            }
            else
            {
                Console.WriteLine($"Projeto '{nomeProjeto}' não encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao adicionar a tarefa: {ex.Message}");
        }
    }
    public static void concluirTarefaEmProjeto(ProjetosController projetosController)
    {
        try
        {
            Console.Write("Digite o nome do projeto para concluir a tarefa: ");
            string nomeProjeto = Console.ReadLine() ?? string.Empty;

            Projeto? projeto = projetosController.BuscarProjeto(nomeProjeto);
            if (projeto != null)
            {
                Console.Write("Digite o ID da tarefa a ser concluída: ");
                int idTarefa;
                while (!int.TryParse(Console.ReadLine(), out idTarefa))
                {
                    Console.Write("ID inválido. Digite novamente: ");
                }

                Tarefa? tarefa = projeto.BuscarTarefaPorId(idTarefa);
                if (tarefa != null)
                {
                    tarefa.Concluir();
                    Console.WriteLine($"Tarefa '{tarefa.Titulo}' concluída no projeto '{nomeProjeto}'.");
                }
                else
                {
                    Console.WriteLine($"Tarefa com ID '{idTarefa}' não encontrada no projeto '{nomeProjeto}'.");
                }
            }
            else
            {
                Console.WriteLine($"Projeto '{nomeProjeto}' não encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao concluir a tarefa: {ex.Message}");
        }
    }
    public static void cancelarTarefaEmProjeto(ProjetosController projetosController)
    {
        try
        {
            Console.Write("Digite o nome do projeto para cancelar a tarefa: ");
            string nomeProjeto = Console.ReadLine() ?? string.Empty;

            Projeto? projeto = projetosController.BuscarProjeto(nomeProjeto);
            if (projeto != null)
            {
                Console.Write("Digite o ID da tarefa a ser cancelada: ");
                int idTarefa;
                while (!int.TryParse(Console.ReadLine(), out idTarefa))
                {
                    Console.Write("ID inválido. Digite novamente: ");
                }

                Tarefa? tarefa = projeto.BuscarTarefaPorId(idTarefa);
                if (tarefa != null)
                {
                    tarefa.Cancelar();
                    Console.WriteLine($"Tarefa '{tarefa.Titulo}' cancelada no projeto '{nomeProjeto}'.");
                }
                else
                {
                    Console.WriteLine($"Tarefa com ID '{idTarefa}' não encontrada no projeto '{nomeProjeto}'.");
                }
            }
            else
            {
                Console.WriteLine($"Projeto '{nomeProjeto}' não encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao cancelar a tarefa: {ex.Message}");
        }
    }
    public static void reabrirTarefaEmProjeto(ProjetosController projetosController)
    {
        try
        {
            Console.Write("Digite o nome do projeto para reabrir a tarefa: ");
            string nomeProjeto = Console.ReadLine() ?? string.Empty;

            Projeto? projeto = projetosController.BuscarProjeto(nomeProjeto);
            if (projeto != null)
            {
                Console.Write("Digite o ID da tarefa a ser reaberta: ");
                int idTarefa;
                while (!int.TryParse(Console.ReadLine(), out idTarefa))
                {
                    Console.Write("ID inválido. Digite novamente: ");
                }

                Tarefa? tarefa = projeto.BuscarTarefaPorId(idTarefa);
                if (tarefa != null)
                {
                    tarefa.Reabrir();
                    Console.WriteLine($"Tarefa '{tarefa.Titulo}' reaberta no projeto '{nomeProjeto}'.");
                }
                else
                {
                    Console.WriteLine($"Tarefa com ID '{idTarefa}' não encontrada no projeto '{nomeProjeto}'.");
                }
            }
            else
            {
                Console.WriteLine($"Projeto '{nomeProjeto}' não encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao reabrir a tarefa: {ex.Message}");
        }
    }
    public static void listarTarefasDeUmProjeto(ProjetosController projetosController)
    {
        try
        {
            Console.Write("Digite o nome do projeto para listar as tarefas: ");
            string nomeProjeto = Console.ReadLine() ?? string.Empty;

            Projeto? projeto = projetosController.BuscarProjeto(nomeProjeto);
            if (projeto != null)
            {
                List<Tarefa> tarefas = projeto.Tarefas;
                if (tarefas.Count > 0)
                {
                    Console.WriteLine($"Tarefas do projeto '{nomeProjeto}':");
                    foreach (var tarefa in tarefas)
                    {
                        Console.WriteLine($"ID: {tarefa.Id}, Título: {tarefa.Titulo}, Status: {tarefa.Status}, Prioridade: {tarefa.Prioridade}");
                    }
                }
                else
                {
                    Console.WriteLine($"Não há tarefas no projeto '{nomeProjeto}'.");
                }
            }
            else
            {
                Console.WriteLine($"Projeto '{nomeProjeto}' não encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao listar tarefas do projeto: {ex.Message}");
        }
    }
    public static void filtrarEmUmProjeto(ProjetosController projetosController)
    {
        try
        {
            Console.Write("Digite o nome do projeto para filtrar as tarefas: ");
            string nomeProjeto = Console.ReadLine() ?? string.Empty;

            Projeto? projeto = projetosController.BuscarProjeto(nomeProjeto);
            if (projeto != null)
            {
                Console.WriteLine("Escolha o critério de filtro:");
                Console.WriteLine("1. Filtrar por status");
                Console.WriteLine("2. Filtrar por prioridade");
                string criterio = Console.ReadLine() ?? string.Empty;

                List<Tarefa> tarefasFiltradas = new List<Tarefa>();

                if (criterio == "1")
                {
                    Console.Write("Digite o status para filtrar (Pendente, Concluída, Cancelada): ");
                    string status = Console.ReadLine() ?? string.Empty;
                    tarefasFiltradas = projeto.TarefasPorStatus(status);
                }
                else if (criterio == "2")
                {
                    Console.Write("Digite a prioridade para filtrar (1- alta, 2- média, 3- baixa): ");
                    int prioridade;
                    while (!int.TryParse(Console.ReadLine(), out prioridade) || prioridade < 1 || prioridade > 3)
                    {
                        Console.Write("Prioridade inválida. Digite novamente (1- alta, 2- média, 3- baixa): ");
                    }
                    tarefasFiltradas = projeto.TarefasPorPrioridade(prioridade);
                }
                else
                {
                    Console.WriteLine("Critério de filtro inválido.");
                    return;
                }

                if (tarefasFiltradas.Count > 0)
                {
                    Console.WriteLine($"Tarefas filtradas do projeto '{nomeProjeto}':");
                    foreach (var tarefa in tarefasFiltradas)
                    {
                        Console.WriteLine($"ID: {tarefa.Id}, Título: {tarefa.Titulo}, Status: {tarefa.Status}, Prioridade: {tarefa.Prioridade}");
                    }
                }
                else
                {
                    Console.WriteLine($"Não há tarefas que correspondam ao filtro no projeto '{nomeProjeto}'.");
                }
            }
            else
            {
                Console.WriteLine($"Projeto '{nomeProjeto}' não encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao filtrar tarefas no projeto: {ex.Message}");
        }
    }
    public static void filtrarEmTodosOsProjetos(ProjetosController projetosController)
    {
        try
        {
            Console.WriteLine("Escolha o critério de filtro:");
            Console.WriteLine("1. Filtrar por status");
            Console.WriteLine("2. Filtrar por prioridade");
            string criterio = Console.ReadLine() ?? string.Empty;

            List<Tarefa> tarefasFiltradas = new List<Tarefa>();

            if (criterio == "1")
            {
                Console.Write("Digite o status para filtrar (Pendente, Concluída, Cancelada): ");
                string status = Console.ReadLine() ?? string.Empty;
                foreach (var projeto in projetosController.ListarProjetos())
                {
                    tarefasFiltradas.AddRange(projeto.TarefasPorStatus(status));
                }
            }
            else if (criterio == "2")
            {
                Console.Write("Digite a prioridade para filtrar (1- alta, 2- média, 3- baixa): ");
                int prioridade;
                while (!int.TryParse(Console.ReadLine(), out prioridade) || prioridade < 1 || prioridade > 3)
                {
                    Console.Write("Prioridade inválida. Digite novamente (1- alta, 2- média, 3- baixa): ");
                }
                foreach (var projeto in projetosController.ListarProjetos())
                {
                    tarefasFiltradas.AddRange(projeto.TarefasPorPrioridade(prioridade));
                }
            }
            else
            {
                Console.WriteLine("Critério de filtro inválido.");
                return;
            }

            if (tarefasFiltradas.Count > 0)
            {
                Console.WriteLine("Tarefas filtradas em todos os projetos:");
                foreach (var tarefa in tarefasFiltradas)
                {
                    Console.WriteLine($"ID: {tarefa.Id}, Título: {tarefa.Titulo}, Status: {tarefa.Status}, Prioridade: {tarefa.Prioridade}");
                }
            }
            else
            {
                Console.WriteLine("Não há tarefas que correspondam ao filtro em todos os projetos.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao filtrar tarefas em todos os projetos: {ex.Message}");
        }
    }
    public static void resumoGeral(ProjetosController projetosController)
    {
        List<Projeto> projetos = projetosController.ListarProjetos();
        int totalProjetos = projetos.Count;
        int totalTarefasAbertas = 0;
        int totalTarefasConcluidas = 0;
        int totalTarefasCanceladas = 0;

        foreach (var projeto in projetos)
        {
            totalTarefasAbertas += projeto.TotalAbertas();
            totalTarefasConcluidas += projeto.TotalConcluidas();
            totalTarefasCanceladas += projeto.Tarefas.Count(t => t.Status == "Cancelada");
        }

        double percentualConcluidas = totalTarefasAbertas > 0 ? (double)totalTarefasConcluidas / totalTarefasAbertas * 100 : 0;

        Console.WriteLine("Resumo Geral:");
        Console.WriteLine($"Total de projetos: {totalProjetos}");
        Console.WriteLine($"Total de tarefas abertas: {totalTarefasAbertas}");
        Console.WriteLine($"Total de tarefas concluídas: {totalTarefasConcluidas}");
        Console.WriteLine($"Total de tarefas canceladas: {totalTarefasCanceladas}");
        Console.WriteLine($"Percentual de tarefas concluídas em relação às abertas: {percentualConcluidas:F2}%");
    }

    public static void Menu()
    {
        Console.WriteLine("Gerenciador de Tarefas");
        Console.WriteLine("----------------------");
        Console.WriteLine("Selecione uma opção:");
        Console.WriteLine("0. Sair");
        Console.WriteLine("1. Adicionar Projeto");
        Console.WriteLine("2. Pesquisar projeto (mostrar tarefas por status e totais)");
        Console.WriteLine("3. Remover projeto (apenas se sem tarefas)");
        Console.WriteLine("4. Adicionar tarefa em projeto");
        Console.WriteLine("5. Concluir tarefa");
        Console.WriteLine("6. Cancelar tarefa");
        Console.WriteLine("7. Reabrir tarefa");
        Console.WriteLine("8. Listar tarefas de um projeto");
        Console.WriteLine("9. Filtrar tarefas por status ou prioridade em um projeto");
        Console.WriteLine("10. Filtrar tarefas por status ou prioridade em todos os projetos");
        Console.WriteLine("11. Resumo geral: qtde de projetos, tarefas abertas/fechadas/canceladas, % concluídas em relação às abertas");
    }
    public static void Main(string[] args)
    {
        ProjetosController projetosController = new ProjetosController();

        while (true)
        {
            Menu();
            Console.Write("Opção: ");
            string opcao = Console.ReadLine() ?? string.Empty;

            switch (opcao)
            {
                case "0":
                    Console.WriteLine("Saindo do programa...");
                    return;
                case "1":
                    adicionarProjeto(projetosController);
                    break;
                case "2":
                    pesquisarProjeto(projetosController);
                    break;
                case "3":
                    removerProjeto(projetosController);
                    break;
                case "4":
                    adicionarTarefaEmProjeto(projetosController);
                    break;
                case "5":
                    concluirTarefaEmProjeto(projetosController);
                    break;
                case "6":
                    cancelarTarefaEmProjeto(projetosController);
                    break;
                case "7":
                    reabrirTarefaEmProjeto(projetosController);
                    break;
                case "8":
                    listarTarefasDeUmProjeto(projetosController);
                    break;
                case "9":
                    filtrarEmUmProjeto(projetosController);
                    break;
                case "10":
                    filtrarEmTodosOsProjetos(projetosController);
                    break;
                case "11":
                    resumoGeral(projetosController);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}