<template>
  <div class="movie-card">
      <div class="details">
        <h1>{{ this.data.title }}</h1>
      </div> <!-- end details -->
      
      <div class="container">
        <div class="image-container">
          <div class="image">
            <img :src="'https://image.tmdb.org/t/p/w500' + this.data.poster_path" alt="cover" class="cover" />
          </div>
        </div>

        <div class="showing-container">
          <div class="showings">
            <seat-picker :selectedSeats="this.data.selectedSeats" :showingId="this.data.showingId"/> 

          </div>
          <div class="btn">
            <button class="continue-btn" @click.prevent="this.continue()">Continue</button>
          </div>
          <div class="btn">
            <button class="back-btn" @click="$router.go(-1)">Back</button>

          </div>
        </div>
      </div>
  </div> <!-- end movie-card -->
</template>

<script>
    import axios from 'axios';
    import SeatPicker from './SeatPicker.vue'
 
    export default {
        name: "singleMovieSeat",
        
        data() {
            return {
                data: {
                    selectedSeats: [],
                    hasError: false,
                    errorMessage: '',
                    title: '',
                    release_year: '',
                    vote_avarage: '',
                    poster_path: '',
                    backdrop_path: '',
                    description: '',
                    id: '',
                    showingId: ''
                },
            }
        },
        components: {
          SeatPicker
        },
        methods: {
            fetchSingleMovie() {
                axios.get(`movies/${this.$route.params.id}`)
                    .then(response => {
                        this.data.title = response.data.title;
                        this.data.release_year = response.data.releaseYear;
                        this.data.vote_avarage = response.data.voteAverage;
                        this.data.poster_path = response.data.posterPath;
                        this.data.backdrop_path = response.data.backdropPath;
                        this.data.description = response.data.description;
                        this.data.id = response.data.id;
                    }).catch(err => {
                        console.log(err)
                    });
            },
            continueee() {
              this.$router.push({ name: 'singleMovieOrdering', params: { id: this.$route.params.id, showingid: this.data.showingId} })
            }
        },

        created() {
          this.fetchSingleMovie();
          this.data.showingId = 1 * this.$route.params.showingid
      }
      }
</script>

<style scoped>

* {
  box-sizing: border-box;
  font-family: sans-serif;
}

.movie-card {
  font: 18px/26px "Lato", Arial, sans-serif;
  color: black;
  background-color: rgb(243, 243, 243);
  min-height: 60vh;
  margin-left: 10em;
  margin-right: 10em;
  padding: 1em;
  border-radius: 10px;
}

.image-container {
  cursor: pointer;
  border: 2px solid yellow;
}

img { 
  max-width: 100%;
  max-height: 100%;
  box-shadow: 10px 10px 8px grey;
}

.details {
  text-align: center;
}

.container {
  display: flex;
  text-align: center;
  width: 100%;
  
}

.voteaverage {
  font-size: 18px;
  border: 2px solid grey;
  text-align: center;
  padding: 2px;
  border-radius: 5px;
  margin-top: 1em;
}

.showings {
  position: relative;
  
  max-height: 100%;
  margin: 0px;
  padding: 0px;
  padding-left: 7em;
  margin-bottom: 1em;
}

.showing-container {
  width: 100%;
  max-height: 100%;
}
.continue-btn, .back-btn{
  width: 50%;
}

</style>