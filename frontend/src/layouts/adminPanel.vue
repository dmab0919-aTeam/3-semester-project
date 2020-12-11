<template>
    <div class="container">
        <div class="header">
            <h1>Welcome to the Admin Panel</h1>
        </div>

        <div class="create-container">
            <div class="showing-form">
                <form class="form" @submit.prevent="createshowing">
                <h3>Create Showing</h3>
                <label>Price:</label><br>
                <input id="price" v-model="firstname" type="number" placeholder="Enter Price"><br>
                
                <label>Date:</label><br>
                <input id="date" v-model="lastname" type="date" placeholder=""><br>
                
                <label>Time:</label><br>
                <input id="time" v-model="regemail" type="time" placeholder=""><br>
                
                <label>Hallnumber:</label><br>
                <input id="hallnumber" v-model="phone" type="number" placeholder="Enter Number"><br>
                
                <label>Movie Id:</label><br>
                <input id="movieid" v-model="regpassword" type="number" placeholder="Enter valid id"><br>
                <button type="submit">Create</button><br>
                </form>
            </div>
             <div class="list-container">
                <h3>Showings:</h3>
                <ul class="showing-list">
                    <li class="list-item" v-for="(item, key) in this.showings" v-bind:key="key">
                      {{ item.id }} {{ item.hallNumber }} {{ item.movieID }} {{ item.price }} {{ item.showingTime }}
                        <button class="list-button">Update</button>
                        <button class="list-button" @click.prevent="deleteShowing(item.id)">Delete</button>
                    </li>   
                </ul>
            </div>
            <div class="user-form">
                <form class="form" @submit.prevent="createuser">
                <h3>Create User</h3>
                <label>First name:</label><br>
                <input id="firstname" v-model="firstname" type="text" placeholder="Enter First Name"><br>
                
                <label>Last name:</label><br>
                <input id="lastname" v-model="lastname" type="text" placeholder="Enter Last Name"><br>
                
                <label>Email:</label><br>
                <input id="email" v-model="regemail" type="email" placeholder="Enter Email"><br>
                
                <label>Phone number:</label><br>
                <input id="phonenumber" v-model="phone" type="text" placeholder="Enter Phone Number"><br>
                
                <label>Password:</label><br>
                <input id="password" v-model="regpassword" type="password" placeholder="Enter an password"><br>
                <button type="submit">Create</button>
                </form>
            </div>
            <div class="list-container">
                <h3>Users:</h3>
                <ul class="user-list">
                  <li class="list-item" v-for="(item, key) in this.users" v-bind:key="key">
                    {{ item.id }} {{ item.firstName }} {{ item.lastName }} {{ item.email }} {{ item.phoneNumber }} {{ item.userRole }}
                        <button class="list-button">Update</button>
                    <button class="list-button" @click.prevent="deleteUser(item.id)">Delete</button>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</template>

<script>
import axios from "axios";

export default {
  name: 'AdminPanel',
  data() {
    return {
      showings: [],
      users: []
    }
  },
  methods: {
    fetchAllShowing() {
      axios.get('showing').then(response => {
        this.showings = response.data
      })
    },
    fetchAllUsers() {
      axios.get('user').then(response => {
        this.users = response.data
      })
    },
    deleteShowing(id) {
      axios.delete(`showing/${id}`).then(response => {
        this.fetchAllShowing()
        console.log(response) //ToDo der skal ske noget her! 
      }).catch(error => {
        console.log(error)
      })
    },
    deleteUser(id) {
      axios.delete(`user/${id}`).then(response => {
        this.fetchAllUsers()
        console.log(response) //ToDo der skal ske noget her! 
      }).catch(error => {
        console.log(error)
      })
    }
  },
  created() {
    this.fetchAllShowing()
    this.fetchAllUsers()
  }
}
</script>

<style scoped>
html {
  box-sizing: border-box;
}
*, *:before, *:after {
  box-sizing: inherit;
}
html, body {
    height: 100%;
    color: white;
    background-color: white;
}
.h3 {
    margin: 0px;
    padding: 0px;
}
input {
    margin-bottom: 1em;
}

.list-button {
    float: right;
    padding-left: 2em;
    padding-right: 2em;
    margin-right: .5em;
    cursor: pointer;
}
.container {
    background-color: white;
    overflow: scroll;
    border-radius: 1em;
    height: 100vh;
    padding: 1em;
}

.header {
    text-align: center;
    float: left;
    width: 100%;
}

.create-container {
    float: left;
    width: 100%;
    height: 100%;
}
.showing-form, .user-form {
    float: left;
    margin: 1%;
    padding: .5em;
    border: 2px solid grey;
    border-radius: 5px;
    height: 60%;
    overflow: scroll;
    width: 20%;
}

.list-container {
    float: left;
    height: 60%;
    overflow: scroll;
    margin: 1%;
    padding: .5em;
    width: 70%;
    border: 2px solid grey;
}

.showing-list, .user-list{
  margin:0;
  overflow:auto;
  padding: .5em;
  text-indent:10px;
  max-width: 100%;
  max-height: 340px;
  height: 340px;
  border: 1px solid black;
}
.list-item{
  line-height:25px;
  border-bottom: 1px solid;
}

li:nth-child(even){
  background:#ccc;
}

</style>