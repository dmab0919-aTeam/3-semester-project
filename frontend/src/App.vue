<template>
  <div id="app">
    <frontpage />
  </div>
</template>

<script>
import frontpage from "./layouts/frontpage"

export default {
  name: 'App',
   components: {
    frontpage
  }
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
