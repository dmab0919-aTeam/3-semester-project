<template>
    <div>
        <ul class="container">
            <li v-for="movie in movies" :key="movie.title">
            
            <Movie 
            :title="movie.title"
            :release_year="movie.releaseDate"
            :vote_avarage="movie.voteAverage"
            :poster_path="movie.posterPath"
            />
            </li>
        </ul>
    </div>
</template>

<script>
import axios from 'axios';
import Movie from "./Movie";

export default {
  name: 'Frontpage',
  data() {
    return {
      movies: []
    }
  },
  components: {
      Movie
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

<style scoped>
.container {
  display: flex;
  flex-flow: row wrap;
  justify-content: space-around;
  margin: 0;
  padding: 0;
  list-style: none;
}
</style>