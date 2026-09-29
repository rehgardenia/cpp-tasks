namespace ATV3_RESTAURANTE.Models
{
    public class Restaurante
    {
        private const int MAX_PEDIDOS = 50;

        public int proxPedido { get; set; }
        public List<Pedido> Pedidos { get; set; }

        public Restaurante()
        {
            Pedidos = new List<Pedido>();
        }

        public bool novoPedido(Pedido pedido)
        {
            if (pedido != null && Pedidos.Count < MAX_PEDIDOS)
            {
                Pedidos.Add(pedido);
                return true;
            }
            return false;
        }

        public Pedido? buscarPedido(int id)
        {
            return Pedidos.FirstOrDefault(p => p.Id == id);
        }

        public bool removerPedido(Pedido pedido)
        {
            if (pedido != null && Pedidos.Contains(pedido))
            {
                Pedidos.Remove(pedido);
                return true;
            }
            return false;
        }
    }
}
