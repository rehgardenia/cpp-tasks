namespace Models
{
    public class Guiches
    {
        public List<Guiche> guiches { get; set; }

        public Guiches()
        {
            guiches = new List<Guiche>();
        }
        public void adicionar(Guiche guiche)
        {
            guiches.Add(guiche);
        }
    }
}
