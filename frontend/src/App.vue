<template>
  <div id="app">
    <router-view>
      
    </router-view>
    <Footer/>
  </div>
</template>

<script>
import Footer from "./components/Footer";

export default {
  components: {
    Footer
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
