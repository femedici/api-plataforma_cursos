# API - LaMoon  
> Application developed for the Integrative Project course - BCC 2023  

Portuguese Readme:
[README_PT](README_PT.md)

## Description  
An online courses API where a user can enroll in a course, track progress, complete courses, and even become a creator to publish their own courses.  

> Courses List Page:  
![Databrick project with Snowflake](imgs/courses.png)  

> Main Course Page:  
![Databrick project with Snowflake](imgs/first-page.png)  

## Features  

- Login session with different user types (Regular, Creator, Administrator)  
- Automated course progression requests  
- Creator approval with integrated front-end request  
- Course customization upon publication and editing  

## Documentation and Structure  
API request documentation, JSON structure, and integration details can be found in *README_Back.md* and *README_Front.md*, respectively.  

The application is structured into front-end and back-end, both included in this repository.  

- The *'\apilamoon'* folder represents the back-end, developed in C#, .NET 6.0, and NoSQL (MongoDB).  
- The *'\weblamoon'* folder represents the front-end, developed in Vue.js, JavaScript, and TailwindCSS.  

> Using Swagger for request testing and object structure:  
![Databrick project with Snowflake](imgs/swagger.png)  

## Languages and Technologies  

**Back-end:**  
[![My Skills](https://skillicons.dev/icons?i=cs,dotnet,mongodb)](https://skillicons.dev)  

**Front-end:**  
[![My Skills](https://skillicons.dev/icons?i=vue,tailwind,js)](https://skillicons.dev)  

## Running Locally  

Clone the project:  

```bash
  git clone https://github.com/femedici/api-plataforma_cursos.git
```  

Navigate to the 'apilamoon' directory (back-end):  

```bash
  cd /apilamoon
```  

Start the server:  

```bash
  dotnet run
```  

Navigate to the 'weblamoon' directory (front-end):  

```bash
  cd /weblamoon
```  

Install dependencies:  

```bash
  npm i
```  

Start the server:  

```bash
  npm run serve
```  

Access the application at: http://localhost:8080/  

## Author  

- [@femedici](https://github.com/femedici)  

### Contributors  

- [@femattok](https://github.com/mattokgit44)  
- [@femoran](https://github.com/feliperm17)  
- [@caioducati](https://github.com/Cast43)  