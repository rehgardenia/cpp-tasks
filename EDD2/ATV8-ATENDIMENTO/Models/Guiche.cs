namespace Models
{
    public class Guiche
    {
        public int Id { get; set; }
        public Queue<Senha> atendimentos { get; set; }

        public Guiche()
        {
            Id = 0;
            atendimentos = new Queue<Senha>();
        }
        public Guiche(int id)
        {
            Id = id;
            atendimentos = new Queue<Senha>();
        }
        public bool chamar(Queue<Senha> filaSenhas)
        {
            if (filaSenhas.Count > 0)
            {
                Senha senhaChamada = filaSenhas.Dequeue();
                senhaChamada.dataAtend = DateTime.Now.Date;
                senhaChamada.horaAtend = DateTime.Now;
                atendimentos.Enqueue(senhaChamada);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
