using ATV5_AGENDA_WFA.Models;
using Microsoft.VisualBasic;

namespace ATV5_AGENDA_WFA;

public partial class Form1 : Form
{
    private readonly Contatos _contatos = new();

    public Form1()
    {
        InitializeComponent();
        AtualizarListaContatos();
    }

    private void btnAdicionar_Click(object sender, EventArgs e)
    {
        Contato? contato = ExibirFormularioContato("Adicionar contato");
        if (contato == null)
        {
            return;
        }

        if (_contatos.adicionar(contato))
        {
            AtualizarListaContatos();
            MessageBox.Show("Contato adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show("Contato já existe na agenda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnPesquisar_Click(object sender, EventArgs e)
    {
        string nome = Interaction.InputBox("Digite o nome do contato:", "Pesquisar contato");
        if (string.IsNullOrWhiteSpace(nome))
        {
            return;
        }

        Contato? contato = _contatos.Agenda.FirstOrDefault(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        if (contato == null)
        {
            MessageBox.Show("Contato não encontrado.", "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        MessageBox.Show(contato.ToString(), "Contato encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnAlterar_Click(object sender, EventArgs e)
    {
        string nome = Interaction.InputBox("Digite o nome do contato que deseja alterar:", "Alterar contato");
        if (string.IsNullOrWhiteSpace(nome))
        {
            return;
        }

        Contato? contato = _contatos.Agenda.FirstOrDefault(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        if (contato == null)
        {
            MessageBox.Show("Contato não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        Contato? atualizado = ExibirFormularioContato("Alterar contato", contato);
        if (atualizado == null)
        {
            return;
        }

        int indice = _contatos.Agenda.FindIndex(c => c.Nome.Equals(contato.Nome, StringComparison.OrdinalIgnoreCase));
        if (indice >= 0)
        {
            _contatos.Agenda[indice] = atualizado;
            AtualizarListaContatos();
            MessageBox.Show("Contato alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show("Não foi possível alterar o contato.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnRemover_Click(object sender, EventArgs e)
    {
        string nome = Interaction.InputBox("Digite o nome do contato que deseja remover:", "Remover contato");
        if (string.IsNullOrWhiteSpace(nome))
        {
            return;
        }

        Contato? contato = _contatos.Agenda.FirstOrDefault(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        if (contato == null)
        {
            MessageBox.Show("Contato não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (_contatos.remover(contato))
        {
            AtualizarListaContatos();
            MessageBox.Show("Contato removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show("Não foi possível remover o contato.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnListar_Click(object sender, EventArgs e)
    {
        AtualizarListaContatos();
    }

    private void btnSair_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void AtualizarListaContatos()
    {
        listContatos.Items.Clear();

        if (_contatos.Agenda.Count == 0)
        {
            listContatos.Items.Add("Nenhum contato cadastrado.");
            return;
        }

        foreach (Contato contato in _contatos.Agenda)
        {
            string telefonePrincipal = contato.getTelefonePrincipal();
            string texto = $"{contato.Nome} - {contato.Email} - {contato.DtNasc} - {(string.IsNullOrWhiteSpace(telefonePrincipal) ? "Sem telefone principal" : telefonePrincipal)}";
            listContatos.Items.Add(texto);
        }
    }

    private Contato? ExibirFormularioContato(string titulo, Contato? contatoAtual = null)
    {
        Form dialog = new Form
        {
            Text = titulo,
            Width = 420,
            Height = 320,
            StartPosition = FormStartPosition.CenterParent,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            MinimizeBox = false
        };

        Label lblNome = new Label { Text = "Nome:", Location = new Point(20, 20), AutoSize = true };
        TextBox txtNome = new TextBox { Location = new Point(120, 20), Width = 250 };

        Label lblEmail = new Label { Text = "Email:", Location = new Point(20, 60), AutoSize = true };
        TextBox txtEmail = new TextBox { Location = new Point(120, 60), Width = 250 };

        Label lblData = new Label { Text = "Data nasc.:", Location = new Point(20, 100), AutoSize = true };
        TextBox txtData = new TextBox { Location = new Point(120, 100), Width = 250, Text = "dd/mm/aaaa" };

        Label lblTipo = new Label { Text = "Tipo tel.:", Location = new Point(20, 140), AutoSize = true };
        TextBox txtTipo = new TextBox { Location = new Point(120, 140), Width = 120 };

        Label lblTelefone = new Label { Text = "Telefone:", Location = new Point(20, 180), AutoSize = true };
        TextBox txtTelefone = new TextBox { Location = new Point(120, 180), Width = 120 };

        CheckBox chkPrincipal = new CheckBox { Text = "Principal", Location = new Point(255, 180), AutoSize = true };

        Button btnSalvar = new Button { Text = "Salvar", DialogResult = DialogResult.OK, Location = new Point(150, 230), Width = 90,Height = 30 };
        Button btnCancelar = new Button { Text = "Cancelar", DialogResult = DialogResult.Cancel, Location = new Point(255, 230), Width = 90 ,Height = 30 };

        if (contatoAtual != null)
        {
            txtNome.Text = contatoAtual.Nome;
            txtEmail.Text = contatoAtual.Email;
            txtData.Text = contatoAtual.DtNasc.ToString();

            if (contatoAtual.Telefones.Count > 0)
            {
                Telefone primeiroTelefone = contatoAtual.Telefones[0];
                txtTipo.Text = primeiroTelefone.Tipo;
                txtTelefone.Text = primeiroTelefone.Numero;
                chkPrincipal.Checked = primeiroTelefone.Principal;
            }
        }

        dialog.Controls.AddRange(new Control[]
        {
            lblNome, txtNome,
            lblEmail, txtEmail,
            lblData, txtData,
            lblTipo, txtTipo,
            lblTelefone, txtTelefone,
            chkPrincipal,
            btnSalvar, btnCancelar
        });

        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return null;
        }

        string nome = txtNome.Text.Trim();
        string email = txtEmail.Text.Trim();
        string dataTexto = txtData.Text.Trim();
        string tipo = txtTipo.Text.Trim();
        string numero = txtTelefone.Text.Trim();

        if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email))
        {
            MessageBox.Show("Nome e email são obrigatórios.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return null;
        }

        if (!TryLerData(dataTexto, out Data? dataNascimento))
        {
            MessageBox.Show("Data inválida. Use o formato dd/mm/aaaa.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return null;
        }

        Contato novoContato = contatoAtual ?? new Contato();
        novoContato.Nome = nome;
        novoContato.Email = email;
        novoContato.DtNasc = dataNascimento!;
        novoContato.Telefones.Clear();

        if (!string.IsNullOrWhiteSpace(tipo) && !string.IsNullOrWhiteSpace(numero))
        {
            Telefone telefone = new Telefone
            {
                Tipo = tipo,
                Numero = numero,
                Principal = chkPrincipal.Checked
            };
            novoContato.adicionarTelefone(telefone);
        }

        return novoContato;
    }

    private static bool TryLerData(string valor, out Data? data)
    {
        data = null;
        if (string.IsNullOrWhiteSpace(valor))
        {
            return false;
        }

        string[] partes = valor.Split('/');
        if (partes.Length != 3)
        {
            return false;
        }

        if (!int.TryParse(partes[0], out int dia) ||
            !int.TryParse(partes[1], out int mes) ||
            !int.TryParse(partes[2], out int ano))
        {
            return false;
        }

        if (mes < 1 || mes > 12 || dia < 1 || dia > 31)
        {
            return false;
        }

        data = new Data(dia, mes, ano);
        return true;
    }
}
