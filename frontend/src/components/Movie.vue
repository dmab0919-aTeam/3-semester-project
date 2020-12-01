<template>
    <li class="item">
        <div class="movie-item_image">
            <img :src="'https://image.tmdb.org/t/p/w500' + this.poster_path" 
            alt="A movie"/>
        </div>
        <div class="movie-item_info">
            <p class="overflow-ellipsis"><strong>{{ this.title }}</strong> </p>
            <p class="subtitle">Year: {{ this.release_year }} | Rating: {{ this.vote_avarage }} </p>
        </div>
    </li>
</template>

<script>
export default {
  name: 'Frontpage',
      props: {
        title: String,
        release_year: String,
        vote_avarage: Number,
        poster_path: String
    }
}
</script>
 
<style scoped>
  .item {
    height: 25em;
    width: 15em;
    margin: 1em;
    cursor: pointer;
    transition: all 0.50s ease;
}

.item:hover {
    transform: scale(1.1, 1.1);
}

.subtitle {
    color: grey;
    font-style: normal;
}

.overflow-ellipsis {
    overflow: hidden;
    text-overflow: ellipsis;
    color: whitesmoke;
}

img {
    max-width: 100%;
    max-height: 100%;
}

img:hover {
    transition: all 0.50s ease;
    box-shadow: 1px 0px 12px 12px rgba(17, 255, 243, 0.64);
}

p {
    white-space: nowrap; 
    color: rgb(231, 231, 231);
    font-size: 1em;
    padding: 0px;
    margin: 0px; 
}
</style>