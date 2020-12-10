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
              <p v-if="data.hasError">{{ this.data.errorMessage }}</p>
              <p>Choose a showing for this movie: {{ this.data.title }} </p>
              <label>
                <select class="dropdown-menu" v-model="data.selected_showing">
                  <option v-for="(item, key) in this.data.showings" v-bind:key="key" :value="item.id">
                    <a>Seat Price {{ item.price }} DKK</a>
                    {{ item.showingTime }}
                  </option>
                </select>
              </label>
              <button class="continue-btn" @click.prevent="selectshowing()">Continue</button>
              <button class="back-btn" @click="$router.go(-1)">Back</button>
            </div>
          </div>
        </div>
    </div> <!-- end movie-card -->
</template>

<script>
    import axios from 'axios';
 
    export default {
        name: "singleMovie",
        
        data() {
            return {
                data: {
                    hasError: false,
                    errorMessage: '',
                    selected_showing: '',
                    title: '',
                    release_year: '',
                    vote_avarage: '',
                    poster_path: '',
                    backdrop_path: '',
                    description: '',
                    id: '',
                    showings: []
                },
            }   
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
            fetchShowings() {
            axios.get(`showing/movie/${this.$route.params.id}`).then(response => {
                this.data.showings = response.data
              }).catch(err => {
                console.log(err)
              });
            },
            selectshowing() {
              if(this.data.selected_showing === ""){
                this.data.errorMessage = "You need to vælge an dato";
                this.data.hasError = true;
              } else{
                this.data.hasError = false;
                this.data.errorMessage = "";
                console.log(this.data.selected_showing);
                this.$router.push({ name: 'singleMovieSeat', params: { id: this.$route.params.id, showingid: this.data.selected_showing} })
                //this.$router.push({ name: 'singleMovieSeat', params: { id: this.$route.params.id, showingid: this.data.selected_showing.id} })
              }
            }
        },

        created() {
          this.data.title = this.$route.params.title;
          this.data.release_year = this.$route.params.release_year;
          this.data.vote_avarage = this.$route.params.vote_avarage;
          this.data.poster_path = this.$route.params.poster_path;
          this.data.backdrop_path = this.$route.params.backdrop_path;
          this.data.description = this.$route.params.description;
          this.fetchSingleMovie();
          this.fetchShowings();

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
  width: 50%;
  float: left;
}


.container {
  display: flex;
  text-align: center;
  width: 50%;
  margin-left: 25%;
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
  float: left;
  position: relative;
}

.continue-btn{
  width: 50%;
  margin-top: 1em;
}

</style>