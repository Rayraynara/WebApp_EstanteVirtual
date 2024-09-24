# Sistema de Comércio Eletrônico de Livros

## Documento de Requisitos

### 1. Introdução

O sistema de comércio eletrônico de livros novos e usados tem como objetivo fornecer uma plataforma online exclusivamente para compra e venda de livros. Este documento descreve os requisitos funcionais e não funcionais do sistema.

### 2. Requisitos Funcionais

#### 2.1 Autenticação de Usuários

- **Criação de conta:**
  Os usuários devem poder criar uma conta fornecendo informações como nome, CPF, e-mail, telefone, endereço com CEP e números dos cartões de crédito.

- **Login:**
  Os usuários registrados devem poder fazer login usando seu e-mail e senha.

- **Logout:**
  Os usuários devem poder fazer logout a qualquer momento.

- **Edição de conta:**
  Os usuários devem poder editar as informações de sua conta, incluindo nome, e-mail, telefone, endereço e números dos cartões de crédito.

- **Remoção de conta:**
  Os usuários devem poder solicitar a exclusão permanente de sua conta.

#### 2.2 Gerenciamento de Produtos

- **CRUD de produto:**
  Os administradores devem poder adicionar, visualizar, editar e excluir produtos do sistema.
  Cada produto deve ter as seguintes informações:
  - Nome
  - Preço
  - Marca (para livros, isso pode se referir à editora)
  - Quantidade em estoque
  - Dia e hora da venda de cada produto

#### 2.3 Informações de Vendas

- **Informações sobre vendas:**
  Os usuários devem poder acessar informações sobre vendas de produtos nos seguintes formatos:
  - Dia e hora das vendas de um produto no período selecionado pelo usuário: dias, semanas ou meses.
  - Total vendido de um produto no período selecionado pelo usuário: dias, semanas ou meses.

### 3. Requisitos Não Funcionais

- **Segurança:**
  O sistema deve garantir a segurança das informações dos usuários, incluindo senhas e números de cartão de crédito.

- **Usabilidade:**
  A interface do usuário deve ser intuitiva e fácil de usar, proporcionando uma boa experiência ao usuário.

- **Desempenho:**
  O sistema deve ter um bom desempenho, garantindo tempos de resposta rápidos mesmo em períodos de alto tráfego.

- **Confiabilidade:**
  O sistema deve ser confiável e estar disponível a maior parte do tempo, com um tempo mínimo de inatividade planejado para manutenção.

### 4. Restrições

- **Padrão Arquitetural:** 
O sistema será desenvolvido utilizando uma arquitetura de aplicação web, seguindo os princípios do padrão MVC (Model-View-Controller).
  
- **Frameworks e Persistência:** 
O sistema foi desenvolvido utilizando HTML e CSS no front-end, sem o uso de frameworks de desenvolvimento web. No back-end, foi implementado em C# com ASP.NET Core, utilizando o Entity Framework para a manipulação de dados. O SQL Server foi utilizado como o sistema de gerenciamento de banco de dados para persistência dos dados.

Para mais detalhes, consulte o [Documento de Requisitos - Projeto Integrador III](https://docs.google.com/document/d/1D7Bxuh2fgGddgJQnTyjALp0L_)
