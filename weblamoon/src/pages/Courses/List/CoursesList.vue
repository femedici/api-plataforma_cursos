<template>
    <!DOCTYPE html>
    <html lang="en">
    <body>
        <div class="container">
            <div class="scroll-fade">
                Lista de Cursos Disponiveis
            </div>
        </div>
        <table>
        <button @click="fetchData">Buscar Dados</button>
          <thead>
            <tr>
              <th>Cursos: </th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(item, index) in data" :key="index">
              <td>{{ item.title }}</td>
              <router-link :to="'/view-course/' + item.id" class="nav-link">VER</router-link>
            </tr>
          </tbody>
        </table>
        <router-link to="/create-course" class="nav-link">Criar Curso</router-link>
    </body>

    </html>
</template>

<script src="./CoursesList.js"></script>

<style src="./style.css"></style>