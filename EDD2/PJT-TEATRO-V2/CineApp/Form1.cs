namespace CineApp
{
    public partial class Form1 : Form
    {
        private Button[,] botoes;
        private Poltrona[,] poltronas;
        private Label lbFaturamento;

        // Cores do sistema
        private readonly Color corFundo = Color.FromArgb(24, 27, 32);
        private readonly Color corPainel = Color.FromArgb(32, 36, 43);
        private readonly Color corLivre = Color.FromArgb(45, 110, 210);
        private readonly Color corInteira = Color.FromArgb(220, 70, 70);
        private readonly Color corMeia = Color.FromArgb(235, 160, 55);
        private readonly Color corTexto = Color.White;
        private readonly Color corTextoSecundario = Color.FromArgb(180, 185, 195);

        public Form1()
        {
            InitializeComponent();

            // Configuração da janela
            this.Text = "CineApp - Sistema de Bilheteria";
            this.BackColor = corFundo;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScroll = true;
            this.DoubleBuffered = true;

            botoes = new Button[15, 40];
            poltronas = new Poltrona[15, 40];

            // Configurações gerais
            configurarTela();

            // POLTRONAS
            exibirMatriz();

            // FATURAMENTO
            exibirFaturamento();
        }

        private void configurarTela()
        {
            // Título
            Label titulo = new Label();
            titulo.Parent = this;
            titulo.Text = "🎬  CINEAPP";
            titulo.Left = 30;
            titulo.Top = 20;
            titulo.AutoSize = true;
            titulo.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            titulo.ForeColor = Color.White;

            // Subtítulo
            Label subtitulo = new Label();
            subtitulo.Parent = this;
            subtitulo.Text = "Sistema de Bilheteria";
            subtitulo.Left = 34;
            subtitulo.Top = 70;
            subtitulo.AutoSize = true;
            subtitulo.Font = new Font("Segoe UI", 10);
            subtitulo.ForeColor = corTextoSecundario;

            // Linha decorativa
            Panel linha = new Panel();
            linha.Parent = this;
            linha.Left = 30;
            linha.Top = 85;
            linha.Width = 2180;
            linha.Height = 1;
            linha.BackColor = Color.FromArgb(60, 65, 75);

            // Tela
            Label tela = new Label();
            tela.Parent = this;
            tela.Text = "TELA";
            tela.Left = 1090;
            tela.Top = 105;
            tela.Width = 160;
            tela.Height = 35;
            tela.TextAlign = ContentAlignment.MiddleCenter;
            tela.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            tela.ForeColor = Color.White;
            tela.BackColor = Color.FromArgb(70, 75, 85);

            // Informação
            Label instrucao = new Label();
            instrucao.Parent = this;
            instrucao.Text = "Selecione uma poltrona para realizar uma reserva";
            instrucao.Left = 1000;
            instrucao.Top = 145;
            instrucao.AutoSize = true;
            instrucao.Font = new Font("Segoe UI", 9);
            instrucao.ForeColor = corTextoSecundario;
        }

        private void exibirFaturamento()
        {
            // Painel inferior
            Panel painel = new Panel();
            painel.Parent = this;
            painel.Left = 250;
            painel.Top = 950;
            painel.Width = 1920;
            painel.Height = 130;
            painel.BackColor = corPainel;

            // Botão Faturamento
            Button btnFaturamento = new Button();

            btnFaturamento.Parent = painel;
            btnFaturamento.Left = 30;
            btnFaturamento.Top = 30;
            btnFaturamento.Width = 180;
            btnFaturamento.Height = 60;

            btnFaturamento.Text = "💰  FATURAMENTO";
            btnFaturamento.Font = new Font(
                "Segoe UI",
                10,
                FontStyle.Bold
            );

            btnFaturamento.ForeColor = Color.White;
            btnFaturamento.BackColor = Color.FromArgb(55, 130, 80);
            btnFaturamento.FlatStyle = FlatStyle.Flat;
            btnFaturamento.FlatAppearance.BorderSize = 0;
            btnFaturamento.Cursor = Cursors.Hand;

            btnFaturamento.Click += calculoFaturamento;

            // Label Faturamento
            lbFaturamento = new Label();

            lbFaturamento.Parent = painel;
            lbFaturamento.Left = 250;
            lbFaturamento.Top = 50;
            lbFaturamento.Width = 1700;
            lbFaturamento.Height = 90;

            lbFaturamento.ForeColor = corTextoSecundario;
            lbFaturamento.Font = new Font(
                "Segoe UI",
                10,
                FontStyle.Regular
            );

            lbFaturamento.Text =
                "Clique em \"Faturamento\" para visualizar o resumo da bilheteria.";
        }

        private void calculoFaturamento(object sender, EventArgs e)
        {
            double resultado = 0;

            int livres = 0;
            int inteiras = 0;
            int meias = 0;

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    if (poltronas[i, j].ocupacao == 1)
                    {
                        inteiras++;
                        resultado += poltronas[i, j].valor;
                    }
                    else if (poltronas[i, j].ocupacao == 2)
                    {
                        meias++;
                        resultado += poltronas[i, j].valor / 2;
                    }
                    else
                    {
                        livres++;
                    }
                }
            }

            int ocupados = inteiras + meias;

            lbFaturamento.Text =
                $"LUGARES OCUPADOS: {ocupados}     " +
                $"LIVRES: {livres}     " +
                $"INTEIRAS: {inteiras}     " +
                $"MEIAS: {meias}     " +
                $"TOTAL: R$ {resultado:F2}";

            lbFaturamento.ForeColor = Color.White;
            lbFaturamento.Font = new Font(
                "Segoe UI",
                11,
                FontStyle.Bold
            );
        }

        private void exibirMatriz()
        {
            int xInicial = 250;
            int yInicial = 190;

            int largura = 43;
            int altura = 35;
            int espacamento = 5;

            // NÚMEROS DAS COLUNAS
            for (int j = 0; j < 40; j++)
            {
                Label label = new Label();

                label.Parent = this;
                label.Left = xInicial + j * (largura + espacamento);
                label.Top = yInicial - 25;
                label.Width = largura;
                label.Height = 20;
                label.Text = (j + 1).ToString();
                label.TextAlign = ContentAlignment.MiddleCenter;

                label.Font = new Font(
                    "Segoe UI",
                    8,
                    FontStyle.Bold
                );

                label.ForeColor = corTextoSecundario;
            }

            // MATRIZ
            for (int i = 0; i < 15; i++)
            {
                int y = yInicial + i * (altura + espacamento);

                // Label da fileira
                Label labelFileira = new Label();

                labelFileira.Parent = this;
                labelFileira.Left = 210;
                labelFileira.Top = y + 7;
                labelFileira.Width = 30;
                labelFileira.Height = 25;
                labelFileira.Text = ((char)('A' + i)).ToString();
                labelFileira.TextAlign = ContentAlignment.MiddleCenter;

                labelFileira.Font = new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

                labelFileira.ForeColor = corTexto;

                // POLTRONAS
                for (int j = 0; j < 40; j++)
                {
                    int x = xInicial + j * (largura + espacamento);

                    // Criação do botão
                    botoes[i, j] = new Button();

                    botoes[i, j].Parent = this;
                    botoes[i, j].Left = x;
                    botoes[i, j].Top = y;
                    botoes[i, j].Width = largura;
                    botoes[i, j].Height = altura;
                    botoes[i, j].Tag = new Point(i, j);
                    botoes[i, j].Text = idPoltrona(i, j);

                    botoes[i, j].Font =
                        new Font(
                            "Segoe UI",
                            7,
                            FontStyle.Bold
                        );

                    botoes[i, j].ForeColor = Color.White;
                    botoes[i, j].BackColor = corLivre;
                    botoes[i, j].FlatStyle = FlatStyle.Flat;
                    botoes[i, j].FlatAppearance.BorderSize = 0;
                    botoes[i, j].Cursor = Cursors.Hand;
                    botoes[i, j].Click += reservaPoltrona;

                    // Criação da poltrona
                    poltronas[i, j] = new Poltrona();

                    poltronas[i, j].ocupacao = 0;
                    poltronas[i, j].posX = i;
                    poltronas[i, j].posY = j;

                    // Configuração dos valores
                    if (i >= 0 && i <= 4)
                    {
                        poltronas[i, j].valor = 50;
                    }
                    else if (i >= 5 && i <= 9)
                    {
                        poltronas[i, j].valor = 30;
                    }
                    else if (i >= 10 && i <= 14)
                    {
                        poltronas[i, j].valor = 15;
                    }
                    else
                    {
                        poltronas[i, j].valor = 0;
                    }
                }
            }

            // Legenda
            exibirLegenda();
        }

        private void exibirLegenda()
        {
            int y = 900;

            Label titulo = new Label();

            titulo.Parent = this;
            titulo.Left = 250;
            titulo.Top = y;
            titulo.AutoSize = true;
            titulo.Text = "Legenda:";
            titulo.Font = new Font(
                "Segoe UI",
                9,
                FontStyle.Bold
            );
            titulo.ForeColor = corTexto;

            // Livre
            criarLegenda ( 330, y, corLivre, "Livre");
            // Inteira
            criarLegenda(450, y, corInteira,"Inteira");

            // Meia
            criarLegenda(
                580,
                y,
                corMeia,
                "Meia-Entrada"
            );
        }

        private void criarLegenda(
            int x,
            int y,
            Color cor,
            string texto)
        {
            Panel indicador = new Panel();

            indicador.Parent = this;

            indicador.Left = x;
            indicador.Top = y + 3;

            indicador.Width = 15;
            indicador.Height = 15;

            indicador.BackColor = cor;

            Label label = new Label();

            label.Parent = this;

            label.Left = x + 22;
            label.Top = y;

            label.AutoSize = true;

            label.Text = texto;

            label.Font = new Font(
                "Segoe UI",
                9
            );

            label.ForeColor =
                corTextoSecundario;
        }

        private void reservaPoltrona(
            object sender,
            EventArgs e)
        {
            Button btn =
                (Button)sender;

            Point posicao =
                (Point)btn.Tag;

            int x = posicao.X;
            int y = posicao.Y;

            // Validação das coordenadas
            if (x < 0 || x >= 15 ||
                y < 0 || y >= 40)
            {
                MessageBox.Show(
                    "Coordenada inválida.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            Poltrona p =
                poltronas[x, y];

            // Verifica ocupação
            if (p.ocupacao != 0)
            {
                MessageBox.Show(
                    $"Essa poltrona já está ocupada!\n\n" +
                    $"Poltrona: {idPoltrona(x, y)}\n" +
                    $"Tipo: {exibirOcupacao(p.ocupacao)}",
                    "Poltrona ocupada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            // Abre tela de reserva
            using (FormReserva popup =
                new FormReserva(p))
            {
                if (popup.ShowDialog(this) ==
                    DialogResult.OK)
                {
                    p.ocupacao =
                        popup.TipoReserva;

                    atualizarPoltrona(
                        btn,
                        p
                    );
                }
            }
        }

        private void atualizarPoltrona(
            Button btn,
            Poltrona p)
        {
            if (p.ocupacao == 1)
            {
                btn.BackColor =
                    corInteira;
            }
            else if (p.ocupacao == 2)
            {
                btn.BackColor =
                    corMeia;
            }
        }

        private string idPoltrona(
            int i,
            int j)
        {
            return $"{(char)('A' + i)}{j + 1}";
        }

        private string exibirOcupacao(
            int o)
        {
            switch (o)
            {
                case 0:
                    return "Livre";

                case 1:
                    return "Inteira";

                case 2:
                    return "Meia-Entrada";

                default:
                    return "Desconhecida";
            }
        }
    }
}
