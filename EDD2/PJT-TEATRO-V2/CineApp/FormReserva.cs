using System;
using System.Drawing;
using System.Windows.Forms;

namespace CineApp
{
    public class FormReserva : Form
    {
        public int TipoReserva { get; private set; }

        private Poltrona poltrona;

        public FormReserva(Poltrona p)
        {
            poltrona = p;

            Text = "Reservar Poltrona";
            Size = new Size(400, 230);

            StartPosition = FormStartPosition.CenterParent;

            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;

            // -------------------------
            // POLTRONA
            // -------------------------

            Label lblPoltrona = new Label();

            lblPoltrona.Text =
                $"Poltrona {(char)('A' + p.posX)}{p.posY + 1}";

            lblPoltrona.AutoSize = true;
            lblPoltrona.Font = new Font("Arial", 12, FontStyle.Bold);

            // Centraliza horizontalmente
            lblPoltrona.Location = new Point(
                (ClientSize.Width - lblPoltrona.PreferredWidth) / 2,
                20
            );


            // -------------------------
            // VALOR INTEIRA
            // -------------------------

            Label lblInteira = new Label();

            lblInteira.Text =
                $"Inteira: R$ {p.valor:F2}";

            lblInteira.AutoSize = true;

            lblInteira.Location = new Point(
                (ClientSize.Width - lblInteira.PreferredWidth) / 2,
                60
            );


            // -------------------------
            // VALOR MEIA
            // -------------------------

            Label lblMeia = new Label();

            lblMeia.Text =
                $"Meia-entrada: R$ {(p.valor / 2):F2}";

            lblMeia.AutoSize = true;

            lblMeia.Location = new Point(
                (ClientSize.Width - lblMeia.PreferredWidth) / 2,
                90
            );


            // -------------------------
            // BOTÕES
            // -------------------------

            Button btnInteira = new Button();

            btnInteira.Text = "Inteira";
            btnInteira.Size = new Size(110, 35);

            btnInteira.Click += (sender, e) =>
            {
                TipoReserva = 1;
                DialogResult = DialogResult.OK;
                Close();
            };


            Button btnMeia = new Button();

            btnMeia.Text = "Meia-entrada";
            btnMeia.Size = new Size(110, 35);

            btnMeia.Click += (sender, e) =>
            {
                TipoReserva = 2;
                DialogResult = DialogResult.OK;
                Close();
            };


            Button btnCancelar = new Button();

            btnCancelar.Text = "Cancelar";
            btnCancelar.Size = new Size(110, 35);

            btnCancelar.Click += (sender, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };


            // -------------------------
            // POSIÇÃO DOS BOTÕES
            // -------------------------

            int espacamento = 10;

            int larguraTotal =
                btnInteira.Width +
                btnMeia.Width +
                btnCancelar.Width +
                (espacamento * 2);

            int inicioX =
                (ClientSize.Width - larguraTotal) / 2;

            btnInteira.Location =
                new Point(inicioX, 130);

            btnMeia.Location =
                new Point(
                    inicioX + btnInteira.Width + espacamento,
                    130
                );

            btnCancelar.Location =
                new Point(
                    inicioX +
                    btnInteira.Width +
                    btnMeia.Width +
                    (espacamento * 2),
                    130
                );


            // -------------------------
            // ADICIONA CONTROLES
            // -------------------------

            Controls.Add(lblPoltrona);
            Controls.Add(lblInteira);
            Controls.Add(lblMeia);
            Controls.Add(btnInteira);
            Controls.Add(btnMeia);
            Controls.Add(btnCancelar);
        }
    }
}