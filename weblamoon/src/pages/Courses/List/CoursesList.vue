<template>
  <!DOCTYPE html>
  <html lang="en">

  <body>
    <div class="container1">
      <div class="scroll-fade1">
        Cursos Disponíveis
      </div>
    </div>

    <table class="centralize">
      <tbody>
        <tr v-for="(item, index) in data" :key="index">
          <td>
            <!-- Contêiner do curso -->
            <div class="course-container">
              <!-- Título do curso -->
              <div class="course-title">{{ item.title }}</div>
              <!-- Descrição do curso -->
              <div class="course-description">{{ item.description }}</div>
              <!-- Botão "Acessar Curso" -->
              <router-link :to="'/view-course/' + item.id" class="access-button">Acessar Curso</router-link>
            </div>
          </td>
        </tr>
      </tbody>
    </table>
    <div class="nav-link1">
      <router-link to="/create-course" class="nav-link1" id="create-course-link1">Criar Curso</router-link>
    </div>
  </body>

  </html>
</template>

<script src="./CoursesList.js"></script>

<style src="./CoursesList.css"></style>