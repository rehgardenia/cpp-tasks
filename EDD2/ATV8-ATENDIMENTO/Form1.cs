namespace ATV8_ATENDIMENTO;

public partial class Form1 : Form
{
    private readonly Models.Senhas senhas = new();
    private readonly Models.Guiches guiches = new();

    public Form1()
    {
        InitializeComponent();
        btnGerar.Click += (_, _) => GerarSenhas();
        btnAdicionarGuiche.Click += (_, _) => AdicionarGuiches();
        btnChamar.Click += (_, _) => ChamarSenha();
        cmbGuicheHistorico.SelectedIndexChanged += (_, _) => AtualizarAtendimentos();
        cmbGuicheHistorico.Items.Add("Todos");
        cmbGuicheHistorico.SelectedIndex = 0;
    }

    private void GerarSenhas()
    {
        senhas.gerar();

        lblProximoValor.Text = senhas.proximoAtendimento.ToString();
        AtualizarSenhas();
    }

    private void AdicionarGuiches()
    {
        int primeiroId = guiches.guiches.Count == 0
            ? 1
            : guiches.guiches.Max(g => g.Id) + 1;

        for (int i = 0; i < (int)nudQuantidadeGuiches.Value; i++)
            guiches.adicionar(new Models.Guiche(primeiroId + i));

        cmbGuiche.Items.Clear();
        cmbGuicheHistorico.Items.Clear();
        cmbGuicheHistorico.Items.Add("Todos");
        foreach (var guiche in guiches.guiches)
        {
            string nome = $"Guichê {guiche.Id}";
            cmbGuiche.Items.Add(nome);
            cmbGuicheHistorico.Items.Add(nome);
        }

        if (cmbGuiche.Items.Count > 0)
            cmbGuiche.SelectedIndex = 0;
        cmbGuicheHistorico.SelectedIndex = 0;

        lblTotalGuiches.Text = guiches.guiches.Count.ToString();
    }

    private void ChamarSenha()
    {
        if (cmbGuiche.SelectedIndex < 0)
        {
            MessageBox.Show("Cadastre e selecione um guichê.", "Guichê não selecionado",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var guiche = guiches.guiches[cmbGuiche.SelectedIndex];
        if (!guiche.chamar(senhas.filaSenhas))
        {
            MessageBox.Show("Não há senhas aguardando atendimento.", "Fila vazia",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        AtualizarSenhas();
        AtualizarAtendimentos();
    }

    private void AtualizarSenhas()
    {
        dgvSenhas.Rows.Clear();
        foreach (var senha in senhas.filaSenhas)
            dgvSenhas.Rows.Add(senha.Id, senha.dataGerac.ToShortDateString(),
                senha.horaGerac.ToShortTimeString(), "Aguardando");
    }

    private void AtualizarAtendimentos()
    {
        dgvAtendimentos.Rows.Clear();
        int indice = cmbGuicheHistorico.SelectedIndex;
        if (indice < 0)
            return;

        IEnumerable<Models.Guiche> guichesFiltrados = indice == 0
            ? guiches.guiches
            : guiches.guiches.Where(g => g.Id == guiches.guiches[indice - 1].Id);

        foreach (var guiche in guichesFiltrados)
        {
            foreach (var senha in guiche.atendimentos)
                dgvAtendimentos.Rows.Add(senha.Id, $"Guichê {guiche.Id}",
                    senha.dataGerac.ToShortDateString(), senha.horaGerac.ToShortTimeString(),
                    senha.dataAtend.ToShortDateString(), senha.horaAtend.ToShortTimeString());
        }
    }
}
