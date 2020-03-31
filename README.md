# WebMotors - Gerenciador de Anuncios
API Rest para gerenciamento de anuncios da webmotors.
## Tecnologias utilizadas:
- ASP .NET Core 3.1 WebAPI
- Banco de dados SQL Server
  
## Bibliotecas utlizadas para desenvolvimento
- Entity Framework Core 3.1.3
- Swagger (Swashbuckle.AspNetCore 5.2.1)

Para esta aplicação, utilizei os seguintes padrões de desenvolvimento:
### 1. MVC
### 2. Inversão de controle
Nenhum objeto é instânciado diretamente dentro dos métodos, todos os objetos são injetados diretamente no construtor da classe.
### 3. Injeção de Dependência
Framework de injeção de dependência nativo do ASP .NET Core.
### 4. Testes de Unidade
Ao Executar o projeto de Tests, serão executados 24 Testes de unidades.
## Guia de instalação
1. Fazer o Download do .NET Core 3.1 ([Clique Aqui](https://dotnet.microsoft.com/download/visual-studio-sdks?utm_source=getdotnetsdk&utm_medium=referral "Clique Aqui"))
2. Fazer a instalação no computador.
3. Criar banco de dados no SQL Server utilizado o arquivo de Scripts "BancoDeDados.SQL".
3. Abrir o projeto no Visual Studio 2019
4. Clicar com o Botão direito do mouse no projeto WebAPI e selecionar a Opção "Manage User Secrets". 
5. Colar o JSON Abaixo dentro da secrets, substituindo [Servidor], [NomeDoBanco], [Usuário], [Senha] pelas informações do Seu banco de dados.
> {
  "ConnectionString": "Data Source=[Servidor];Initial Catalog=[NomeDoBanco];Integrated Security=false;User Id=[Usuário];password=[Senha]"
}
6. Executar o projeto.
