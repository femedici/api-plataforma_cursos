# Back - apilamoon
> Descrição da estruturação do projeto e documentação da api.

## Documentação - Cursos 

#### Retorna todos os cursos

```http
  GET /courses
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `api_key` | `string` | **Obrigatório**. A chave da sua API |

#### Retorna um curso pelo ID

```http
  GET /courses/id/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. Obrigatório. O ID do curso que você quer |


#### Retorna todos os cursos de um criador

```http
  GET /courses/creatorId/{creatorId}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `creatorId`      | `int` | **Obrigatório**. Obrigatório. O ID do criador dos cursos |


#### Retorna um curso pelo título

```http
  GET /courses/title/{title}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `title`      | `string` | **Obrigatório**. O título do curso que você quer |


#### Atualiza o ícone de um curso pelo ID
```http
  PUT /courses/icon
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. O ID do curso para o qual o ícone será atualizado|
| Corpo da Requisição | `IFormFile` | **Obrigatório**. Detalhes do curso atualizado |


#### Atualiza o banner de um curso pelo ID
```http
  PUT /courses/banner
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. O ID do curso para o qual o banner será atualizado |
| Corpo da Requisição | `IFormFile` | **Obrigatório**. Detalhes do curso atualizado |


## Documentação - Inscrições

#### Retorna todas as inscrições

```http
  GET /subscription
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `api_key` | `string` | **Obrigatório**. A chave da sua API |

#### Retornar todas as inscrições de um usuário

```http
  GET /subscription/idUser/{idUser}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `idUser`      | `int` | **Obrigatório**. Obrigatório. O ID do usuário da sessão |

#### Retorna uma inscrição específica de um usuário e curso

```http
  GET /subscription/user/{idUser}/course/{idCourse}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `idUser`      | `int` | **Obrigatório**. Obrigatório. O ID do usuário da sessão |
| `idCourse`      | `int` | **Obrigatório**. Obrigatório. O ID do curso em específico |

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

