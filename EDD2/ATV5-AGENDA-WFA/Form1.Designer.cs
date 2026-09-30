namespace ATV5_AGENDA_WFA;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label lblTitulo;
    private System.Windows.Forms.ListBox listContatos;
    private System.Windows.Forms.Button btnAdicionar;
    private System.Windows.Forms.Button btnPesquisar;
    private System.Windows.Forms.Button btnAlterar;
    private System.Windows.Forms.Button btnRemover;
    private System.Windows.Forms.Button btnListar;
    private System.Windows.Forms.Button btnSair;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();

        this.lblTitulo = new System.Windows.Forms.Label();
        this.listContatos = new System.Windows.Forms.ListBox();
        this.btnAdicionar = new System.Windows.Forms.Button();
        this.btnPesquisar = new System.Windows.Forms.Button();
        this.btnAlterar = new System.Windows.Forms.Button();
        this.btnRemover = new System.Windows.Forms.Button();
        this.btnListar = new System.Windows.Forms.Button();
        this.btnSair = new System.Windows.Forms.Button();

        this.SuspendLayout();

        this.lblTitulo.AutoSize = true;
        this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.lblTitulo.Location = new System.Drawing.Point(20, 20);
        this.lblTitulo.Name = "lblTitulo";
        this.lblTitulo.Size = new System.Drawing.Size(240, 30);
        this.lblTitulo.TabIndex = 0;
        this.lblTitulo.Text = "Agenda de Contatos";

        this.listContatos.FormattingEnabled = true;
        this.listContatos.ItemHeight = 18;
        this.listContatos.Location = new System.Drawing.Point(20, 70);
        this.listContatos.Name = "listContatos";
        this.listContatos.Size = new System.Drawing.Size(520, 320);
        this.listContatos.TabIndex = 1;

        this.btnAdicionar.Location = new System.Drawing.Point(565, 125); //
        this.btnAdicionar.Name = "btnAdicionar";
        this.btnAdicionar.Size = new System.Drawing.Size(150, 40);
        this.btnAdicionar.TabIndex = 2;
        this.btnAdicionar.Text = "1. Adicionar contato";
        this.btnAdicionar.UseVisualStyleBackColor = true;
        this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);

        this.btnPesquisar.Location = new System.Drawing.Point(565, 180);
        this.btnPesquisar.Name = "btnPesquisar";
        this.btnPesquisar.Size = new System.Drawing.Size(150, 40);
        this.btnPesquisar.TabIndex = 3;
        this.btnPesquisar.Text = "2. Pesquisar contato";
        this.btnPesquisar.UseVisualStyleBackColor = true;
        this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);

        this.btnAlterar.Location = new System.Drawing.Point(565, 235);
        this.btnAlterar.Name = "btnAlterar";
        this.btnAlterar.Size = new System.Drawing.Size(150, 40);
        this.btnAlterar.TabIndex = 4;
        this.btnAlterar.Text = "3. Alterar contato";
        this.btnAlterar.UseVisualStyleBackColor = true;
        this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);

        this.btnRemover.Location = new System.Drawing.Point(565, 290);
        this.btnRemover.Name = "btnRemover";
        this.btnRemover.Size = new System.Drawing.Size(150, 40);
        this.btnRemover.TabIndex = 5;
        this.btnRemover.Text = "4. Remover contato";
        this.btnRemover.UseVisualStyleBackColor = true;
        this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);

        this.btnListar.Location = new System.Drawing.Point(565, 345);
        this.btnListar.Name = "btnListar";
        this.btnListar.Size = new System.Drawing.Size(150, 40);
        this.btnListar.TabIndex = 6;
        this.btnListar.Text = "5. Listar contatos";
        this.btnListar.UseVisualStyleBackColor = true;
        this.btnListar.Click += new System.EventHandler(this.btnListar_Click);

        this.btnSair.Location = new System.Drawing.Point(565, 70);
        this.btnSair.Name = "btnSair";
        this.btnSair.Size = new System.Drawing.Size(150, 40);
        this.btnSair.TabIndex = 7;
        this.btnSair.Text = "0. Sair";
        this.btnSair.UseVisualStyleBackColor = true;
        this.btnSair.Click += new System.EventHandler(this.btnSair_Click);

        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(740, 420);
        this.Controls.Add(this.lblTitulo);
        this.Controls.Add(this.listContatos);
        this.Controls.Add(this.btnAdicionar);
        this.Controls.Add(this.btnPesquisar);
        this.Controls.Add(this.btnAlterar);
        this.Controls.Add(this.btnRemover);
        this.Controls.Add(this.btnListar);
        this.Controls.Add(this.btnSair);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "Form1";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Agenda de Contatos";

        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
