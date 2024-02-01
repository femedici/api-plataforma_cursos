# Front - weblamoon
> Descrição da estruturação do projeto e documentação de objetos.

## Documentação de Objetos - json's

#### Cursos

```
  {
  "id": 0,
  "title": "string",
  "description": "string",
  "mainVideo": "string",
  "bodyText": "string",
  "password": "string",
  "icon": "string",
  "banner": "string",
  "creator": "string",
  "creatorID": 0,
  "creationDate": "string",
  "price": 0
  }
```

#### Tópico

```
  {
  "id": 0,
  "referenceCourse": 0,
  "title": "string",
  "description": "string",
  "video": "string",
  "progress": true
  }
```
#### Inscrição

```
  {
  "id": 0,
  "idCourse": 0,
  "idUser": 0,
  "progression": 0,
  "subscriptionDate": "string",
  "conclusionDate": "string"
  }
```

#### Progressão

```
  {
  "id": 0,
  "idSubscription": 0,
  "idTopic": 0,
  "progress": true
  }
```
#### Usuário

```
  {
  "id": 0,
  "name": "string",
  "email": "string",
  "password": "string",
  "icon": "string",
  "creationDate": "string",
  "creator": true,
  "becameCreator": true
  }
```

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