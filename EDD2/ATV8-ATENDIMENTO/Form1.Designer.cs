
#nullable enable

using System.Drawing;
using System.Windows.Forms;

namespace ATV8_ATENDIMENTO
{
    partial class Form1
    {
        private System.ComponentModel.IContainer? components = null;

        private Button btnGerar = null!;
        private Button btnAdicionarGuiche = null!;
        private Button btnChamar = null!;

        private NumericUpDown nudQuantidadeGuiches = null!;

        private ComboBox cmbGuiche = null!;
        private ComboBox cmbGuicheHistorico = null!;

        private DataGridView dgvSenhas = null!;
        private DataGridView dgvAtendimentos = null!;

        private Label lblProximoValor = null!;
        private Label lblTotalGuiches = null!;

        private readonly Color azul =
            Color.FromArgb(32, 112, 207);

        private readonly Color texto =
            Color.FromArgb(22, 45, 83);

        private readonly Color fundo =
            Color.FromArgb(242, 246, 251);

        private readonly Color borda =
            Color.FromArgb(214, 226, 241);

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnGerar = new Button();
            btnAdicionarGuiche = new Button();
            btnChamar = new Button();

            nudQuantidadeGuiches = new NumericUpDown();

            cmbGuiche = new ComboBox();
            cmbGuicheHistorico = new ComboBox();

            dgvSenhas = new DataGridView();
            dgvAtendimentos = new DataGridView();

            var lblTitulo = new Label();
            var lblQuantidade = new Label();
            var lblGuiche = new Label();

            lblProximoValor = new Label();
            lblTotalGuiches = new Label();

            var painelAcoes = new TableLayoutPanel();
            var painelIndicadores = new TableLayoutPanel();
            var painelTopo = new TableLayoutPanel();
            var painelSenhas = new Panel();
            var painelAtendimentos = new Panel();
            var layoutListas = new TableLayoutPanel();

            SuspendLayout();

            // ==========================================
            // FORMULÁRIO
            // ==========================================

            Text = "Central de Atendimentos";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1536, 1024);
            MinimumSize = new Size(1100, 700);
            BackColor = fundo;
            Font = new Font("Segoe UI", 10);

            // ==========================================
            // LAYOUT PRINCIPAL
            // ==========================================

