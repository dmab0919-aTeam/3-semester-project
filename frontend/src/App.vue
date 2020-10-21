<template>
  <div id="app">
    <Navbar/>
    <router-view>
      
    </router-view>
    <Footer/>
  </div>
</template>

<script>
import Navbar from "./components/Navbar";
import Footer from "./components/Footer";



export default {
  components: {
    Navbar, Footer
  },
  name: 'App',
   
}
</script>

<style>
#app {
  font-family: Aria, Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  margin: 1em;
  padding: 0;
  
  min-height: 100vh;
  position: relative;
}
body {
  background-color: rgb(14, 14, 14);
}

</style>
