namespace Models
{
    public class Guiches
    {
        public List<Guiche> guiches { get; set; }

        public Guiches()
        {
            guiches = new List<Guiche>();
        }
        public void adicionar(int id)
        {
            Guiche novoGuiche = new Guiche(id);
            guiches.Add(novoGuiche);
        }
    }
}
