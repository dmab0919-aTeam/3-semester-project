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
        background-color: rgb(31, 31, 31);
        width: 100%;
        border-radius: 5px;   
    }

    .navbar-movies {
        box-sizing: border-box;
        float: left;
    }

    img {
        max-width: 100%;

    }

</style>