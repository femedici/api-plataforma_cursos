<template>
  <!DOCTYPE html>
  <html lang="en">

  <body>
    <div class="container1">
      <div class="scroll-fade1">
        Lista de Cursos Disponiveis
      </div>
    </div>
    <div class="centralize">
      <button @click="fetchData">Buscar Dados</button>
    </div>
    <table class="centralize">


      <thead>
        <tr>
          <th>Cursos: </th>
        </tr>
      </thead>

      <tbody>
        <tr v-for="(item, index) in data" :key="index">
          <td>{{ item.title }}</td>
          <router-link :to="'/view-course/' + item.id" class="nav-link1">VER</router-link>
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

<style src="./style.css"></style>