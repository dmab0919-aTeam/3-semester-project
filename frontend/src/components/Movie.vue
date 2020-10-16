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
    margin: 1em;
    cursor: pointer;
    transition: all 0.25s ease;
}

.item:hover {
    transform: scale(1.1, 1.1);
}

.subtitle {
    color: grey;
    font-style: normal;
}

.overflow-ellipsis {
    text-overflow: ellipsis;
}

img {
    max-height: 20em;
    max-width: 15em;
}

img:hover {
    box-shadow: 1px 0px 12px 12px rgba(211,84,0,0.64);
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