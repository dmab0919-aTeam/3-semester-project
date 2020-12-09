<template>
    <div class="container">
        <div class="img-con">
            <img src="../assets/logo.png" alt="NBA">
        </div>
    </div>
</template>

<script>
export default {
    data() {
      return {
        Search: ''
      }
    },
    methods: {
        gotoLogin: function() {
            this.$router.push({ name: 'login' })
        }
    }
}
</script>

<style scoped>
    .container {
        font-family: Arial, Helvetica, sans-serif;
        margin-bottom: 1em;
        background-color:white;
        border-radius: 10px;
        padding: 1em;
        text-align: center;
    }

    .link-container {
       padding-top: 1em;
    }

    button{
        padding-left: 2em;
        padding-right: 2em;
        border: 2px solid black;
        border-radius: 5px;
    }

    button:hover {
        background-color: black;
        color: white;
    }
</style>