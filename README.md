# .NET Supplies

Sistema simples de gerenciamento de suprimentos desenvolvido em **C# com .NET**, com foco em conceitos de **Programação Orientada a Objetos (POO)**.

## Funcionalidades

* Cadastro de produtos
* Consulta de estoque
* Entrada de materiais
* Saída de materiais
* Controle de estoque mínimo
* Realização de inventário
* Identificação de divergências entre estoque físico e sistema

## Tecnologias

* C#
* .NET
* Programação Orientada a Objetos
* VS Code

## Estrutura

```text
dotnet-supplies/
├── Models/
│   ├── Movimentacao.cs
│   ├── Produto.cs
│   ├── ResultadoInventario.cs
│   └── TipoMovimentacao.cs
├── Services/
│   ├── Estoque.cs
│   └── Inventario.cs
├── Program.cs
└── SistemaSuprimentos.csproj
```

## Executando o projeto

Clone o repositório:

```bash
git clone https://github.com/andre8756/dotnet-supplies.git
```

Entre na pasta:

```bash
cd dotnet-supplies
```

Execute:

```bash
dotnet run
```
ticar **C# e .NET**, aplicando conceitos de POO em um cenário de controle de suprimentos e estoque.
