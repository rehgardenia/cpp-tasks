# Escola

Um projeto em **C#** para gerenciamento de escolas, cursos, disciplinas e alunos, implementado com o padrão **MVC (Model-View-Controller)**.

## 📋 Descrição

Este projeto implementa um sistema de gerenciamento escolar que permite:
- Adicionar, pesquisar e remover **cursos**
- Gerenciar **disciplinas** associadas aos cursos
- Matricular e desmatricular **alunos** nas disciplinas
- Pesquisar informações sobre cursos, disciplinas e alunos
- Interface console interativa com menu

## 🏗️ Arquitetura MVC

O projeto segue o padrão **Model-View-Controller** para separação de responsabilidades:

### Model
- **`Aluno`**: Representa um aluno com ID e nome
  - Capacidade: Até 15 alunos por disciplina
  
- **`Disciplina`**: Representa uma disciplina com ID e descrição
  - Associa alunos matriculados
  - Capacidade: Até 12 disciplinas por curso
  
- **`Curso`**: Representa um curso com ID e descrição
  - Associa disciplinas ofertadas
  - Capacidade: Até 5 cursos por escola
  
- **`Escola`**: Classe principal que gerencia toda a escola
  - Armazena e gerencia todos os cursos

### View
- **`EscolaView`**: Gerencia toda a interação com o usuário
  - Menu interativo com 10 opções
  - Leitura de entrada com validação (IDs, textos)
  - Exibição de mensagens e informações

### Controller
- **`EscolaController`**: Coordena Model e View
  - Lógica de negócio (adicionar, pesquisar, remover)
  - Validações e tratamento de erros
  - Comunicação entre Model e View

## 🛠️ Tecnologias

- **Linguagem**: C# (.NET 10.0)
- **Tipo de Projeto**: Aplicação Console
- **Padrão**: MVC (Model-View-Controller)
- **Framework**: .NET SDK

## ⚙️ Requisitos

- .NET SDK 10.0 ou superior
- Windows, Linux ou macOS

## 🚀 Como Usar

### Clonar o repositório
```bash
git clone <url-do-repositorio>
cd Escola
```

### Compilar o projeto
```bash
dotnet build
```

### Executar a aplicação
```bash
dotnet run
```

## 📁 Estrutura do Projeto

```
Escola/
├── Program.cs                 # Ponto de entrada da aplicação
├── Escola.csproj             # Arquivo de configuração do projeto
├── Model/
│   ├── Aluno.cs              # Modelo de Aluno
│   ├── Curso.cs              # Modelo de Curso
│   ├── Disciplina.cs         # Modelo de Disciplina
│   └── Escola.cs             # Modelo principal (EscolaModel)
├── View/
│   └── EscolaView.cs         # Interface com o usuário
├── Controller/
│   └── EscolaController.cs   # Lógica de negócio
├── bin/                       # Binários compilados
├── obj/                       # Arquivos de compilação
└── README.md                 # Este arquivo
```

## 📋 Menu Principal

A aplicação oferece um menu interativo com as seguintes opções:

```
0. Sair
1. Adicionar Curso
2. Pesquisar Curso
3. Remover Curso
4. Adicionar Disciplina
5. Pesquisar Disciplina
6. Remover Disciplina
7. Matricular Aluno
8. Desmatricular Aluno
9. Pesquisar Aluno
```

## 💾 Limitações Atuais

- Dados armazenados em memória (sem persistência em banco de dados)
- Capacidades fixas:
  - Máximo de 5 cursos
  - Máximo de 12 disciplinas por curso
  - Máximo de 15 alunos por disciplina

## 🔄 Fluxo de Uso Recomendado

1. Adicionar cursos à escola
2. Adicionar disciplinas aos cursos
3. Adicionar alunos à escola
4. Matricular alunos em disciplinas
5. Consultar informações conforme necessário


## 📝 Licença

Este projeto é fornecido como está, sem nenhuma licença específica.

---

**Nota**: Este é um projeto educacional para praticar conceitos de programação orientada a objetos e o padrão MVC em C#.
