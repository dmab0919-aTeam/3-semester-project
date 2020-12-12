<template>
    <div class="container">
        <div class="header">
            <h1>Welcome to the Admin Panel</h1>
        </div>
        <div class="create-container">
            <div class="showing-form">
                <form class="form">
                <h3>Create Showing</h3>
                <label>Price:</label><br>
                <input id="price" v-model="showing.Price" type="number" placeholder="Enter Price"><br>
                <label>Date:</label><br>
                <input id="datetime" v-model="showing.ShowingTime" type="datetime-local" placeholder=""><br>
                <label>Hallnumber:</label><br>
                <input id="hallnumber" v-model="showing.HallNumber" type="number" placeholder="Enter Number"><br>
                <label>Movie Id:</label><br>
                <input id="movieid" v-model="showing.MovieID" type="number" placeholder="Enter valid id"><br>
                <button v-if="createOrUpdateShowing" @click.prevent="createShowing">Create</button><br>
                <button v-if="!createOrUpdateShowing" @click.prevent="putShowing">Update</button><br>
                <button v-if="!createOrUpdateShowing" @click.prevent="wipeShowingObject">Cancel</button><br>
                </form>
            </div>

            <div class="table-container">
                <table class="table">
                    <tr>
                        <th>Id:</th>
                        <th>HallNumber:</th>
                        <th>MovieID</th>
                        <th>Price:</th>
                        <th>ShowingTime:</th>
                    </tr>
                    <tr v-for="(item, key) in this.showings" v-bind:key="key">
                        <td>{{ item.id }}</td>
                        <td>{{ item.hallNumber }}</td>
                        <td>{{ item.movieID }}</td>
                        <td>{{ item.price }}</td>
                        <td>{{ item.showingTime }}</td>
                        <td><button class="list-button" @click.prevent="updateShowing(item.id, item.price, item.showingTime, item.hallNumber, item.movieID)">Update</button></td>
                        <td><button class="list-button" @click.prevent="deleteShowing(item.id)">Delete</button></td>
                    </tr>
                </table>
            </div>
            <div class="user-form">
                <form class="form" @submit.prevent="createUser">
                <h3>Create User</h3>
                <label>First name:</label><br>
                <input id="firstname" v-model="user.FirstName" type="text" placeholder="Enter First Name"><br>
                
                <label>Last name:</label><br>
                <input id="lastname" v-model="user.LastName" type="text" placeholder="Enter Last Name"><br>
                
                <label>Email:</label><br>
                <input id="email" v-model="user.Email" type="email" placeholder="Enter Email"><br>
                
                <label>Phone number:</label><br>
                <input id="phonenumber" v-model="user.PhoneNumber" type="text" placeholder="Enter Phone Number"><br>
                
                <label>Role:</label><br>
                <input type="text" name="role" v-model="user.UserRole" list="roles">
                    <datalist id="roles">
                        <option value="Admin"></option>
                        <option value="User"></option>
                    </datalist><br>

                <label>Password:</label><br>
                <input id="password" v-model="user.Password" type="password" placeholder="Enter an password"><br>
                  <button v-if="createOrUpdateUser" @click.prevent="createUser">Create</button><br>
                  <button v-if="!createOrUpdateUser" @click.prevent="putUser">Update</button><br>
                  <button v-if="!createOrUpdateUser" @click.prevent="wipeUserObject">Cancel</button><br>
                </form>
            </div>

            <div class="table-container">
                <table class="table">
                    <tr>
                      <th>Name:</th>
                      <th>Last Name:</th>
                      <th>Email:</th>
                      <th>Phone:</th>
                      <th>Role:</th>
                    </tr>
                    <tr v-for="(item, key) in this.users" v-bind:key="key">
                      <td>{{ item.firstName }}</td>
                      <td>{{ item.lastName }}</td>
                      <td>{{ item.email }}</td>
                      <td>{{ item.phoneNumber }}</td>
                      <td>{{ item.userRole }}</td>
                      <td><button class="list-button" @click.prevent="updateUser(item.id, item.firstName, item.lastName, item.email, item.phoneNumber, item.userRole)">Update</button></td>
                      <td><button class="list-button" @click.prevent="deleteUser(item.id)">Delete</button></td>
                    </tr>
                </table>
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
      createOrUpdateShowing: true,
      createOrUpdateUser: true,
      showings: [],
      users: [],
      user: {
        Id: '',
        FirstName: '',
        LastName: '',
        Email: '',
        PhoneNumber: '',
        Password: '',
        UserRole: ''
      },
      showing: {
        id: '',
        Price: '',
        ShowingTime: '',
        HallNumber: '',
        MovieID: ''
      }
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
    },
    createUser() {
      axios.post('user', {
        FirstName: this.user.FirstName,
        LastName: this.user.LastName,
        Email: this.user.Email,
        PhoneNumber: this.user.PhoneNumber,
        Password: this.user.Password,
        UserRole: this.user.UserRole,
      }).then(response => {
        this.user.FirstName = null
        this.user.LastName = null
        this.user.Email = null
        this.user.PhoneNumber = null
        this.user.Password = null
        this.user.UserRole = null
        this.fetchAllUsers()
        console.log(response)
      }).catch(error => {
        console.log(error)
      })
    },
    createShowing() {
      axios.post('showing', {
        Price: this.showing.Price,
        ShowingTime: this.showing.ShowingTime,
        HallNumber: this.showing.HallNumber,
        MovieID: this.showing.MovieID,
      }).then(response => {
        this.wipeShowingObject()
        this.fetchAllShowing()
        console.log(response)
      }).catch(error => {
        console.log(error)
      })
    },
    updateShowing(id, Price, ShowingTime, HallNumber, MovieID) {
      this.createOrUpdateShowing = false
      this.showing.id = id
      this.showing.Price = Price
      this.showing.ShowingTime = ShowingTime
      this.showing.HallNumber = HallNumber
      this.showing.MovieID = MovieID
    },
    putShowing() {
      axios.put('showing', {
        id: this.showing.id,
        Price: this.showing.Price,
        ShowingTime: this.showing.ShowingTime,
        HallNumber: this.showing.HallNumber,
        MovieID: this.showing.MovieID,
      }).then(response => {
        this.wipeShowingObject()
        this.fetchAllShowing()
        console.log(response)
      }).catch(error => {
        console.log(error)
      })
    },
    wipeShowingObject() {
      this.showing.Price = null
      this.showing.MovieID = null
      this.showing.HallNumber = null
      this.showing.ShowingTime = null
      this.createOrUpdateShowing = true
    },
    wipeUserObject() {
      this.user.id = null
      this.user.FirstName = null
      this.user.LastName = null
      this.user.Email = null
      this.user.PhoneNumber = null
      this.user.Password = null
      this.user.UserRole = null
      this.createOrUpdateUser = true
    },
    updateUser(id, FirstName, LastName, Email, PhoneNumber, UserRole) {
      this.user.id = id
      this.user.FirstName = FirstName
      this.user.LastName = LastName
      this.user.Email = Email
      this.user.PhoneNumber = PhoneNumber
      this.user.UserRole = UserRole
      this.createOrUpdateUser = false
    },
    putUser() {
      axios.put('user', {
        id: this.user.id,
        FirstName: this.user.FirstName,
        LastName: this.user.LastName,
        Email: this.user.Email,
        PhoneNumber: this.user.PhoneNumber,
        UserRole: this.user.UserRole,
      }).then(response => {
        this.wipeUserObject()
        this.fetchAllUsers()
        console.log(response)
      }).catch(error => {
        console.log(error)
      })
    },
  },
  created() {
    this.fetchAllShowing()
    this.fetchAllUsers()
  }
}
</script>

<style scoped>

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

tr:nth-child(even){
  background-color: #f2f2f2;
  }

tr:hover {
  background-color: rgb(187, 187, 187);
}

.list-button {
    float: right;
    cursor: pointer;
    width: 100%;
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
    overflow: auto;
    width: 15%;
}
.table-container {
    float: left;
    overflow: auto;
    height: 60%;
    margin: 1%;
    padding: .5em;
    width: 75%;
    border: 2px solid grey;
}

table {
  text-align: left;
  table-layout: auto;
  width: 100%;
}

</style>