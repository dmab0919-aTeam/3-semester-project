<template>
    <div class="container">
        
        <div class="movie-wrapper">
            <h2>Add new movie</h2>
            <label>Title:</label>
            <input v-model="movieTitle" placeholder="Enter Title">
            <br>
            <label>Poster:</label>
            <input v-model="movieTitle" placeholder="Enter Poster Path">
        </div>

        <div class="showing-wrapper">
            <h2>Add new showing</h2>
            <label>Movie id:</label>
            <input v-model="movieid" placeholder="Enter ID">
        </div>
        
    </div>
    
</template>

<script>
export default {

}
</script>

<style scoped>
html, body {
    height: 100%;
    color: white;
    background-color: white;
}

.container {
    background-color: white;
    border: 2px solid green;
    padding: 5px;

    position: absolute;
    left: 50%;
    transform: translate(-50%, 0);
    
    height: 80%;
    width: 80%;

    float: left;
}

.movie-wrapper {
    border: 2px solid red;
    width: 20%;
    height: 100%;
}

.showing-wrapper {
    border: 2px solid red;
    width: 20%;
    height: 100%;
}


</style>