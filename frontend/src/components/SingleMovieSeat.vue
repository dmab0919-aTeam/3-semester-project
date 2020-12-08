<template>
  <div class="movie-card">
      <div class="details">
        <h1>Title: {{ this.data.title }}</h1>
      </div> <!-- end details -->
      
      <div class="column2">
        <strong>Description:</strong> <p>{{ this.data.description }}</p>
      </div> <!-- end column2 -->

      <div class="container">
        <div class="image-container">
          <div class="image">
            <img :src="'https://image.tmdb.org/t/p/w500' + this.data.poster_path" alt="cover" class="cover" />
            <div class="voteaverage">{{ this.data.vote_avarage }} Vote Average</div>
          </div>
        </div>

        <div class="showing-container">
          <div class="showings">
            <br><br><br><br><br>
            <seat-picker :selectedSeats="this.data.selectedSeats" :showingId="this.data.showingId"/> 

            <button @click.prevent="continuesd()">Continue</button>
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
            continuesd() {
              axios.post(`seat`, {
                seatreservationDTO: {
                  seats : this.data.selectedSeats,
                  userId : 1,
                  showingId : 1
                }
              })
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
  min-height: 90vh;
  margin: 2em;
  padding: 2em;
  border-radius: 10px;
}

.image-container {
  height: 25em;
  width: 15em;
  padding-top: 1em;
  margin: 1em;
  cursor: pointer;
}

img { 
  max-width: 100%;
  max-height: 100%;
  box-shadow: 10px 10px 8px grey;
}

.details {
  text-align: center;
}

.column2 {
  padding: 2em;
}


.container {
  display: flex;
}

.voteaverage {
  font-size: 18px;
  border: 2px solid grey;
  text-align: center;
  padding: 2px;
  border-radius: 5px;
}

.showings {
  float: left;
  position: relative;
}
</style>