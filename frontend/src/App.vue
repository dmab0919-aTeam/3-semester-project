<template>
  <div id="app">
    <Navbar />

    <div v-for="movie in movies" :key="movie.title">
      <MovieItem 
        :title="movie.title"
        :release_year="movie.release_year"
        :vote_avarage="movie.vote_avarage"
        :poster_path="movie.poster_path"
      />
    </div>
    <div>
      <b-button>Button</b-button>
      <b-button variant="danger">Button</b-button>
      <b-button variant="success">Button</b-button>
      <b-button variant="outline-primary">Button</b-button>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
import MovieItem from "./components/MovieItem";
import Navbar from "./components/Navbar";
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

export default {
  name: 'App',
  data() {
    return {
      movies: []
    }
  },
  components: {
    MovieItem, Navbar
  },
  
  created() {
    axios.get("movies")
        .then(response => {
          this.movies = response.data
        }).catch(err => {
      console.log(err)
    });
  }
}
</script>

<style>
#app {
  font-family: Aria, Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: white;
}

</style>
