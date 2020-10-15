<template>
    <div class="movie-item">
        <div class="image_wrapper">
            <img src="https://image.tmdb.org/t/p/w500/7W0G3YECgDAfnuiHG91r8WqgIOe.jpg" 
            alt="A movie"></div>
        <div class="movie-item_information_wrapper">
            <p class="overflow-ellipsis"><strong>{{ movie.title}}</strong> </p>
            <p class="subtitle">Year: {{ movie.releaseYear }} | Rating: {{ movie.rating }} </p>
        </div>
    </div>
</template>


<script>
export default {
    data() {
        return {
            movie: {
                title: 'Trolls world tour this is an other system',
                rating: '5.9',
                releaseYear: '2019'
            }
        }
    }
}
</script>

<style scoped>
    .movie-item {
        border-radius: 5px;
        box-sizing: border-box;
        margin: 1em;
        cursor: pointer;
        transition: all 0.25s ease;
        width: 14em;
        height: 20em;
        float: left;
    }

    .movie-item:hover {
        transform: scale(1.1, 1.1);
        color: #ffee10;
        box-shadow: 0 0 15px #ffee10;
    }

    .movie-item_information_wrapper {
        border-radius: 5px;
        text-align: left;
             
    }

    .subtitle {
        color: grey;
        font-style: normal;
    }

    .overflow-ellipsis {
        text-overflow: ellipsis;
    }

    img {
        max-height: 100%;
        max-width: 100%;
    }

    p {
        overflow: hidden;
        white-space: nowrap; 

        color: rgb(231, 231, 231);
        font-size: 1em;
        padding: 0px;
        margin: 0px; 
    }



</style>