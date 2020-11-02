<template>
  <div id="frontpage">
      <Navbar />
      <MovieItem/>
  </div>
</template>

<script>
import MovieItem from "../components/MovieItem";
import Navbar from "../components/Navbar";

export default {
  name: 'Frontpage',
  components: {
    MovieItem, Navbar
  },
}
</script>

<style>

</style>
