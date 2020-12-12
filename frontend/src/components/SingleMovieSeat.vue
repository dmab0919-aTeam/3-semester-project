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
          <p v-if="data.hasError">{{ this.data.errorMessage }}</p>
          <div class="showings">
            <seat-picker v-if(data.renderComponent) :selectedSeats="this.data.selectedSeats" :showingId="1 * this.$route.params.showingid"/> 
          </div>
          <div class="btn">
            <button class="continue-btn" @click.prevent="reserveSeats()">Continue</button>
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
    import {uuid} from 'vue-uuid'
 
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
                    showingId: '',
                    renderComponent: true,
                    key: uuid.v1()
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
            gotoorder() {
              this.$router.push({ name: 'singleMovieOrdering', params: { id: this.$route.params.id, showingid: (1 * this.$route.params.showingid), seats: JSON.stringify(this.data.selectedSeats), key: this.data.key} })
            },
            reserveSeats() {
              if(this.data.selectedSeats.length === 0){
                this.data.errorMessage = "You need to vælge nogle seats";
                this.data.hasError = true;
              } else{
                this.data.errorMessage = "";
                this.data.hasError = false;
                axios.post('seat', {
                  UUID: this.data.key,
                  showingId: 1 * this.$route.params.showingid,
                  selectedseats: this.data.selectedSeats
                  }).then(response => {
                  if (response.status === 200) {
                    this.gotoorder()
                  }
                }).catch(err => {
                  this.data.errorMessage = "Could not reserve seats,  check your selections and try again";
                  this.data.hasError = true;
                  this.data.renderComponent = false;
                  this.$nextTick(() => {
                  // Add the component back in
                    this.renderComponent = true;
                  });
                  console.log(err)
                })
            }},
        
        },
        created() {
            this.fetchSingleMovie();
            this.data.showingId = 1 * this.$route.params.showingid
            clearInterval(this.internal)
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