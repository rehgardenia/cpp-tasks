namespace Models
{
    public class Senha
    {
        public int Id { get; set; }
        public DateTime dataGerac { get; set; }
        public DateTime horaGerac { get; set; }

        public Senha(int id)
        {
            Id = id;
            dataGerac = DateTime.Now.Date;
            horaGerac = DateTime.Now;
        }
        public string dadosParciais()
        {
            return $"{Id} - {dataGerac.ToShortDateString()} - {horaGerac.ToShortTimeString()}";
        }
        public string dadosCompletos()
        {
            return $"{Id} - {dataGerac} - {horaGerac}";
        }

    }
}