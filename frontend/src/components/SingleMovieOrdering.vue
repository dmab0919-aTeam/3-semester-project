<template>
  <div class="movie-card">
    <div class="container">
      <div class="showing-container">
        <div class="container">
          <form class="form-login" @submit.prevent="login">
            <h1>Login</h1>
            <label for="email">Email:</label><br>
            <input id="login.email" required v-model="email" type="text" placeholder="Enter Email"/>
            <br>
            <label for="email">Password:</label><br>
            <input id="login.password" required v-model="password" type="password" placeholder="Enter Password"/>
            <button type="submit">Login</button><br>
          </form>
        </div>
      </div>
    </div>
    <div class="container">
      <div class="form-container">
        <form class="form" @submit.prevent="register">
          <label>First name:</label>
          <input id="firstname" v-model="firstname" type="text"><br>
          <label>Last name:</label>
          <input id="lastname" v-model="lastname" type="text"><br>
          <label>Email:</label>
          <input id="email" v-model="regemail" type="email"><br>
          <label>Phone number:</label>
          <input id="phonenumber" v-model="phone" type="text"><br>
          <label>Password:</label>
          <input id="password" v-model="regpassword" type="password"><br>
          <button type="submit">Register</button><br>
          
        </form>
      </div>
    </div>
  </div> <!-- end movie-card -->
</template>

<script>
// import axios from 'axios';

import axios from "axios";

export default {
  name: "singleMovieOrdering",

  data() {
    return {
        showingId: '',
        email: '',
        password: '',
        firstname: '',
        lastname: '',
        regemail : '',
        phone: '',
        regpassword: ''
      }
  },
  methods: {
    ProcessOrder() {
      
    },
    login() {
      const email = this.email;
      const password = this.password;
      
      this.$store.dispatch('login', { email, password })
          .then(() => {
            this.ProcessOrder();
          }).catch(() => {
        console.log('Noget gik galt!')
      });
    },
    register() {
      axios.post('auth/register', {
        FirstName: this.firstname,
        LastName: this.lastname,
        Email: this.regemail,
        PhoneNumber: this.phone,
        Password: this.regpassword
      }).then(response => {
        console.log(response.data)
        const email = this.regemail;
        const password = this.regpassword;
        this.$store.dispatch('login', { email, password })
            .then(() => {
              this.ProcessOrder();
            }).catch(() => {
          console.log('Noget gik galt!')
        });
      }).catch(error => {
        console.log(error)
      })
    }
  },

  created() {
    this.showingId = 1 * this.$route.params.showingid
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