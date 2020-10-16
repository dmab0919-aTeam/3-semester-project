<template>
  <div id="frontpage">
      <Navbar/>
      <MovieItem/>
      <Footer/>
  </div>
</template>

<script>
import MovieItem from "../components/MovieItem";
import Navbar from "../components/Navbar";
import Footer from "../components/Footer";

export default {
  name: 'Frontpage',
  components: {
    MovieItem, Navbar, Footer
  },
}
</script>

<style>

</style>