            var principal = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                ColumnCount = 1,
                RowCount = 3,
                BackColor = fundo,
                Margin = new Padding(0)
            };

            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 65));

            principal.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 130));

            principal.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));

            Controls.Add(principal);

            // ==========================================
            // TÍTULO NO TOPO
            // ==========================================

            lblTitulo.Text = "Central de Atendimentos";
            lblTitulo.Font = new Font(
                "Segoe UI", 22, FontStyle.Bold);

            lblTitulo.ForeColor = texto;
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.TextAlign =
                ContentAlignment.MiddleLeft;
            lblTitulo.Margin = new Padding(0);

            principal.Controls.Add(lblTitulo, 0, 0);

            // ==========================================
            // FAIXA SUPERIOR: AÇÕES E INDICADORES
            // ==========================================

            painelTopo.Dock = DockStyle.Fill;
            painelTopo.ColumnCount = 2;
            painelTopo.RowCount = 1;
            painelTopo.BackColor = fundo;
            painelTopo.Margin = new Padding(0);

            painelTopo.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 70));

            painelTopo.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 30));

            principal.Controls.Add(painelTopo, 0, 1);

            // ==========================================
            // PAINEL DE AÇÕES
            // ==========================================

            painelAcoes.Dock = DockStyle.Fill;
            painelAcoes.ColumnCount = 6;
            painelAcoes.RowCount = 1;
            painelAcoes.BackColor = Color.White;
            painelAcoes.Padding = new Padding(12);
            painelAcoes.Margin = new Padding(0, 0, 12, 0);

            painelAcoes.CellBorderStyle =
                TableLayoutPanelCellBorderStyle.None;

            painelAcoes.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 18));

            painelAcoes.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 20));

            painelAcoes.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 15));

            painelAcoes.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 15));

            painelAcoes.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 10));

            painelAcoes.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 22));

            painelTopo.Controls.Add(painelAcoes, 0, 0);

            // Botão Gerar Senha
            btnGerar.Text = "Gerar Senha";
            EstilizarBotao(btnGerar, true);
            painelAcoes.Controls.Add(btnGerar, 0, 0);

            // Botão Adicionar Guichê
            btnAdicionarGuiche.Text = "Adicionar Guichê";
            EstilizarBotao(btnAdicionarGuiche, false);
            painelAcoes.Controls.Add(btnAdicionarGuiche, 1, 0);

            // Campo de quantidade de guichês
            var painelQuantidade = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = Color.White,
                Padding = new Padding(8, 5, 8, 5),
                Margin = new Padding(3)
            };

            painelQuantidade.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 28));

            painelQuantidade.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));

            lblQuantidade.Text = "Quantidade:";
            lblQuantidade.Dock = DockStyle.Fill;
            lblQuantidade.ForeColor = texto;
            lblQuantidade.TextAlign =
                ContentAlignment.MiddleLeft;

            nudQuantidadeGuiches.Minimum = 1;
            nudQuantidadeGuiches.Maximum = 100;
            nudQuantidadeGuiches.Value = 1;
            nudQuantidadeGuiches.Dock = DockStyle.Fill;
            nudQuantidadeGuiches.TextAlign =
                HorizontalAlignment.Center;
            nudQuantidadeGuiches.Font =
                new Font("Segoe UI", 11);

            painelQuantidade.Controls.Add(lblQuantidade, 0, 0);
            painelQuantidade.Controls.Add(
                nudQuantidadeGuiches, 0, 1);

            painelAcoes.Controls.Add(painelQuantidade, 2, 0);

            // Botão Chamar
            btnChamar.Text = "Chamar";
            EstilizarBotao(btnChamar, true);
            painelAcoes.Controls.Add(btnChamar, 3, 0);

            // Campo Guichê
            // O ComboBox começa vazio.
            cmbGuiche.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbGuiche.Anchor = AnchorStyles.None;
            cmbGuiche.Width = 230;
            cmbGuiche.Font = new Font("Segoe UI", 13);
            cmbGuiche.DropDownHeight = 220;

            lblGuiche.Text = "Guichê:";
            lblGuiche.Anchor = AnchorStyles.None;
            lblGuiche.ForeColor = texto;
            lblGuiche.Font = new Font("Segoe UI", 12);

            // O seletor fica em um painel próprio.
            // Para manter o layout compacto, ele é posicionado
            // acima da área de ações como campo auxiliar.
            // Será preenchido quando os guichês forem cadastrados.
            painelAcoes.Controls.Add(lblGuiche, 4, 0);
            painelAcoes.Controls.Add(cmbGuiche, 5, 0);

            // ==========================================
            // PAINEL DE INDICADORES
            // ==========================================

            painelIndicadores.Dock = DockStyle.Fill;
            painelIndicadores.ColumnCount = 2;
            painelIndicadores.RowCount = 1;
            painelIndicadores.BackColor = Color.White;
            painelIndicadores.Padding = new Padding(5);
            painelIndicadores.Margin = new Padding(0);

            painelIndicadores.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 50));

            painelIndicadores.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 50));

            painelTopo.Controls.Add(painelIndicadores, 1, 0);

            var indicadorProximo = CriarIndicador(
                "Próximo atendimento",
                out lblProximoValor);

            var indicadorGuiches = CriarIndicador(
                "Guichês cadastrados",
                out lblTotalGuiches);

            // Nenhum atendimento ou guichê pré-cadastrado.
            lblProximoValor.Text = "—";
            lblTotalGuiches.Text = "0";

            painelIndicadores.Controls.Add(
                indicadorProximo, 0, 0);

            painelIndicadores.Controls.Add(
                indicadorGuiches, 1, 0);

            // ==========================================
            // LISTAS INFERIORES
            // ==========================================

            layoutListas.Dock = DockStyle.Fill;
            layoutListas.ColumnCount = 2;
            layoutListas.RowCount = 1;
            layoutListas.BackColor = fundo;
            layoutListas.Margin = new Padding(0, 22, 0, 0);
            layoutListas.Padding = new Padding(0);

            layoutListas.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 50));

            layoutListas.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 50));

            principal.Controls.Add(layoutListas, 0, 2);

            // ==========================================
            // PAINEL SENHAS
            // ==========================================

            painelSenhas = CriarPainel();
            painelSenhas.Margin = new Padding(0, 0, 7, 0);

            layoutListas.Controls.Add(painelSenhas, 0, 0);

            var cabecalhoSenhas = Cabecalho(
                "Senhas",
                "Aguardando atendimento");

            dgvSenhas = Tabela();

            dgvSenhas.Columns.Add("Id", "ID");

            dgvSenhas.Columns.Add(
                "DataGeracao", "Data de Geração");

            dgvSenhas.Columns.Add(
                "HoraGeracao", "Hora de Geração");

            dgvSenhas.Columns.Add(
                "Status", "Status");

            painelSenhas.Controls.Add(dgvSenhas);
            painelSenhas.Controls.Add(cabecalhoSenhas);

            // ==========================================
            // PAINEL ATENDIMENTOS
            // ==========================================

            painelAtendimentos = CriarPainel();
            painelAtendimentos.Margin =
                new Padding(7, 0, 0, 0);

            layoutListas.Controls.Add(
                painelAtendimentos, 1, 0);

            var cabecalhoAtendimentos = new Panel
            {
                Dock = DockStyle.Top,
                Height = 76,
                BackColor = Color.White
            };

            var tituloAtendimentos = Cabecalho(
                "Atendimentos",
                "Histórico por guichê");

            tituloAtendimentos.Dock = DockStyle.Left;
            tituloAtendimentos.Width = 300;

            var seletorHistorico = new TableLayoutPanel
            {
                Dock = DockStyle.Right,
                Width = 220,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = Color.White,
                Padding = new Padding(0, 12, 0, 12)
            };

            seletorHistorico.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 85));

            seletorHistorico.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100));

            var lblHistorico = new Label
            {
                Text = "Guichê:",
                Dock = DockStyle.Fill,
                ForeColor = texto,
                TextAlign = ContentAlignment.MiddleLeft
            };

            cmbGuicheHistorico.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbGuicheHistorico.Dock = DockStyle.Fill;
            cmbGuicheHistorico.Font =
                new Font("Segoe UI", 10);

            // Também começa vazio.
            seletorHistorico.Controls.Add(lblHistorico, 0, 0);

            seletorHistorico.Controls.Add(
                cmbGuicheHistorico, 1, 0);

            cabecalhoAtendimentos.Controls.Add(
                tituloAtendimentos);

            cabecalhoAtendimentos.Controls.Add(
                seletorHistorico);

            dgvAtendimentos = Tabela();

            dgvAtendimentos.Columns.Add("Id", "ID");

            dgvAtendimentos.Columns.Add("Guiche", "Guichê");

            dgvAtendimentos.Columns.Add(
                "DataGeracao", "Data de Geração");

            dgvAtendimentos.Columns.Add(
                "HoraGeracao", "Hora de Geração");

            dgvAtendimentos.Columns.Add(
                "DataAtendimento", "Data de Atendimento");

            dgvAtendimentos.Columns.Add(
                "HoraAtendimento", "Hora de Atendimento");

            painelAtendimentos.Controls.Add(dgvAtendimentos);

            painelAtendimentos.Controls.Add(
                cabecalhoAtendimentos);

            // ==========================================
            // FINALIZAÇÃO
            // ==========================================

            ResumeLayout(false);
        }

        // ==========================================
        // MÉTODOS AUXILIARES DE ESTILO
        // ==========================================

        private void EstilizarBotao(
            Button botao,
            bool destaque)
        {
            botao.Dock = DockStyle.Fill;
            botao.Margin = new Padding(8, 15, 8, 15);

            botao.FlatStyle = FlatStyle.Flat;

            botao.FlatAppearance.BorderSize =
                destaque ? 0 : 1;

            botao.FlatAppearance.BorderColor = azul;

            botao.BackColor = destaque
                ? azul
                : Color.White;

            botao.ForeColor = destaque
                ? Color.White
                : azul;

            botao.Font = new Font(
                "Segoe UI", 11, FontStyle.Bold);

            botao.Cursor = Cursors.Hand;
        }

        private Panel CriarPainel()
        {
            return new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(15),
                BorderStyle = BorderStyle.FixedSingle
            };
        }

        private Panel Cabecalho(
            string titulo,
            string subtitulo)
        {
            var painel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 76,
                BackColor = Color.White
            };

            var lblTitulo = new Label
            {
                Text = titulo,
                Location = new Point(10, 5),
                Size = new Size(350, 32),
                Font = new Font(
                    "Segoe UI", 16, FontStyle.Bold),
                ForeColor = texto
            };

            var lblSubtitulo = new Label
            {
                Text = subtitulo,
                Location = new Point(10, 39),
                Size = new Size(350, 25),
                Font = new Font("Segoe UI", 10),
                ForeColor = texto
            };

            painel.Controls.Add(lblTitulo);
            painel.Controls.Add(lblSubtitulo);

            return painel;
        }

        private Panel CriarIndicador(
            string titulo,
            out Label valor)
        {
            var painel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(5)
            };

            var lblTitulo = new Label
            {
                Text = titulo,
                Dock = DockStyle.Top,
                Height = 38,
                TextAlign = ContentAlignment.BottomCenter,
                ForeColor = texto,
                Font = new Font("Segoe UI", 9)
            };

            valor = new Label
            {
                Text = "—",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = texto,
                Font = new Font(
                    "Segoe UI", 22, FontStyle.Bold)
            };

            painel.Controls.Add(valor);
            painel.Controls.Add(lblTitulo);

            return painel;
        }

        private DataGridView Tabela()
        {
            var tabela = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,

                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,

                ReadOnly = true,
                RowHeadersVisible = false,
                MultiSelect = false,

                SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect,

                AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill,

                EnableHeadersVisualStyles = false,
                ColumnHeadersHeight = 44,

                RowTemplate = { Height = 49 },

                GridColor = borda
            };

            tabela.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(241, 245, 250);

            tabela.ColumnHeadersDefaultCellStyle.ForeColor =
                texto;

            tabela.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            tabela.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(241, 245, 250);

            tabela.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                texto;

            tabela.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            tabela.DefaultCellStyle.ForeColor = texto;

            tabela.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(218, 235, 252);

            tabela.DefaultCellStyle.SelectionForeColor =
                texto;

            tabela.DefaultCellStyle.Padding =
                new Padding(5);

            return tabela;
        }
    }
}
