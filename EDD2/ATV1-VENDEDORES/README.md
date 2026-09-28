# Sistema de Cadastro de Vendedores

Projeto em C# para gerenciamento de vendedores, vendas e comissões, desenvolvido como aplicação de console usando o padrão MVC (Model-View-Controller).

## Descrição

Este sistema permite cadastrar vendedores, consultar dados, excluir registros, registrar vendas e listar o total das vendas e comissões. A aplicação mantém um controle de até 10 vendedores e registra vendas diárias por vendedor.

## Funcionalidades

- Cadastrar vendedor
- Consultar vendedor por ID
- Excluir vendedor
- Registrar venda por dia
- Listar vendedores e totais gerais
- Calcular comissão e total de vendas
- Validar limite máximo de vendedores

## Estrutura do projeto

```text
ATV1-VENDEDORES/
├── README.md
└── PjtVendedores/
    ├── Program.cs
    ├── PjtVendedores.csproj
    ├── Controller/
    │   └── VendedorController.cs
    ├── Model/
    │   ├── Venda.cs
    │   ├── Vendedor.cs
    │   └── Vendedores.cs
    └── View/
        └── VendedorView.cs
```

## Classes principais

### Model
- `Vendedor`: representa um vendedor com ID, nome, percentual de comissão e histórico de vendas.
- `Vendedores`: gerencia a lista de vendedores e as operações de cadastro, busca e exclusão.
- `Venda`: armazena a quantidade de vendas e o valor total da venda.

### View
- `VendedorView`: responsável pela exibição do menu e das mensagens no console.

### Controller
- `VendedorController`: implementa a lógica de controle do fluxo do sistema e das ações do menu.

## Menu do sistema

O programa oferece o seguinte menu:

0. Sair
1. Cadastrar vendedor
2. Consultar vendedor
3. Excluir vendedor
4. Registrar venda
5. Listar vendedores

## Como executar

1. Abra o terminal no diretório do projeto:

```bash
cd ATV1-VENDEDORES/PjtVendedores
```

2. Execute a aplicação:

```bash
dotnet run
```

## Requisitos

- .NET SDK instalado
- Ambiente de terminal/console

## Observações

- Cada vendedor pode registrar vendas em até 31 dias do mês.
- A exclusão de vendedor só é permitida quando ele não possui vendas registradas.
- O sistema tem limite de 10 vendedores cadastrados.

## Autor

Projeto desenvolvido para fins de estudo e prática de programação orientada a objetos em C#.
