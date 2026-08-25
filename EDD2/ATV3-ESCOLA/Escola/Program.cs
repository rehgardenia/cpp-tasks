using Escola.Controller;
using Escola.Model;
using Escola.View;

public class Program
{
    public static void Main()
    {
        EscolaModel escola = new EscolaModel();
        EscolaView view = new EscolaView();
        EscolaController controller = new EscolaController(escola, view);
        int opcao = -1;

        while (opcao != 0)
        {
            Console.Clear();
            opcao = view.ExibirMenu();

            switch (opcao)
            {
                case 0:
                    view.ExibirMensagem("Saindo do programa...");
                    break;
                case 1:
                    controller.AdicionarCurso();
                    break;
                case 2:
                    controller.PesquisarCurso();
                    break;
                case 3:
                    controller.RemoverCurso();
                    break;
                case 4:
                    controller.AdicionarDisciplina();
                    break;
                case 5:
                    controller.PesquisarDisciplina();
                    break;
                case 6:
                    controller.RemoverDisciplina();
                    break;
                case 7:
                    controller.MatricularAluno();
                    break;
                case 8:
                    controller.DesmatricularAluno();
                    break;
                case 9:
                    controller.PesquisarAluno();
                    break;
            }

            if (opcao != 0)
            {
                Console.WriteLine("\nPressione uma tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
