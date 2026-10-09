namespace Models
{
    public class Senhas
    {
        public int proximoAtendimento { get; set; }
        public Queue<Senha> filaSenhas { get; set; }

        public Senhas()
        {
            proximoAtendimento = 1;
            filaSenhas = new Queue<Senha>();
        }
        public void gerar()
        {
            Senha novaSenha = new Senha(proximoAtendimento);
            filaSenhas.Enqueue(novaSenha);
            proximoAtendimento++;
        }
    }
}
