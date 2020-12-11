<template>
  <div class="container">
      <h1>Login or Register</h1>
      <p>If you don't have an account then, create an new by register. Else just login and continue to payment.</p>
      <div class="login-form">
          <form class="form-login" @submit.prevent="login">
            <h2>Login</h2>
            <label for="email">Email:</label><br>
            <input id="login.email" required v-model="email" type="text" placeholder="Enter Email"/>
            <br>
            <label for="email">Password:</label><br>
            <input id="login.password" required v-model="password" type="password" placeholder="Enter Password"/>
            <br>
            <button type="submit">Login</button><br>
          </form>
      </div>

      <div class="register-form">
        <form class="form" @submit.prevent="register">
          <br><br>
          <h2>Register</h2>
          <label>First name:</label>
          <br>
          <input id="firstname" v-model="firstname" type="text" placeholder="Enter First Name"><br>
          <label>Last name:</label>
          <br>
          <input id="lastname" v-model="lastname" type="text" placeholder="Enter Last Name"><br>
          <label>Email:</label>
          <br>
          <input id="email" v-model="regemail" type="email" placeholder="Enter Email"><br>
          <label>Phone number:</label>
          <br>
          <input id="phonenumber" v-model="phone" type="text" placeholder="Enter Phone Number"><br>
          <label>Password:</label>
          <br>
          <input id="password" v-model="regpassword" type="password" placeholder="Enter an password"><br>
          <button type="submit">Register</button><br>
        </form>
      </div>
    </div>
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
    PayOrder() {
      this.$router.push({ name: 'payment', params: { id: this.$route.params.id, showingid: (1 * this.$route.params.showingid), seats: this.$route.params.seats} })
    },
    login() {
      const email = this.email;
      const password = this.password;
      
      this.$store.dispatch('login', { email, password })
          .then(() => {
            this.PayOrder();
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
              this.PayOrder();
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

input {
  width: 20em;
  height: 2em;
  margin-bottom: 2em;
  border: none;
  border-bottom: 2px solid black;
}
input:focus {
  background-color: black;
  color: white;
  border-color: white
}

button {
  width: 30%;
  font-size: 14px;
  border-radius: 5px;
  transition: all ease-in 0.8s;
}

 button:hover {
  cursor: pointer;
  background-color: black;
  color: white;
}

.container {
  font: 18px/26px "Lato", Arial, sans-serif;
  color: black;
  background-color: rgb(243, 243, 243);
  min-height: 90vh;
  margin: 2em;
  padding: 2em;
  border-radius: 10px;
  text-align: center;
}

.login-form, .register-form {
  text-align: center;
  width: 50%;
  margin-left: 25%;
  max-height: 100%;
}

</style>