<template>
    <div class="container">
        <div class="img-con">
            <img src="../assets/logo.png" alt="NBA">
        </div>
        <div class="link-container">
            <a class="links" href="">Booking</a>
            <a class="links" href="">Movies</a>
            <a class="links" href="">About us</a>
        </div>
        <div class="input-field">
            <input v-model="Search" placeholder="Find film..">
        </div>
        
        
        
    </div>
</template>

<script>
export default {
}
</script>

<style scoped>
    .container {
        font-family: Arial, Helvetica, sans-serif;
        margin-bottom: 1em;
        background-color:white;
        color: white;
        border-radius: 10px;
        padding: 1em;
        text-align: center;
    }

    .header {
        font-size: 6vh;
        margin: 0px;
    }

    .links {
        text-decoration: none;
        color: black;
        border-radius: 10px;
        text-align: center;
        padding-left: 1.5em;
        padding-right: 1.5em;
        margin: 1em;
        box-sizing: border-box;
        
    }

    .links:hover {
        cursor: pointer;
        background-color: rgba(211,84,0,0.64);
        color: white;

    }

    .link-container {
        display: inline-block;
        
    }

    .input-field {
        display: inline-block;
        
    }

    .input-field input {
        text-align: right;
        
    }

   
</style>