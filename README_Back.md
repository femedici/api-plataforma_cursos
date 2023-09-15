# Back - apilamoon
> Especificações de inicialização do ambiente do back da aplicação LaMoon, e descrição da estruturação do projeto.

## Inicialização do ambiente
Os comandos a seguir são necessários para inicialização do ambiente no seu computador:
PS: estar dentro do diretório: ***../api-plataforma_cursos/apilamoon***

> **iniciando o projeto**
dotnet run

## Estruturação

A divisão da estrutura é feita na seguinte forma:

> **/Models**
Neste arquivo estão presentes as estruturas dos objetos/classes do sistema, cada classe tendo sua respectiva estrutura e controller.

> **appsettings.json**
Neste arquivo está presente principalmente o endereçamento do localhost do banco Mongo, o endereço da conexão da sessão.

> **apilamoon.csproj**
Neste arquivo está presente as expecificações da versão do ASP.NET utilizado e as extensões de mongo integradas na aplicação

> **MeuMongo.cs**
Neste arquivo cria um objeto de conexão chamado MeuMongo, responsável por receber a conexão e utiliza-la na aplicação

> **Program.cs**
Este arquivo é o responsável pelo builder() do back, onde está presente as contruções/builders do services e referenciação do Swagger.