# Cadastro de Clientes

## Linguagem e Ferramentas
Este projeto foi desenvolvido em C# e utiliza sistemas de arquivos para o cadastro de clientes, demonstrando a aplicabilidade da linguagem para operações de CRUD (Criar, Ler, Atualizar, Deletar) em um contexto de gerenciamento de dados.

## Integrantes do Grupo
- Sergio Tadeu Dias
- Sérgio Renato
- Igor Alves Palmeira
- Josan Johnata
- Ugo Rocha Ventura
- Igor Nascimento De Vasconcellos
- Jose Flai Oliverira de Jesus

## Visão Geral do Código
O sistema é composto por uma aplicação console que permite ao usuário realizar várias operações relacionadas ao cadastro de clientes, tais como:
- Cadastrar um novo cliente
- Alterar dados de um cliente existente
- Excluir um cliente do cadastro
- Listar todos os clientes cadastrados
- Consultar clientes ativos
- Calcular a média de renda anual dos clientes ativos
- Informar os aniversariantes do dia
- Pesquisar um cliente pelo código ou nome

O código utiliza a classe `Dictionary<int, string>` para armazenar os dados dos clientes, onde a chave é um identificador único do cliente e o valor é uma string contendo os dados do cliente separados por ponto e vírgula. Os dados são persistidos em um arquivo de texto localizado em `c:\temp\csharp\cadastro.txt`, demonstrando a utilização de operações de leitura e escrita em arquivos com C#.

### Principais Métodos
- `LerArquivo()`: Carrega os dados dos clientes do arquivo para a aplicação.
- `GravarDadosArquivo(string linhaCadastro)`: Grava um novo cadastro de cliente no arquivo.
- `CriarNovoCliente()`, `AlterarCliente()`, `ExcluirCliente()`: Métodos para manipulação dos dados dos clientes.
- `ConsultarTodosClientes()`, `ConsultarClienteCodigo()`, `ConsultarClienteNome()`: Métodos para consulta de dados.
