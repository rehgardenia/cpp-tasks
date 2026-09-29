# Sistema de Gestão de Cozinha Industrial

Projeto em **C#** desenvolvido aplicando os conceitos de **Programação Orientada a Objetos (POO)** e a arquitetura **MVC (Model-View-Controller)** para gerenciamento de pedidos e itens de um restaurante/cozinha industrial.

---

## 📌 Contexto do Domínio

Uma cozinha industrial atende diariamente até **50 pedidos** (numerados sequencialmente). Cada pedido aceita no máximo **10 itens**. O sistema é responsável por:

* Gerenciar o ciclo de vida dos pedidos (criar, adicionar/remover itens, cancelar).
* Calcular totais e relatórios diários de faturamento.
* Manter o histórico de operações em console.

---

## 🏗️ Arquitetura do Projeto (MVC)

O projeto está estruturado no padrão MVC para garantir o desacoplamento das regras de negócio, interface do usuário e controle de fluxo:

```text
CozinhaIndustrial/
├── Models/
│   ├── Item.cs
│   ├── Pedido.cs
│   └── Restaurante.cs
├── Views/
│   └── ConsoleView.cs
├── Controllers/
│   └── CozinhaController.cs
├── Program.cs
└── README.md

```

* **Models**: Contêm os atributos, validações e regras de negócio da aplicação.
* **Views**: Responsáveis pela interação direta com o usuário (leitura e exibição no console).
* **Controllers**: Intermediam a comunicação entre as interações da View e as operações nos Models.

---

## 📐 Diagrama de Classes

```text
+---------------------+
|        Item         |
+---------------------+
| - id: int           |
| - descricao: string |
| - preco: double     |
+---------------------+

+----------------------------------+
|              Pedido              |
+----------------------------------+
| - id: int                        |
| - cliente: string                |
| - itens: Item[10]                |
+----------------------------------+
| + AdicionarItem(Item item): bool |
| + RemoverItem(Item item): bool   |
| + DadosDoPedido(): string        |
| + CalcularTotal(): double        |
+----------------------------------+

+---------------------------------------+
|              Restaurante              |
+---------------------------------------+
| - proxPedido: int                     |
| - pedidos: Pedido[50]                 |
+---------------------------------------+
| + NovoPedido(Pedido pedido): bool     |
| + BuscarPedido(Pedido pedido): Pedido |
| + CancelarPedido(Pedido pedido): bool |
+---------------------------------------+

```

---

## 💻 Opções do Menu (Console)

Ao executar a aplicação, o menu interativo oferece as seguintes operações:

| Opção | Ação | Descrição |
| --- | --- | --- |
| **0** | Sair | Encerra a execução do sistema. |
| **1** | Criar novo pedido | Gera um pedido sequencial atribuído ao nome do cliente. |
| **2** | Adicionar item ao pedido | Insere um item (ID, descrição e preço) em um pedido existente (máx. 10). |
| **3** | Remover item do pedido | Remove um item previamente cadastrado de um pedido. |
| **4** | Consultar pedido | Exibe detalhes de um pedido: ID, cliente, itens cadastrados e valor total. |
| **5** | Cancelar pedido | Remove o pedido da lista ativa do restaurante. |
| **6** | Listar todos os pedidos | Exibe o relatório geral com IDs, totais por pedido e o faturamento do dia. |

---

## 🚀 Como Executar o Projeto

### Pré-requisitos

* [.NET SDK 8.0](https://dotnet.microsoft.com/download) ou superior instalado.
* IDE/Editor de sua preferência (VS Code, Visual Studio, JetBrains Rider).

### Passos

1. Clone este repositório:
```bash
git clone https://github.com/seu-usuario/cozinha-industrial-mvc.git

```


2. Navegue até o diretório do projeto:
```bash
cd cozinha-industrial-mvc

```


3. Compile e execute a aplicação:
```bash
dotnet run

```



---

## 🛠️ Tecnologias Utilizadas

* **Linguagem**: C#
* **Plataforma**: .NET Console Application
* **Conceitos de POO**: Encapsulamento, Abstração e Associação de Objetos via Array Fixo (`Item[10]` e `Pedido[50]`).
