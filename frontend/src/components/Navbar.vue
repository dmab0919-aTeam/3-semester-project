<template>
        <div class="navbar-wrapper">
            <img :src="logo"/>
        </div>
</template>

<script>
import logo from "../assets/logo.png"

export default {
    data: function() {
        return {
            logo: logo
        }
    }
}
</script>

<style>
    
    .navbar-wrapper {
        margin: 0px;
        background-color: white;
        width: 100%;
        border-radius: 5px;   
        text-align: center;
        position: absolute;
    }

    img {
        max-width: 100%;


    }

</style>