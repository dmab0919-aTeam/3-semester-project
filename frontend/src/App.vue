<template>
  <div id="app">
    <Navbar />
    <MovieItem /> <MovieItem /> <MovieItem /> <MovieItem />
    <p> {{ movie.original_title }} </p>
  </div>
</template>

<script>
import axios from 'axios';
import MovieItem from "./components/MovieItem";
import Navbar from "./components/Navbar";

export default {
  name: 'App',
  data() {
    return {
      movie: {
        original_title: null,
        release_date: null,
        vote_avarage: null
      }
    }
  },
  components: {
    MovieItem, Navbar
  },
  
  created() {
    axios.get("products")
        .then(response => {
          this.response = response.data
          this.original_title = response.data[1].original_title;
          this.release_date = response.data[1].release_date;
          this.vote_avarage = response.data[1].vote_avarage;
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
  color: #2c3e50;
}

body {
  background-color: rgb(20, 20, 20)

}


</style>
