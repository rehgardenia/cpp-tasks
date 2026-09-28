Contexto

Uma cozinha industrial atende diariamente até 50 pedidos feitos por clientes e numerados sequencialmente.

Cada um desses pedidos pode ter, no máximo, 10 itens, cada um com um preço no cardápio.

O sistema deve calcular o valor total dos pedidos e permitir consultar o histórico.

Diagrama de Classes
+---------------------+
| Item                |
+---------------------+
| - id: int           |
| - descricao: string |
| - preco: double     |
+---------------------+

+----------------------------------+
| Pedido                           |
+----------------------------------+
| - id: int                        |
| - cliente: string                |
| - itens: Item[10]                |
+----------------------------------+
| + adicionarItem(Item item): bool |
| + removerItem(Item item): bool   |
| + dadosDoPedido(): string        |
| + calcularTotal(): double        |
+----------------------------------+

+---------------------------------------+
| Restaurante                           |
+---------------------------------------+
| - proxPedido: int                     |
| - pedidos: Pedido[50]                 |
+---------------------------------------+
| + novoPedido(Pedido pedido): bool     |
| + buscarPedido(Pedido pedido): Pedido |
| + cancelarPedido(Pedido pedido): bool |
+---------------------------------------+


Opções do Seletor
0. Sair
1. Criar novo pedido
2. Adicionar item ao pedido
3. Remover item do pedido
4. Consultar pedido (mostrar id, cliente, itens e valor total)
5. Cancelar pedido
6. Listar todos os pedidos (com id, valores totais e soma geral do dia)