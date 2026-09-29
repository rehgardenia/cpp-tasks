namespace ATV3_RESTAURANTE.Models
{
    public class Pedido
    {
        private const int MAX_ITEM = 10;

        public int Id { get; set; }
        public string Client { get; set; } = string.Empty;
        public List<Item> Items { get; set; }

        public Pedido()
        {
            Items = new List<Item>();
        }

        public bool addItem(Item item)
        {
            if (item != null && Items.Count < MAX_ITEM)
            {
                Items.Add(item);
                return true;
            }
            return false;
        }

        public bool removerItem(Item item)
        {
            if (item != null && Items.Contains(item))
            {
                Items.Remove(item);
                return true;
            }
            return false;
        }

        public string dadosPedido()
        {
            string dados = $"Pedido ID: {Id}\nCliente: {Client}\nItens:\n";
            foreach (var item in Items)
            {
                dados += $"- {item.Description} - Preço: {item.Price:C}\n";
            }
            return dados;
        }

        public decimal calcularTotal()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.Price;
            }
            return total;
        }
    }
}
