# Front - weblamoon
> Especificações de inicialização do ambiente do front da aplicação LaMoon, e descrição da estruturação do projeto.

## Inicialização do ambiente
Os comandos a seguir são necessários para inicialização do ambiente no seu computador:
PS: estar dentro do diretório: ***../api-plataforma_cursos/weblamoon***

> **1° VEZ (Instalando bibliotecas npm no seu ambiente)**
npm i
npm install -g @vue/cli
npm install --save-dev @vue/cli-service --legacy-peer-deps

> **iniciando o projeto**
Set-ExecutionPolicy -Scope Process -ExecutionPolicy RemoteSigned (caso não execute, ou acuse erro)
npm run serve


## Estruturação

Na estrutura do front o ambiente desenvolvido está na pasta ***./src***
Dentro dela, a divisão é feita na seguinte lógica:

> ***/assets***
Neste arquivo estão imagens que são utilizadas na aplicação;

> ***/components***
Neste arquivo estão os componentes que são compartilhados entre todas as páginas do ambiente do front

> ***/pages***
Neste arquivo estão as paginas/lading-pages da aplicação, estão separadas em tipos de objeto do sistema ou tipos de ação tomada

> ***/routes***
Neste arquivo estão as rotas limpas de endereçamento do front, utilizadas para navegação e deixar a URL clean

> **axio.js**
Neste file js é presente o endereço de requisição HTTP do back, estão configurado pela biblioteca 'axios' do vue