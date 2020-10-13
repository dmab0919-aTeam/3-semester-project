<template>
  <div id="app">
    <img alt="Vue logo" src="./assets/logo.png">
    <HelloWorld :msg="'Product: ' + productName1 + ', price: ' + productPrice1 + ' k' "/>
    <HelloWorld :msg="'Product: ' + productName2 + ', price: ' + productPrice2 + ' USD' "/>
  </div>
</template>

<script>
import HelloWorld from './components/HelloWorld.vue'
import axios from 'axios';

export default {
  name: 'App',
  data() {
    return {
      productName1 : null,
      productPrice1 : null,
      productName2 : null,
      productPrice2 : null,
    }
  },
  components: {
    HelloWorld
  },
  
  created() {
    axios.get("products")
        .then(response => {
          this.productName1 = response.data[0].name;
          this.productPrice1 = response.data[0].price;
          this.productName2 = response.data[1].name;
          this.productPrice2 = response.data[1].price;
        }).catch(err => {
      console.log(err)
    });
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
